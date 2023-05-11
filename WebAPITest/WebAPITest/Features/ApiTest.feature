Feature: Test DropBox API

Scenario: Upload, GetMetaData and Delete
    Given I connect to dropbox.api
    When I try to add file
    When I check its metadata
    When I delete file

