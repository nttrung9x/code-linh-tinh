                                    string session = "";
                                    string phone = "";
                                    string Apiphone = tb_apiotpsim.Text;
                                    int bienso = 0;
                                    do
                                    {
                                        string site = "";
                                        this.Invoke(new MethodInvoker(delegate ()
                                        { // đoạn code tương tác.
                                            site = "http://otpsim.com/";
                                        }));

                                        string getphoneotp = http.Get(site + "api/phones/request?token=" + Apiphone + "&service=5").ToString();
                                        string loihetso = Regex.Match(getphoneotp, "(message\":\")(.*?)(\")").Groups[2].Value;
                                        if (loihetso == "Kho số đang tạm hết, vui lòng liên hệ hỗ trợ")
                                        {
                                            Status(index, "Không lấy được số!");
                                            Thread.Sleep(1000);
                                            return false;
                                        }
                                        if (loihetso != "Kho số đang tạm hết, vui lòng liên hệ hỗ trợ")
                                        {
                                            phone = Regex.Match(getphoneotp, "(phone_number\":\")(.*?)(\")").Groups[2].Value;
                                            session = Regex.Match(getphoneotp, "(session\":\")(.*?)(\")").Groups[2].Value;
                                            if (phone != "" && session != "")
                                            {
                                                Status(index, $"phonenumber: {phone}");
                                                bienso = 5;
                                            }
                                        }
                                        Thread.Sleep(1000);

                                    } while (bienso <= 2);
