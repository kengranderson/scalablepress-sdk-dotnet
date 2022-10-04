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

@placeorderbatch
Scenario: Place Crowdfunding Supporter Orders in a Batch
	Given We are in "live" Mode
	And We Define Batch Orders to Target 10 Dollars
	And We Generate a Crowdfunding Supporter Batch Order Quote 
	When We Place the Batch Order
	Then The Batch of Orders Should be Placed
