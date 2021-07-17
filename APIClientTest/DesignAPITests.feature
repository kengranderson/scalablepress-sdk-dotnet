Feature: DesignAPITests
	In order to test the Design API
	we call these methods

@create
Scenario: Create Design
	Given the table of data
 | name                              | type | sides_front_dimensions_width | sides_front_position_horizontal | sides_front_position_offset_top | sides_front_artwork | sides_front_proof |
 | Black Facts Matter - AKA Founders | dtg  | 11                           | C                               | 2.5                             |C:\\Users\\Ken\\Dropbox\\Projects\\BlackFacts\\blackfactsmatter\\blackfacts-minute-video-cover.png | C:\\Users\\Ken\\Dropbox\\Projects\\BlackFacts\\blackfactsmatter\\black-facts-matter-shirt-aka-founders-proof.png |
	When I call the Design Create API
	Then the result should be a new Design Id

@create-to-order
Scenario: Create Design, Get Quote, Place Order
Given design is created from a random image in the images folder
And a Quote is generated from the Design Id
When an Order is placed
Then we should have an Order Id

