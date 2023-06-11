Feature: EPAM Website
  As a user
  I want to explore EPAM website
  So that I can learn about their services

  Scenario: Navigate to EPAM homepage
    Given I am on the EPAM homepage
    When I check the page title
    Then I should see "EPAM | Software Engineering & Product Development Services  " in the title

  Scenario: Navigate to Careers page
    Given I am on the EPAM homepage
    When I click on the "Careers" link
    Then I should be redirected to the Careers page

  Scenario: Search for job openings
    Given I am on the Careers page
    When I enter "Software Engineer Warsaw" in the search field
    And I click the search button
    Then I should see a list of job openings related to "Software Engineer"

  Scenario: Contact EPAM for partnership
    Given I am on the EPAM homepage
    When I click on the "Contact Us" link
    And I fill in the contact form with valid information
    And I submit the form
    Then I should see a success message confirming my partnership inquiry

  Scenario: View EPAM blog
    Given I am on the EPAM homepage
    When I click on the "Blog" link
    Then I should be redirected to the EPAM blog page

  Scenario: Change language preference
    Given I am on the EPAM homepage
    When I select "??(???)" as the language preference
    Then the page should be translated to ??(???)

  Scenario: View EPAM social media profiles
    Given I am on the EPAM homepage
    When I see footer, I click on the social media icons
    Then I should be redirected to EPAM's respective social media profiles