Feature: HomePage validation

@smoketest
Scenario: Verify homepage logo
	Given I browse Application URL
	Then Verify website logo

@smoketest
Scenario: Verify product search
	Given Application should be up and running
	 And I navigate to homepage
	When I enter 'chiffon' in seach box
	 And I click on search button
	Then Verify search result page displayed
	 And Verify search text 'chiffon' in results page
	 And Verify result count '2'
	 And Verify sort by dropdwon displayed
	 And Verify showing results text with count '2'
	 And Verify '2' items displayed in result page

