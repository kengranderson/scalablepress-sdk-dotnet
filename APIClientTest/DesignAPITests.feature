Feature: DesignAPITests
	In order to tes the Design API
	we call the methods

@create
Scenario: Create Design
	Given I have specified the design type as "dtg"
	And named the design "Black Facts Matter - AKA Founders"
	And specified the design image as "C:\Users\Ken.CMUCORP\Dropbox\Projects\BlackFacts\blackfactsmatter\aka\bfm-design-aka-founders.png"
	When I call the Design Create API
	Then the result should be a new Design Id
