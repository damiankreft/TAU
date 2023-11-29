from selenium import webdriver
from selenium.webdriver.firefox.options import Options as FOpt
from selenium.webdriver.edge.options import Options as EOpt
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.by import By
from time import sleep
from components import components
import logging as l

# Disable logging to prevent leaking software versions and paths
for logger in [l.getLogger(name) for name in l.root.manager.loggerDict]:
    logger.setLevel(l.WARNING)
l.basicConfig(format='%(asctime)s[%(levelname)s] %(funcName)s: %(message)s', datefmt='%d/%m/%Y %I:%M:%S %p ', filename="results/scenario2.log", level=l.DEBUG, encoding='utf-8', filemode="w")

TIME_PAGE_LOAD = 3
TIME_COOKIES_TO_LOGIN_FORM = 1
EMAIL_VALUE = 'Adres e-mail'
PASSWORD_VALUE = 'Hasło'

edgeOptions = webdriver.EdgeOptions()
edgeOptions.add_experimental_option('excludeSwitches', ['enable-logging'])
for driver in [webdriver.Edge(options=edgeOptions), webdriver.Firefox(options=FOpt())]:

    l.info("testing started")
    driver.get(components.SUT)

    l.debug("Waiting for the website to load: %d" % TIME_PAGE_LOAD)
    sleep(TIME_PAGE_LOAD)

    accept_cookies_button = driver.find_element(by=By.XPATH, value=components.PATH_COOKIES_BUTTON)
    accept_cookies_button.click()

    sleep(TIME_COOKIES_TO_LOGIN_FORM)
    name_textbox_input =  driver.find_element(by=By.XPATH, value=components.PATH_LOGIN_INPUT)
    password_textbox_input = driver.find_element(by=By.XPATH, value=components.PATH_PASSWORD_INPUT)

    l.debug("Sending invalid credentials.")
    name_textbox_input.send_keys("invalidemail123")
    password_textbox_input.send_keys("invalidpassword345")
    l.debug("Sending login")
    login_button = driver.find_element(by=By.XPATH, value=components.PATH_LOGIN_BUTTON)
    login_button.click()
    sleep(2)
    error_message = driver.find_element(by=By.XPATH, value=components.PATH_ERROR_SPAN)
    color = error_message.value_of_css_property("color")

    assert "rgb(230, 0, 0)" or "rgb(230, 0, 0, 1)" in color 
    l.info("TEST 0: Error message is visible and has proper color.")
    driver.quit()

    l.info("All tests passed")

l.info("All iterations have been finished successfully.")


