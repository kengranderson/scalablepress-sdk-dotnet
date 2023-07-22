Feature: DesignAPITests
	In order to test the Design API
	we call these methods

@create
Scenario: Create Design
	Given the table of data
	| name                              | type |front_artwork | front_dimensions_height | front_dimensions_width | front_position_horizontal | front_position_offset_bottom | front_position_offset_front | back_artwork | back_dimensions_height | back_dimensions_width | back_position_horizontal | back_position_offset_bottom | back_position_offset_top | left_artwork                 | left_dimensions_height          | left_dimensions_width           | left_position_horizontal                                                                           | left_position_offset_bottom                                                                                      | left_position_offset_top | right_artwork | right_dimensions_height | right_dimensions_width | right_position_horizontal | right_position_offset_bottom | right_position_offset_top | 

	When I call the Design Create API
	Then the result should be a new Design Id

@create-to-order
Scenario: Create Design, Get Quote, Place Order
	Given design is created from a random image in the images folder
	And a Quote is generated from the Design Id
	When an Order is placed
	Then we should have an Order Id

@pull-designs
Scenario Outline: Pull Designs from ScalablePress
Given a ScalablePress Design with Id "<designId>"
When I retrieve the Design corresponding to the Id
Then a DesignTemplate record will be created if necessary, and the data from ScalablePress will be written to the DesignTemplate record

Examples: 
| designId                 |
| 649e4d95162dcd09050e6142 |
| 649e4c6a8c04d642f9c2a2b1 |
| 649cc0cd15d4964279f2af5e |
| 649a563f1cae4274a66f267e |
| 6493b92f5d15831bf83aaf1d |
| 6493a9e04237095d485e13a2 |
| 6473c45c1c0a1b6f01be7113 |
| 6473c451352230775ac9f7bd |
| 63fa3a25083a60397d6db29d |
| 63f03e21f1b7c639979647c0 |
| 63ab961a1039c4465ebc85ea |
| 63ab92d0b6fa0077469f5b81 |
| 63ab924ef09d447668ee5103 |
| 639bd6b132248e223d7a3eff |
| 6306ab01403284422b1959ef |
| 6306a84cfc24776e9f4d9a5b |
| 6306a186403284422b1957c4 |
| 63068ae3cb5676790b1507d5 |
| 61ff32a210583347a0137d97 |
| 61ea7bf5626a773f8fd1a0b0 |
| 61ea7bf3452baa69c2b86619 |
| 61ea7bf091bc461b46c30a2e |
| 61ea7bef66681b726e38114c |
| 61ea7beddc391206b64caa52 |
| 61ea7beb452baa69c2b86618 |
| 61ea7be928a70337dcc3e9a3 |
| 61ea7be859107869cf0353b8 |
| 61ea7be68f40f71b392d0602 |
| 61ea7be4626a773f8fd1a0af |
| 61ea7be228a70337dcc3e9a2 |
| 61ea7be0452baa69c2b86617 |
| 61ea7bde626a773f8fd1a0ae |
| 61ea7bdb8f40f71b392d0601 |
| 61ea7bd931d76c69ce6c345c |
| 61ea7bca28a70337dcc3e9a1 |
| 61df2e2325b43e45469baf2b |
| 613d02838e3c2946aee47484 |
| 61380d7b2c9c320597720d14 |
| 61380be2b5416a46ba5a56eb |
| 61380b8842eeb546b4918e5b |
| 61380b1e8e3c2946aee3013a |
| 6137fa1242eeb546b49189d3 |
| 6123212e4bcc0c4fb37c45b9 |
| 6123212b3282717de7a53347 |
| 61228be41e971c4fa1768198 |
| 611f191146cbf22c39671391 |
| 611f190e067e22268ff2441c |
| 611f190b819f294fad237ae0 |
| 611f190897a3362c2f5f2243 |
| 611f1906731e042a41bfe5e1 |
| 611f1903819f294fad237ade |
| 611f1900903c816db29fb1e6 |
| 611f18fe2f2dfc02091fb225 |
| 611f18fb1e971c4fa175baac |
| 611f18f897a3362c2f5f223d |
| 611f18f52f2dfc02091fb224 |
| 611f18f31e971c4fa175baab |
| 611f18eff411f86da544c887 |
| 611f18e9067e22268ff24416 |
| 611f18e63282717de7a4406e |
| 611f18e3067e22268ff24415 |
| 611f18def411f86da544c886 |
| 611f18db1e971c4fa175baaa |
| 611f18d52f2dfc02091fb223 |
| 611f18d2819f294fad237adb |
| 611f18cf2f2dfc02091fb222 |
| 611f18ccb23a172fe8f86bab |
| 611f18c91e971c4fa175baa9 |
| 611f18c62f27820215ca30f1 |
| 611f18c3b23a172fe8f86baa |
| 611f18c04bcc0c4fb37b5354 |
| 611f18bd55d0fd020258813a |
| 611f18b9903c816db29fb1cd |
| 611f18b62f2dfc02091fb221 |
| 611f18b1731e042a41bfe5c7 |
| 611f1880731e042a41bfe5c3 |
| 611f187c903c816db29fb1c2 |
| 6123414bb23a172fe8f96e01 |
| 612342cd1e971c4fa176ba93 |
| 61df2b3e5cb10b5a3e3f8928 |
