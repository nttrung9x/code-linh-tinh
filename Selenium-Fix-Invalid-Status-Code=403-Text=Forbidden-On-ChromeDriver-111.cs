How To Fix Invalid Status Code=403 Text=Forbidden On ChromeDriver 111 Using Selenium
Cách fix lỗi WARNING: Invalid Status code=403 text=Forbidden trên ChromeDriver 111 khi sử dụng Selenium.
Chắc là nhiều bạn đang sử dụng Selenium và cập nhật browser Chrome hay Edge lên phiên bản 111.0.xxxx.xx sẽ gặp lỗi WARNING: Invalid Status code=403 text=Forbidden và kết quả là nó chỉ mở cái browser lên rồi bắn ra câu lỗi không làm gì được nữa 😄
Cách fix lỗi trên là ngay chổ bạn khởi tạo giá trị cho driver thì bạn thêm cái thuộc tính như bên dưới vào ChromeOptions hoặc EdgeOptions
ChromeOptions options = new ChromeOptions();
options.addArguments("--remote-allow-origins=*");
driver = new ChromeDriver(options);

Nguồn: https://anhtester.com/blog/how-to-fix-invalid-status-code-403-text-forbidden-on-chromedriver-111-using-selenium-b553.html
