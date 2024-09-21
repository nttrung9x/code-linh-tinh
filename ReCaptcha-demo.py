# https://captcha69.com/_extensions/chrome/all.recaptcha.v6.9.captcha69.com.zip
# Add Key Trực Tiếp Trong Path: D:\path_to\all.recaptcha.v6.9.captcha69.com\content\main.js
# Chèn Key dạng point_xxx vào Line 25 >>> var API_KEY_CAPTCHA69 = "point_xxx";

from selenium import webdriver
from selenium.webdriver.common.by import By
from time import sleep

# Khởi tạo driver với extension từ thư mục
options = webdriver.ChromeOptions()
options.add_argument("--load-extension=D:\\path_to\\all.recaptcha.v6.9.captcha69.com")  # Đường dẫn đến thư mục extension
options.add_argument("--proxy-bypass-list=captcha69.com");// bỏ qua proxy khi load trang web captcha69.com - áp dụng cho cả requests bên trong extensions

driver = webdriver.Chrome(options=options)

# Mở trang Facebook
driver.get('https://www.facebook.com')

# Loop để kiểm tra captcha có được giải thành công hay chưa
Giai_Thanh_Cong_Text = "Giải Xong - CaptCha69.Com"
while True:
    elements = driver.find_elements(By.CLASS_NAME, "ReCaptcha_solver")
    for element in elements:
        if Giai_Thanh_Cong_Text in element.text:
            print("Captcha giải thành công!")
            break
    else:
        sleep(1)
        continue
    break

# Đóng driver sau khi hoàn thành
driver.quit()
