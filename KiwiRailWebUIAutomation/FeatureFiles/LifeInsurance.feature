Feature: Life Insurance

Background:
	Given I navigate to the TAL Website
	Then I verify that I am on TAL Website Main Page

Scenario: Searching for a Life Insurance Product
	Then I click on "Insurance Products" at the top
	Then I click on "Life Insurance" at the top
	Then I click on "Get a quote" at the top
	Then User add birthdate "12/07/1993"
	Then User add details 'Get a quote' page
       | Question                                 | Answer                                                              | Field_Type	|
       | Your Gender                              | Female                                                              | CheckBox		 |
       | Do you Smoke?                            | No                                                                  | CheckBox		|
       | Occupation                               | Computer - Analyst / Consultant / Programmer - University qualified | Dropdownfill   |
       | Annual Income (Excluding Superannuation) | 130000                                                              | TextInput		|
	Then User click on "Continue" button
	Then User add details 'Get a quote 2' page
       | Question   | Answer                                                              | Field_Type |
       | First Name | Dishali					                                          | TextInput  |
       | Last Name  | Khilari                                                             | TextInput  |
       | Phone      | 413065691													      | PhoneNumber  |
       | Email      | dishali.khilari12@gmail.com                                         | TextInput  |
       | Postcode   | 2061                                                                | TextInput  |
	Then User click on "CALCULATE MY QUOTE" big button
	Then User click on "Add" big button
	Then User add details 'Life Insurance' page
       | Question   | Answer                                                              | Field_Type |
       | Cover Amount  | 130000					                                          | TextInput  |
	Then User click on "Confirm" big button
