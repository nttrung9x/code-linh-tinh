[DllImport("user32.dll", SetLastError = true)]
public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

public static class ListExtensions
{
    public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
    {
        return source
            .Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / chunkSize)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();
    }
}

public Size GetSizeAdjustedToAspectRatio(int sourceWidth, int sourceHeight, int dWidth, int dHeight)
{
    var newHeight = 0;
    var newWidth = 0;
    if (dWidth != 0)
    {
        newHeight = dWidth * sourceHeight / sourceWidth;
        newWidth = dWidth;
    }
    else
    {
        newWidth = dHeight * sourceWidth / sourceHeight;
        newHeight = dHeight;
    }
    return new Size(newWidth, newHeight);
}

public void ArrangeWindows(List<IntPtr> list, int widthDefault, int heightDefault, bool resize)
{
    int countList = list.Count;
    Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
    while (heightDefault > 0)
    {
        int maxHorizontal = workingArea.Width / widthDefault;
        int maxVertical = workingArea.Height / heightDefault;
        var calVertical = Math.Ceiling((double)countList / maxHorizontal);
        if (calVertical <= maxVertical || !resize)
        {
            var listVertical = list.ChunkBy(maxHorizontal);
            for (int i = 0; i < listVertical.Count; i++)
            {
                int y = heightDefault * i;
                for (int j = 0; j < listVertical[i].Count; j++)
                {
                    int x = widthDefault * j;
                    MoveWindow(listVertical[i][j], x, y, widthDefault, heightDefault, false);
                }
            }
            return;
        }
        else
        {
            var newSize = GetSizeAdjustedToAspectRatio(widthDefault, heightDefault, 0, heightDefault - 10);
            widthDefault = newSize.Width;
            heightDefault = newSize.Height;
        }
    }
}
