Feature: Users

As a user, I will like to run API requests for premium users, free users and other users and get the expected output.

@regression 
Scenario Outline: Test_01 Test to ensure that a user can request premium, free and other users API
	Given that I have the correct url '<UserTypeUrl>' and I perform the Get request
	Then the status code should be '<ExpectedStatus>'
	And the actual results of the Get requests should be equal to the expected results for user type '<UserTypeExpectedResults>'  

Examples: 
	| UserTypeUrl   | ExpectedStatus | UserTypeExpectedResults |
	| Premium    | OK             | Premium User Results    |
	| Free User  | OK             | Free User Results       |
	| Other User | BadRequest     | Other User Results      |

