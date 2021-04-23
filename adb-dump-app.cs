
//Dump trên giả lập qua port Index : 
public string DumpText(string index, string button, int exitwhile, bool dumx = false, bool tap = true, int x = 0, int y = 0)
{              
    string index_copy = index.Replace(" ", "_");          
    int num = 0;
    string linksdcard = "/sdcard/" + index_copy + ".xml";
    string filename = Directory.GetCurrentDirectory() + @"\dump";
    string linkdump = "pull \"" + linksdcard + "\" " + "\"" + filename + "\"";

    while (true)
    {
        if (dumx == false)
        {
            try
            {
                File.Delete("dump/" + index_copy + ".xml");
            }
            catch (Exception E){}

            string text1 = ExcuteCMD(index, "shell uiautomator dump /sdcard/" + index_copy + ".xml");
            string text2 = ExcuteCMD(index, linkdump);
        }       

        XmlDocument doc = new XmlDocument();
        try
        {
            string linkxml = "dump/" + index_copy + ".xml";
            doc.Load(linkxml);
            XmlNode book;
            XmlNode root = doc.DocumentElement;
            book = root.SelectSingleNode("//node[@text=\'" + button + "\']");
            if (book != null)
            {
                string toadonext = book.Attributes["bounds"].Value;
                toadonext = toadonext.Replace("][", ",").Replace("]", "").Replace("[", "");
                int toado1 = Int32.Parse(toadonext.Split(',')[0]);
                int toado2 = Int32.Parse(toadonext.Split(',')[1]);
                if(tap == true)
                {
                    Tap(index, toado1 + x, toado2 + y);
                }
                return "0";
            }
            else
            {
                Thread.Sleep(1500);
                num++;
                if (num == exitwhile)
                {
                    return "1";
                }
            }
        }catch(Exception E){}
    }
}

//Dump trên điện thoại qua port deviceID: 
public static string DumpText(string deviceID, string button, int exitwhile, bool dumx = false)
{
    int num = 0;
    while (true)
    {
        if (dumx == false)
        {
            ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell uiautomator dump /sdcard/window_dump_" + deviceID + ".xml && adb -s " + deviceID + " pull /sdcard/window_dump_" + deviceID + ".xml");
        }

        XmlDocument doc = new XmlDocument();
        doc.Load("window_dump_" + deviceID + ".xml");
        XmlNode book;
        XmlNode root = doc.DocumentElement;
        book = root.SelectSingleNode("//node[@text=\'" + button + "\']");

        if (book != null)
        {
            string toadonext = book.Attributes["bounds"].Value;
            toadonext = toadonext.Replace("][", ",").Replace("]", "").Replace("[", "");
            int toado1 = Int32.Parse(toadonext.Split(',')[0]);
            int toado2 = Int32.Parse(toadonext.Split(',')[1]);
            ADBHelper.Tap(deviceID, toado1, toado2);
            return "0";
        }
        else
        {
            num++;
            if (num == exitwhile)
            {
                return "1";
            }
        }
    }
}