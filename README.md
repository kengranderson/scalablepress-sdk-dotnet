# scalablepress-sdk-dotnet: a C# Software Development Kit for the ScalablePress REST API

This is a C# Software Development Kit that I built for myself to use the ScalablePress  REST APIs to power the BlackFacts.com Swag page 
at [https://blackfacts.com/swag](https://blackfacts.com/swag).

## About this SDK

I wrote it here and there over a couple of years in order to be able to use the ScalablePress API to generate custom products on demand, 
as well as place orders for them that can be delivered directly to customers. 

While I am primarily a C# developer, the principles in most languages would be the same, and obviously the ScalablePress API is the api, 
so if you are skilled in another programming language, this should be pretty straightforward to port for your own use.

## TDD Unit Tests

Also, I have some TDD Unit Tests (using SpecFlow) included for almost all (maybe all?) of the ScalablePress APIs.  

## Dependencies and Building the Project

The Unit tests do have dependencies on products in the BlackFacts Catalog database, as well as a few of my proprietary NuGet packages 
which I store in a private repository, so you will not be able to build this directly out of the box without contacting me at 
[ken@blackfacts.com](mailto:ken@blackfacts.com).  

I'm quite happy to share the NuGet packages if you want to build or port this for your own purposes, but will continue to maintain my packages 
in my private NuGet package library. 

## Considerations and Usage

Consider this SDK as a Proof-Of-Concept / MVP / Starting Point for you to use the ScalablePress API in your own projects.

## Note on Open Source

As writing software is how I have put food on my table since 1991, I do not default to publishing much of anything on Github and giving it away for free. 
However, if you know of a Whole Foods that will give me free food for flashing my Microsoft MVP medallion, I'll be happy to start 
giving away more of my codebase of over 140 private Git repos. Just let a brother know!

And if you have a problem with that, feel free to write your own SDK - good luck! 

## Thank You!
