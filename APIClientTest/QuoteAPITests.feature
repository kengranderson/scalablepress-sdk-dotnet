Feature: QuoteAPITests
	Test the ScalablePress Quote API

Background:
	Given the Swag Catalog contains these products
		| id                               | designId                 | title                                                | price |
		| gildan-ultra-cotton-tank         | 611f187c903c816db29fb1c2 | Harriet Tubman $20 Bill - Red and White (on Black)   | 20.00 |
		| next-level-ladies-racerback-tank | 611f18e9067e22268ff24416 | Harriet Tubman $20 Bill - Purple and Gold (on White) | 20.00 |
		| gildan-ultra-cotton-tank         | 611f18e3067e22268ff24415 | Harriet Tubman $20 Bill - Blue and Gold (on White)   | 20.00 |
		| gildan-ultra-ladies-t-shirt      | 611f18eff411f86da544c887 | Harriet Tubman $20 Bill - Red and White (on White)   | 20.00 |
		| gildan-ultra-cotton-t-shirt      | 611f18bd55d0fd020258813a | Harriet Tubman $20 Bill - Brown and Gold (on Black)  | 20.00 |
		| gildan-ultra-cotton-tank         | 611f18ccb23a172fe8f86bab | Blackfacts Heroes - Blue and White (on Black)        | 20.00 |
		| next-level-ladies-racerback-tank | 611f18cf2f2dfc02091fb222 | Blackfacts Heroes - Purple and Gold (on Black)       | 20.00 |
		| gildan-ultra-cotton-t-shirt      | 611f1880731e042a41bfe5c3 | Harriet Tubman $20 Bill - White and Black (on Black) | 20.00 |
		| gildan-ultra-cotton-tank         | 611f191146cbf22c39671391 | Blackfacts Heroes - Pink and Green (on White)        | 20.00 |
		| gildan-ultra-cotton-t-shirt      | 611f18fe2f2dfc02091fb225 | Blackfacts Heroes - Blue and Gold (on White)         | 20.00 |
		| gildan-ultra-ladies-t-shirt      | 611f18e9067e22268ff24416 | Harriet Tubman $20 Bill - Purple and Gold (on White) | 20.00 |
		| next-level-ladies-racerback-tank | 611f1900903c816db29fb1e6 | Blackfacts Heroes - Blue and White (on White)        | 20.00 |
		| next-level-ladies-racerback-tank | 611f190e067e22268ff2441c | Blackfacts Heroes - Black and Gold (on White)        | 20.00 |
		| next-level-ladies-racerback-tank | 611f18c04bcc0c4fb37b5354 | Harriet Tubman $20 Bill - Black and Gold (on Black)  | 20.00 |
		| gildan-ultra-cotton-t-shirt      | 611f1903819f294fad237ade | Blackfacts Heroes - Purple and Gold (on White)       | 20.00 |
		| gildan-ultra-ladies-t-shirt      | 611f18b9903c816db29fb1cd | Harriet Tubman $20 Bill - Purple and Gold (on Black) | 20.00 |
		| gildan-ultra-cotton-t-shirt      | 611f18c04bcc0c4fb37b5354 | Harriet Tubman $20 Bill - Black and Gold (on Black)  | 20.00 |
		| next-level-ladies-racerback-tank | 611f1903819f294fad237ade | Blackfacts Heroes - Purple and Gold (on White)       | 20.00 |
		| gildan-ultra-cotton-tank         | 611f18f897a3362c2f5f223d | Harriet Tubman $20 Bill - Black and Gold (on White)  | 20.00 |
		| gildan-ultra-cotton-tank         | 611f18c04bcc0c4fb37b5354 | Harriet Tubman $20 Bill - Black and Gold (on Black)  | 20.00 |
	And invalid products are listed here
		| id                       | designId                 | title              | price |
		| gildan-ultra-cotton-jank | 611f187c903c816db29fb1c2 | Invalid Product Id | 20.00 |
	And products are available in these sizes
		| size    |
		| sml     |
		| med     |
		| lrg     |
		| xlg     |
		| xxl     |
		| xxxl    |
		| xxxxl   |
		| xxxxxl  |
		| xxxxxxl |
	And invalid product sizes are listed here
		| size |
		| bad  |
	And products are available in these colors
		| color |
		| black |
		| white |
	And invalid product colors are listed here
		| color     |
		| invisible |
	And our address book contains these addresses
		| name                | address1                  | city        | state | zip   | country |
		| Richard E Witt      | 3325 Half and Half Drive  | Corcoran    | CA    | 93212 | US      |
		| Gary R Mendoza      | 2840 Harley Vincent Drive | Mesopotamia | OH    | 44439 | US      |
		| William M Duvall    | 154 Pretty View Lane      | Sebastopol  | CA    | 95472 | US      |
		| Justin R Reeser     | 4407 Brooke Street        | Houston     | TX    | 77002 | US      |
		| Brenda F Hart       | 1683 Christie Way         | Lexington   | MA    | 02173 | US      |
		| Eric L Mitchell     | 2570 Summit Street        | Davenport   | IA    | 52806 | US      |
		| Joe T Dawkins       | 149 Goldcliff Circle      | Washington  | DC    | 20016 | US      |
		| Billie F Buffington | 1885 Virginia Street      | Chicago     | IL    | 60653 | US      |
		| Lisa W Boss         | 1891 New Street           | Madras      | OR    | 97741 | US      |
		| Howard S Davis      | 821 Langtown Road         | Toledo      | OH    | 43609 | US      |
	And the custom label from address is
		| name           | address1    | city   | state | zip   | country |
		| Blackfacts.com | 60 State St | Boston | MA    | 02210 | US      |
	And the invalid address book contains these addresses
		| name     | address1       | city    | state | zip   | country |
		| John Doe | 123 Any Street | Anytown | MA    | 00000 | US      |

@standardquote
Scenario: Generate Standard Quote With Single Product
	Given the first 1 products are selected
	And the quantity ordered is 1 each
	And the first 1 sizes are selected
	And the first 1 colors are selected
	And the first 1 addresses are selected
	When a Standard Quote is generated with this data
	Then the result should contain an Order Token

@bulkquote1
Scenario: Generate Bulk Quote With Multiple Products To Same Address
	Given the first 5 products are selected
	And the quantity ordered is 2 each
	And the first 5 sizes are selected
	And the first 2 colors are selected
	And the first 1 addresses are selected
	When a Bulk Quote is generated with this data
	Then the result should contain an Order Token

@bulkquote2
Scenario: Generate Bulk Quote With Multiple Products To Different Addresses
	Given the first 5 products are selected
	And the quantity ordered is 2 each
	And the first 5 sizes are selected
	And the first 2 colors are selected
	And the first 5 addresses are selected
	When a Bulk Quote is generated with this data
	Then the result should contain an Order Token

@bulkquote3
Scenario: Generate Bulk Quote With Multiple Products To Different Addresses And Custom Labels
	Given the first 5 products are selected
	And the quantity ordered is 2 each
	And the first 5 sizes are selected
	And the first 2 colors are selected
	And the first 1 addresses are selected
	And the first 1 custom addresses is selected
	When a Bulk Quote is generated with this data
	Then the result should contain an Order Token

@quoteerror1
Scenario: Generate Quote Error From Invalid Product
	Given the first 1 invalid products get selected
	And the quantity ordered is 1 each
	And the first 1 sizes are selected
	And the first 1 colors are selected
	And the first 1 addresses are selected
	When a Standard Quote is generated with this data
	Then the result should contain an Error Response

@quoteerror2
Scenario: Generate Quote Error From Invalid Product Color
	Given the first 1 products are selected
	And the quantity ordered is 1 each
	And the first 1 sizes are selected
	And the first 1 invalid colors are selected
	And the first 1 addresses are selected
	When a Standard Quote is generated with this data
	Then the result should contain an Error Response

@quoteerror3
Scenario: Generate Quote Error From Invalid Product Size
	Given the first 1 products are selected
	And the quantity ordered is 1 each
	And the first 1 invalid sizes are selected
	And the first 1 colors are selected
	And the first 1 addresses are selected
	When a Standard Quote is generated with this data
	Then the result should contain an Error Response

@quoteerror4
Scenario: Generate Quote Error From Invalid Product Quantity
	Given the first 1 products are selected
	And the quantity ordered is -1 each
	And the first 1 sizes are selected
	And the first 1 colors are selected
	And the first 1 addresses are selected
	When a Standard Quote is generated with this data
	Then the result should contain an Error Response

@quoteerror5
Scenario: Generate Quote Error From Invalid Address
	Given the first 1 products are selected
	And the quantity ordered is 1 each
	And the first 1 sizes are selected
	And the first 1 colors are selected
	And the first 1 invalid addresses are selected
	When a Standard Quote is generated with this data
	Then the result should contain an Error Response

