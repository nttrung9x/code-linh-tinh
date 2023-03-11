public static void BackupFacebook(string DeviceID, string FileName, string uid)
{ // https://www.facebook.com/hkvn9x
    try
    {
        string path = " pull /data/data/com.facebook.katana/app_light_prefs/com.facebook.katana/";
        string[] list = { "account_manager", "analytics_periodic_events", "authentication", "default_phone_id", "fb4a_dm", "logged_in_", "overtheair_prefs", "PrevDownload", "pw_enc_key", "underlying_account","user_storage_device_key","dbl_local_auth_","auth_backup"};
        for (int i = 0; i < list.Length; i++)
        {
            if (!list[i].Contains("logged_in") && !list[i].Contains("dbl_local_auth_"))
            {
                ExecuteADB(" -s " + DeviceID + " " + path + list[i] + " " + FileName + "\\" + uid + "\\app_light_prefs\\com.facebook.katana\\" + list[i]);
            }
            else
            {
                ExecuteADB(" -s " + DeviceID + " " + path + list[i] + uid + " " + FileName + "\\" + uid + "\\app_light_prefs\\com.facebook.katana\\" + list[i] + uid);
            }
        }
        string path2 = " pull /data/data/com.facebook.katana/shared_prefs";
        ExecuteADB(" -s " + DeviceID + " " + path2 + " " + FileName + "\\" + uid + "\\shared_prefs");
        Thread.Sleep(7000);
        if (File.Exists(FileName + "\\" + uid + ".kd"))
        {
            File.Delete(FileName + "\\" + uid + ".kd");
        }
        ZipFile.CreateFromDirectory(FileName + "\\" + uid, FileName + "\\" + uid + ".kd");
    }catch (Exception ex){      
        Console.WriteLine(ex.ToString());
    }
}

// code new update reels - 12-03-2023

public static void BackupFacebook(string DeviceID, string FileName, string uid)
{ // https://www.facebook.com/hkvn9x
    try
    {
        string path = " pull /data/data/com.facebook.katana/app_light_prefs/com.facebook.katana/";
        string[] list = { "account_manager", "analytics_periodic_events", "authentication", "default_phone_id", "fb4a_dm", "logged_in_", "overtheair_prefs", "PrevDownload", "pw_enc_key", "underlying_account",
    "user_storage_device_key","dbl_local_auth_","auth_backup"};
        for (int i = 0; i < list.Length; i++)
        {
            if (!list[i].Contains("logged_in") && !list[i].Contains("dbl_local_auth_"))
            {
                ExecuteADB(" -s " + DeviceID + " " + path + list[i] + " " + FileName + "\\" + uid + "\\app_light_prefs\\com.facebook.katana\\" + list[i]);
            }
            else
            {
                ExecuteADB(" -s " + DeviceID + " " + path + list[i] + uid + " " + FileName + "\\" + uid + "\\app_light_prefs\\com.facebook.katana\\" + list[i] + uid);
            }
        }
        string path2 = " pull /data/data/com.facebook.katana/shared_prefs";
        ExecuteADB(" -s " + DeviceID + " " + path2 + " " + FileName + "\\" + uid + "\\shared_prefs");
        Thread.Sleep(7000);
        if (File.Exists(FileName + "\\" + uid + ".kd"))
        {
            File.Delete(FileName + "\\" + uid + ".kd");
        }
        ZipFile.CreateFromDirectory(FileName + "\\" + uid, FileName + "\\" + uid + ".kd");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}


public static void RestoreFacebook(string DeviceID, string FileName, string uid)
{ // https://www.facebook.com/hkvn9x
    ExecuteADB($"-s {DeviceID} push {FileName}\\{uid}\\app_light_prefs /data/data/com.facebook.katana/app_light_prefs");
    ExecuteADB($" -s {DeviceID} push {FileName}\\{uid}\\app_light_prefs /data/data/com.facebook.katana/ashared_prefs");
}

