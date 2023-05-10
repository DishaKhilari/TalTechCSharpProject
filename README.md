# KiwiRailWebUIAutomation

i) This is a web ui automation framework coded using Specflow BDD and C#.netcore.
ii) It is based on page object model pattern. Where each page represents a page on the https://www.kiwirail.co.nz/

Folder Structure and Pattern details:
1) Feature Files: This folder contain the feature file that has the test scenarios to be tested in Gherkin language format.
2) Step Definitions: This folder contains the step definition file that has all the test steps from the Gherkin matched to underlying
                     page object functionality.
                     
3) Page Objects : It contains abstract BasePage.cs that has common methods that will be used across the project.
                  It contains MainPage.cs that contains locators for different elements on the page and methods used 
                  to test different functionality on the page.
                  
4) Support : It contains TestConfiguration.cs , this is used to read the value from the appsettings.json file that contains
             different internal project values as url for kiwirail website and browseroptions to be provided to hooks.cs.
             It contains Hooks.cs , this file is brain behind the framework as this is where driver is registered before test run 
             and disposed after test run . Browser selection and intialization is done with different options.
 

# Execution Details:

To execute above tests:
i) Download and install VS 2019 and open the solution file : KiwiRailWebUIAutomation.sln. 
ii) Build the project.
iii) If you don't see the TestExplorer , Goto Test --> TestExplorer . Run the tests from there.

Note: Tests will run in headless mode by default as in the appsettings.json , headless = true , set it to false to run in GUI mode.

# Release Pipeline:
i) Test Project build and publish pipeline : 
Below pipeline builds the testing project and publishes artifacts for release pipeline to run.

https://dev.azure.com/kapoormanil/KiwiRailWebUiAutomation/_build?definitionId=6&_a=summary

ii) Release Pipeline for the project that runs the actual test: It consists of the Automation Run Stage.

https://dev.azure.com/kapoormanil/KiwiRailWebUiAutomation/_release?_a=releases&view=mine&definitionId=1

Example: A successful run : https://dev.azure.com/kapoormanil/KiwiRailWebUiAutomation/_releaseProgress?_a=release-environment-logs&releaseId=4&environmentId=4

Note : Under Tests you will find the test results.
