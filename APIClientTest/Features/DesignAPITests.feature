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