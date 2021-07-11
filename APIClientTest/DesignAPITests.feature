Feature: DesignAPITests
	In order to test the Design API
	we call these methods

@create
Scenario: Create Design
	Given the table of data
 | name                              | type | sides_front_dimensions_width | sides_front_position_horizontal | sides_front_position_offset_top | sides_front_artwork | sides_front_proof |
 | Black Facts Matter - AKA Founders | dtg  | 11                           | C                               | 2.5                             |C:\Users\Ken\Dropbox\Projects\BlackFacts\blackfactsmatter\aka\bfm-design-aka-founders.png | C:\Users\Ken\Dropbox\Projects\BlackFacts\blackfactsmatter\aka\bfm-design-aka-founders-proof.png |
	When I call the Design Create API
	Then the result should be a new Design Id
