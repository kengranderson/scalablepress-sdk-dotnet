Feature: Product API Tests
	In order to confirm that the ScalablePress API Client is working,
	As a developer
	I want to exercise the Product APIs.

@categories
Scenario: Get Category List
	Given I have instantiated an API Client with a valid API key
	When I call the Product Categories API
	Then the result should be a list of Categories

@category
Scenario: Get Products in Category
	Given I have instantiated an API Client with a valid API key
	When I call the Product Category API for Category Id "sweatshirts"
	Then the result should be a list of Products

@product
Scenario: Get Product Info
	Given I have instantiated an API Client with a valid API key
	When I call the Product Info API for Product Id "gildan-sweatshirt-crew"
	Then the result should be a Product Info object

@productavailability
Scenario: Get Product Availability
	Given I have instantiated an API Client with a valid API key
	When I call the Product Availability API for Product Id "gildan-sweatshirt-crew"
	Then the result should be a Product Avalability object

@productdetails
Scenario: Get Product Details
	Given I have instantiated an API Client with a valid API key
	When I call the Product Details API for Product Id "gildan-sweatshirt-crew"
	Then the result should be a Product Details object
