Feature: OrderAPITests
	Generate Quotes and Place Orders

Background:
	Given the Catalog contains these products
		| id                               | designId                 | title                                                | price |
		| gildan-ultra-cotton-tank         | 611f187c903c816db29fb1c2 | Harriet Tubman $20 Bill - Red and White (on Black)   | 20.00 |
		| next-level-ladies-racerback-tank | 611f18e9067e22268ff24416 | Harriet Tubman $20 Bill - Purple and Gold (on White) | 20.00 |
		| gildan-ultra-cotton-tank         | 611f18e3067e22268ff24415 | Harriet Tubman $20 Bill - Blue and Gold (on White)   | 20.00 |
		| gildan-ultra-ladies-t-shirt      | 611f18eff411f86da544c887 | Harriet Tubman $20 Bill - Red and White (on White)   | 20.00 |
		| gildan-ultra-cotton-t-shirt      | 611f18bd55d0fd020258813a | Harriet Tubman $20 Bill - Brown and Gold (on Black)  | 20.00 |
		| gildan-ultra-cotton-tank         | 611f18ccb23a172fe8f86bab | Blackfacts Heroes - Blue and White (on Black)        | 20.00 |
	And swag products are available in these sizes
		| size    |
		| sml     |
		| med     |
		| lrg     |
		| xlg     |
		| xxl     |
		| xxxl    |
		| xxxxl   |
	And swag products are available in these colors
		| color |
		| black |
		| white |
	And the address book contains these addresses
		| name                | address1                  | city        | state | zip   | country |
		| Richard E Witt      | 3325 Half and Half Drive  | Corcoran    | CA    | 93212 | US      |
		| Gary R Mendoza      | 2840 Harley Vincent Drive | Mesopotamia | OH    | 44439 | US      |
		| William M Duvall    | 154 Pretty View Lane      | Sebastopol  | CA    | 95472 | US      |
		| Justin R Reeser     | 4407 Brooke Street        | Houston     | TX    | 77002 | US      |
		| Brenda F Hart       | 1683 Christie Way         | Lexington   | MA    | 02173 | US      |
	And custom label from address is
		| name           | address1    | city   | state | zip   | country |
		| Blackfacts.com | 60 State St | Boston | MA    | 02210 | US      |

@standardquoteorder
Scenario: Generate Order from Standard Quote With Single Product
	Given 1 swag products are selected
	And the swag quantity ordered is 1 each
	And 1 swag sizes are selected
	And 1 swag colors are selected
	And 1 swag addresses are selected
	When a Standard Quote is generated with this swag data
	Then the result should contain a new Order Token
	And when the Order Token is used to place an Order
	Then and Order Id should be returned

@bulkquoteorder
Scenario: Generate Order from Bulk Quote With Multiple Products To Same Address
	Given 5 swag products are selected
	And the swag quantity ordered is 2 each
	And 5 swag sizes are selected
	And 2 swag colors are selected
	And 1 swag addresses are selected
	When a Bulk Quote is generated with this swag data
	Then the result should contain a new Order Token
	And when the Order Token is used to place an Order
	Then and Order Id should be returned

