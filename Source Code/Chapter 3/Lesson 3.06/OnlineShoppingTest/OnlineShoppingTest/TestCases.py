import unittest
from selenium import webdriver
from selenium.webdriver.support.wait import WebDriverWait
from selenium.webdriver.common.by import By
from selenium.webdriver.support import expected_conditions as ExpectedCondition
from selenium.webdriver.support.select import Select
from selenium.webdriver.common.keys import Keys


class Test_TestCases(unittest.TestCase):
    def test_A(self):
        driver=webdriver.Chrome()
        driver.maximize_window()
        driver.get('http://eshop-testweb.azurewebsites.net')
        wait=WebDriverWait(driver,30);
        self.assertEqual(True,wait.until(ExpectedCondition.title_is("Catalog - Microsoft.eShopOnWeb")))
        LoginLink=wait.until(ExpectedCondition.element_to_be_clickable((By.LINK_TEXT,"Login")))
        LoginLink.click()
        emailField=wait.until(ExpectedCondition.element_to_be_clickable((By.ID,"Email")))
        emailField.send_keys("demouser@microsoft.com")
        password=wait.until(ExpectedCondition.visibility_of_element_located((By.ID,"Password")))
        password.send_keys("Pass@word1")
        submitButton=wait.until(ExpectedCondition.element_to_be_clickable((By.CSS_SELECTOR,".btn.btn-default.btn-brand.btn-brand-big")))
        submitButton.submit()
        selectListItem=Select(driver.find_element_by_id(("BrandFilterApplied")))
        selectListItem.select_by_visible_text((".NET"))
        driver.find_element_by_css_selector((".esh-catalog-items.row > div:nth-of-type(1) > form > input")).click()
        self.assertEqual(True,wait.until(ExpectedCondition.url_to_be("http://eshop-testweb.azurewebsites.net/Basket/Index")))
        
      
        
if __name__ == '__main__':
    unittest.main()
