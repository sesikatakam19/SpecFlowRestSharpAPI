Feature: Get information Location information from City Bikes Endpoint
		Built using Selenium, c# and Rest Sharp
	

#@mytag <"http://api.citybik.es">
Scenario Outline: Get information from Location on providing City and Country from API
	Given the endpoint http://api.citybik.es	
	Given the result  '/v2/networks/'
	When I provide City '<city>' and CountryCode '<country>'
	Then retrieve Longitude and Latitude from Location
	Examples: 
	| city      | country   |
	| Utrecht   | NL        |
	| Frankfurt | de        |
	| paris     | FR        |
	| nocity    | nocountry |