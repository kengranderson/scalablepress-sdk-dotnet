Feature: MockupAPITests
	In order to test the Mockup API
	we call these methods

@create
Scenario: Create a Mockup
	Given a design is created from a random image in the images folder
	When the Mockup API is called
	Then the result should be a Url