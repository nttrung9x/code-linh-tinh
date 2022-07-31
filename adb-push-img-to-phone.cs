public void PushFile(string param, string NameOrId, string path)
        {
            ExecuteMu(string.Format("-{0} {1} adb \"push \\\"{2}\\\" /sdcard/Pictures/\"", param, NameOrId, path));
            ExecuteMu(string.Format("-{0} {1} adb \"shell am broadcast -a android.intent.action.BOOT_COMPLETED -n com.android.providers.media/.MediaScannerReceiver\"", param, NameOrId));
            ExecuteMu(string.Format("-{0} {1} adb \"shell am broadcast -a android.intent.action.MEDIA_SCANNER_SCAN_FILE -d file:///mnt/sdcard/Pictures/\"", param, NameOrId));
            ExecuteMu(string.Format("-{0} {1} adb \"shell am broadcast -a android.intent.action.MEDIA_MOUNTED -d file:///sdcard/Pictures\"", param, NameOrId));
        }
        public void ClearFile(string param, string NameOrId, string filename)
        {
            ExecuteMu(string.Format("-{0} {1} adb \"shell rm /sdcard/Pictures/{2}\"", param, NameOrId, filename));
            ExecuteMu(string.Format("-{0} {1} adb \"shell am broadcast -a android.intent.action.BOOT_COMPLETED -n com.android.providers.media/.MediaScannerReceiver\"", param, NameOrId));
            ExecuteMu(string.Format("-{0} {1} adb \"shell am broadcast -a android.intent.action.MEDIA_SCANNER_SCAN_FILE -d file:///mnt/sdcard/Pictures/\"", param, NameOrId));
            ExecuteMu(string.Format("-{0} {1} adb \"shell am broadcast -a android.intent.action.MEDIA_MOUNTED -d file:///sdcard/Pictures\"", param, NameOrId));
        }
