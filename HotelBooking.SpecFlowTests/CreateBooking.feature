Feature: CreateBooking
	In order to book a room
	As a user
	I want to enter a start and end date in an unoccupied period

@mytag
Scenario: Create a booking (Case 1)
	Given I have specified the start date to be in 1 day
	And I have specified the end date to be in 9 days
	When the dates have been entered
	Then the result should return true

Scenario: Create a booking (Case 2)
	Given I have specified the start date to be in 21 day
	And I have specified the end date to be in 30 days
	When the dates have been entered
	Then the result should return true

Scenario: Create a booking (Case 3)
	Given I have specified the start date to be in 9 day
	And I have specified the end date to be in 21 days
	When the dates have been entered
	Then the result should return false

Scenario: Create a booking (Case 4)
	Given I have specified the start date to be in 9 day
	And I have specified the end date to be in 10 days
	When the dates have been entered
	Then the result should return false

Scenario: Create a booking (Case 5)
	Given I have specified the start date to be in 9 day
	And I have specified the end date to be in 20 days
	When the dates have been entered
	Then the result should return false

Scenario: Create a booking (Case 6)
	Given I have specified the start date to be in 20 day
	And I have specified the end date to be in 21 days
	When the dates have been entered
	Then the result should return false

Scenario: Create a booking (Case 7)
	Given I have specified the start date to be in 10 day
	And I have specified the end date to be in 21 days
	When the dates have been entered
	Then the result should return false

Scenario: Create a booking (Case 8)
	Given I have specified the start date to be in 10 day
	And I have specified the end date to be in 11 days
	When the dates have been entered
	Then the result should return false

Scenario: Create a booking (Case 9)
	Given I have specified the start date to be in 10 day
	And I have specified the end date to be in 20 days
	When the dates have been entered
	Then the result should return false

Scenario: Create a booking (Case 10)
	Given I have specified the start date to be in 19 day
	And I have specified the end date to be in 20 days
	When the dates have been entered
	Then the result should return false