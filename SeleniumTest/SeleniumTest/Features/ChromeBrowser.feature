Feature: Login to OrangeHRM

Scenario: Add and delete a job title
    Given I am on the login page
    When I enter the username and password
    Then I should be logged in
    When I press admin panel
    Then Admin panel should pop up
    When I search for accordion
    Then I open Job titles
    When I enter job title page
    Then I should see add Job
    When I click add I can add job
    Then I would like to add the job
    When I add Job I have to delete it
