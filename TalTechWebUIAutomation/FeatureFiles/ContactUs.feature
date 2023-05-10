Feature: ContactUs

Background:
	Given I navigate to the TAL Website
	Then I verify that I am on TAL Website Main Page

Scenario: Contact customer service
	Then Scroll down to the bottom of the page and click the "Contact us"
	Then User add details 'Contact us' page
       | Question   | Answer                      | Field_Type  |
       | Name       | Dishali Khilari             | TextInput   |
       | Email      | dishali.khilari12@gmail.com | TextInput    |
       | Phone      | 0413065691                   | TextInput |
       | I want to  | Make a general enquiry      | DropDown    |
       | Your query | Test Enquiry                | TextArea    |
	Then User click on "Send message" submit button