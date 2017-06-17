@rozetka
Feature: RozetkaTests
	In order to buy goods on Rozetka
	As a customer
	I want to find goods and add them to cart


Background:
	 Given Rozetka page is opened	 

# declarative one
# the one with scenario outline
@search
Scenario Outline: Buy different goods on Rozetka
	Given '<searchExpression>' goods are found
	When I add first good into basket
	Then I can see choosen goods in basket
Examples: 
	| searchExpression |
	| iPad             |
	| гамак            |

# imperative one
# the one with table
@filter
Scenario: Buy Asus laptop on Rozetka
	When I open catalog menu
		And I choose Ноутбуки и компьютеры category
		And I click Asus laptops
		And I filter by processor
			| searchExpression |
			| Intel Core i7    |
			| Intel Core i5    |
		And I add first good into basket
	Then I can see choosen goods in basket
