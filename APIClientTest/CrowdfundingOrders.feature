Feature: CrowdfundingOrders

Place Crowdfunding Supporter Orders

@generatequote
Scenario: Generate Quote for Crowdfunding Supporter Orders
	Given We are in "test" Mode
	And the Crowdfunding Supporter Data is Loaded
	When We Generate a Bulk Quote
	Then the Quote Should be Generated

@placeorder
Scenario: Place Crowdfunding Supporter Orders
	Given We are in "test" Mode
	And We Generate a Crowdfunding Supporter Order Quote 
	When We Place the Order
	Then The Order Should be Placed
