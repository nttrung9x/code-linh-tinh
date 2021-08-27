            public void change_hma()
            {
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/C netsh interface set interface \"HMA! Pro VPN\" disable";
                        startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
            }




