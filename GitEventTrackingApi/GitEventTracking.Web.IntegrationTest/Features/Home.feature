Feature: Home
	Simple calculator for adding two numbers

@Home
Scenario: ID_01_TestHomePage_Loading
	Given I am on Home page
	Then I see 'Add Git Event'

Scenario: ID_02_TestCreateGitEvent
	Given I am on Home page
	When I enter '123' into the 'eventId' field
	And I enter '123' into the 'actorId' field
	And I enter 'actor123Login' into the 'actorLogin' field
	And I enter 'actor123LoginAvatarUrl' into the 'avatarUrl' field
	And I enter '123' into the 'repoId' field
	And I enter 'repo123Name' into the 'repoName' field
	And I enter 'repo123Link' into the 'repoLink' field
	And I click the 'Submit' button
	Then I see 'Event added successfully!!!'

Scenario: ID_03_TestFindActorWithMaxStreak
	Given I am on Home page
	When I click the 'Find' button
	Then I see 'actor123Login'

Scenario: ID_04_TestExceptionForDuplicateGitEventCreation
	Given I am on Home page
	When I enter '123' into the 'eventId' field
	And I enter '123' into the 'actorId' field
	And I enter 'actor123Login' into the 'actorLogin' field
	And I enter 'actor123LoginAvatarUrl' into the 'avatarUrl' field
	And I enter '123' into the 'repoId' field
	And I enter 'repo123Name' into the 'repoName' field
	And I enter 'repo123Link' into the 'repoLink' field
	And I click the 'Submit' button
	Then I see 'Bad Request'