from selenium.webdriver import Chrome
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.common.by import By
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.support.wait import WebDriverWait as WebWait
from selenium.webdriver.support import expected_conditions as EC

from time import sleep

def setupDriver(driver_path=r'driver\chromedriver.exe'):
    options = Options()
    options.add_experimental_option("excludeSwitches", ["enable-automation"])
    options.add_experimental_option('useAutomationExtension', False)
    options.add_argument("--disable-blink-features=AutomationControlled")
    options.add_argument('--disable-extensions')
    options.add_argument('--no-sandbox')
    options.add_argument('--disable-infobars')
    options.add_argument('--disable-dev-shm-usage')
    options.add_argument('--disable-browser-side-navigation')
    options.add_argument('--disable-gpu')
    driver = Chrome(service=Service(driver_path),options=options)
    return driver

def open_link_js(driver,link):
    driver.execute_script(f"window.open('{link}', '_blank')")
    

if __name__ == '__main__':
    url_cloudfare = 'https://nowsecure.nl'
    
    driver = setupDriver()
    open_link_js(driver,url_cloudfare)
    sleep(10)
    driver.switch_to.window(driver.window_handles[1])
    WebWait(driver,10).until(EC.frame_to_be_available_and_switch_to_it((By.XPATH,'//iframe[contains(@src,"https://challenges.cloudflare.com")]')))
    WebWait(driver,10).until(EC.presence_of_element_located((By.XPATH,'//*[@type="checkbox"]'))).click()
    
    input("Enter to close !")
    driver.quit()