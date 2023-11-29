from selenium import webdriver
from selenium.webdriver.firefox.options import Options as FOpt
from selenium.webdriver.edge.options import Options as EOpt
from selenium.webdriver.common.by import By
from time import sleep
import logging as l
from components import components as comp

# Disable logging to prevent leaking software versions and paths
for logger in [l.getLogger(name) for name in l.root.manager.loggerDict]:
    logger.setLevel(l.WARNING)
l.basicConfig(format='%(asctime)s[%(levelname)s] %(funcName)s: %(message)s', datefmt='%d/%m/%Y %I:%M:%S %p ', filename="results/scenario1.log", level=l.DEBUG, encoding='utf-8', filemode="w")

TIME_PAGE_LOAD = 3
TIME_COOKIES_TO_LOGIN_FORM = 1
EMAIL_VALUE = 'Adres e-mail'
PASSWORD_VALUE = 'Hasło'

edgeOptions = EOpt()
edgeOptions.add_experimental_option("excludeSwitches", ["enable-logging"])
for driver in [webdriver.Edge(options=edgeOptions), webdriver.Firefox(options=FOpt())]:

    l.info("testing started")
    driver.get(comp.SUT)

    l.debug("Waiting for the website to load: %d" % TIME_PAGE_LOAD)
    sleep(TIME_PAGE_LOAD)

    accept_cookies_button = driver.find_element(by=By.XPATH, value=comp.PATH_COOKIES_BUTTON)
    accept_cookies_button.click()

    sleep(TIME_COOKIES_TO_LOGIN_FORM)
    name_textbox_label =  driver.find_element(by=By.XPATH, value=comp.PATH_LOGIN_LABEL)
    assert EMAIL_VALUE in name_textbox_label.text
    l.info("TEST 0: Email label value test passed")

    password_textbox_label = driver.find_element(by=By.XPATH, value=comp.PATH_PASSWORD_LABEL)
    assert PASSWORD_VALUE in password_textbox_label.text
    l.info("TEST 1: Password label value test passed")
    driver.quit()

    l.info("All tests passed")

l.info("All iterations have been finished successfully.")

