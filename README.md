# SDT_Homework WebAPI
### This code repository contains three classes: DropboxApp, DropboxTests, and DropboxConfig.

## DropboxConfig
The DropboxConfig class has a single method that returns an instance of the DropboxClient class initialized with an access token.

## DropboxApp
The DropboxApp class has three methods that perform upload, get metadata, and delete operations on files in Dropbox. The UploadDropboxFile method takes a file path and file content, writes the content to a MemoryStream, and uploads it to Dropbox using the DropboxClient.Files.UploadAsync method. The GetFileMetadata method takes a file path and returns the metadata of the file located at the path, using the DropboxClient.Files.GetMetadataAsync method. The DeleteDropboxFile method takes a file path, checks whether the file exists, and deletes it using the DropboxClient.Files.DeleteV2Async method.

## DropboxTests
The DropboxTests class contains three methods annotated with the Given and When attributes. The SetUp method initializes an instance of the DropboxConfig class and sets a file path. The TestDropboxUpload method creates an instance of the DropboxApp class and uploads a file to Dropbox. The TestDropboxGetFileMetadata method creates an instance of the DropboxApp class and gets the metadata of the previously uploaded file. The TestDropboxDelete method creates an instance of the DropboxApp class and deletes the previously uploaded file.

## How to use
Clone this repository and open it in Visual Studio. Build the solution and run the tests in the DropboxTests class to verify that the code works as intended.

## Result 
![This is an alt text.](/image/result.jpg "This is a result.")