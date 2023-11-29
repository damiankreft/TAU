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
l.basicConfig(format='%(asctime)s[%(levelname)s] %(funcName)s: %(message)s', datefmt='%d/%m/%Y %I:%M:%S %p ', filename="results/scenario3.log", level=l.DEBUG, encoding='utf-8', filemode="w")

driver = webdriver.Firefox(options=FOpt())

l.info("testing started")
driver.get(comp.SUT2)
sleep(3)

fee_div = driver.find_element(by=By.XPATH, value="//div[contains(text(), 'Kierunek Informatyka - studia I stopnia - stacjonarne - 1700 zł')]")
assert "Kierunek Informatyka - studia I stopnia - stacjonarne - 1700 zł" in fee_div.text
l.info("TEST 0: Passed")
assert "Kierunek Informatyka - studia I stopnia - niestacjonarne - 1500 zł" in fee_div.text
l.info("TEST 1: Passed")
l.info("Test finished")