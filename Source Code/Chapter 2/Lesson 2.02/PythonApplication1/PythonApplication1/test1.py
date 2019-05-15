import unittest
from selenium  import webdriver
from selenium.webdriver.support.wait import WebDriverWait
from selenium.webdriver.common.by import By
from selenium.webdriver.support import expected_conditions as ExpectedCondition


class Test_test1(unittest.TestCase):
    def test_A(self):
        driver=webdriver.Chrome()
        driver.get('https://www.google.lk/')
        wait=WebDriverWait(driver,60)
        feelingButton=wait.until(ExpectedCondition.element_to_be_clickable((By.NAME,"btnI")))
        feelingButton.click()
        self.assertEqual(True,wait.until(ExpectedCondition.title_contains("Google Doodles")))
        driver.quit()

if __name__ == '__main__':
    unittest.main()