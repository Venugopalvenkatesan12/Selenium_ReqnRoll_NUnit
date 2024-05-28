Feature: Women Section

Background:
   Given I browse Application URL
	Then Verify website logo

@sanitytest
Scenario: Verify categories in Women section
	When I Click on Women tab 
	Then Verify Category title 'WOMEN'
	And Verify '2' categories displayed for Women section