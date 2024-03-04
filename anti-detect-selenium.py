from selenium import webdriver
from pathlib import Path
import time
def ChromeDriver():
    options = webdriver.ChromeOptions()
    options.add_argument('--no-first-run')
    options.add_argument('--no-service-autorun')
    options.add_argument('--password-store-basic')
    options.add_argument('--no-service-autorun')
    options.add_argument('--lang=en-US')
    options.add_argument('--disable-gpu')
    options.add_argument('--disable-cpu')
    options.add_argument("--disable-webgl")
    options.add_argument("--disable-canvas")
    options.add_argument("--disable-audio-api")
    options.add_argument("--disable-client-rects")
    prefs = {
        "credentials_enable_service": False,
        "profile.password_manager_enabled": False,
        "profile.default_content_setting_values.notifications": 2,
        "download_restrictions": 3
    }
    options.add_experimental_option("prefs", prefs)
    options.add_experimental_option('useAutomationExtension', False)
    options.add_argument('--enable-main-frame-before-activation')
    options.add_argument('--display-capture-permissions-policy-allowed')
    options.add_argument('--device-scale-factor=1')
    options.add_argument('--disable-web-security')
    options.add_argument('--allow-running-insecure-content')
    options.add_argument('--disable-popup-blocking')
    options.add_argument('--ignore-certificate-errors')
    options.add_argument('--disable-plugins-discovery')
    options.add_argument('--disable-gpu-shader-disk-cache')
    options.add_argument('--disable-blink-features=AutomationControlled')
    options.add_argument('--profile-directory=Default')
    driver = webdriver.Chrome(options=options)
    return driver
driver = ChromeDriver()
driver.get("https://www.google.com.vn/?hl=vi")
time.sleep(10000)
