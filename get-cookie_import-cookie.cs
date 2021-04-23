public void import_cookie(string cookies)
{
    // cookies = "c_user=100065387852794;datr=Zvh;sb=Zvh2YFMengDc8JBfd2PuMrvg;fr=1a6ztHIpinLLrD3Zk..Bgdvhm.qP.AAA.0.0.BgdviD.AWUxvseMIwQ;xs=32%3AbxpqAglBjaSk2A%3A2%3A1618409603%3A-1%3A3838;wd=351x501";
	string[] arrdata = cookies.Split(new char[] { ';' });
    string[] array = arrdata;
    for (int j = 0; j < array.Length; j++)
    {
        string item = array[j];
        try
        {
            string[] pars = item.Split(new char[] { '=' });
            Cookie cok = new Cookie(pars[0].Trim(), pars[1].Trim(), "m.facebook.com", "/", new DateTime?(DateTime.Now.AddDays(10.0)));
            driver.Manage().Cookies.AddCookie(cok);
        }
        catch (Exception)
        { }
    }
}

public string get_cookie()
{
    lines = "";
    for (int t1 = 0; t1 < 8; t1++)
    {
        var cookiees = driver.Manage().Cookies.AllCookies;
        lines = cookiees[t1].ToString() + ";" + lines;
    }
    string c_user = Regex.Match(lines, "c_user=[0-9]{0,}").ToString();
    string wd = Regex.Match(lines, "wd=[0-9a-zA-Z_.%-]{0,}").ToString();
    string datr = Regex.Match(lines, "datr=[a-zA-Z0-]{0,}").ToString();
    string sub = Regex.Match(lines, "sb=[0-9a-zA-Z_.%-]{0,}").ToString();
    string fr = Regex.Match(lines, "fr=[0-9a-zA-Z_.%-]{0,}").ToString();
    string xs = Regex.Match(lines, "xs=[0-9a-zA-Z_.%-]{0,}").ToString();
    string cookieget;
    cookieget = c_user + ";" + datr + ";" + sub + ";" + fr + ";" + xs + ";" + wd;
    return cookieget;
}