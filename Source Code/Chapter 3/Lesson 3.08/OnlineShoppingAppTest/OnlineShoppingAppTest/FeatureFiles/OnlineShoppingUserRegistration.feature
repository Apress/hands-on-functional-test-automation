Feature: OnlineShoppingUserRegistration
	In order to do online transactions
	As an unregisterd user of the web site
	I want to register to website

@mytag
Scenario: Register new user
	Given user is at home page
	And navigate to registration page
	When user enter valid email password and confirm password
	And click on the Signin button
	Then user navigate to user account
	When user logout from the user account
	Then myaccount link should not be displayed

