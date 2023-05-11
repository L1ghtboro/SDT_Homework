using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPITest{
    [Binding]
    internal class DropboxTests{
        private DropboxConfig _dropboxConfig;
        private string path;

        [Given(@"I connect to dropbox.api")]
        public void SetUp(){
            _dropboxConfig = new DropboxConfig();
            path = "/HomeWork/test.txt";
        }

        [When(@"I try to add file")]
        public async Task TestDropboxUpload(){
            var client = _dropboxConfig.getClient();
            var uploadTest = new DropboxApp(client);

            var result = await uploadTest.UploadDropboxFile(path, "Hello World!");

            // Asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(path, result.PathDisplay);
        }

        [When(@"I check its metadata")]
        public async Task TestDropboxGetFileMetadata(){
            var client = _dropboxConfig.getClient();
            var getFileMetadataTest = new DropboxApp(client);

            var metadata = await getFileMetadataTest.GetFileMetadata(path);

            // Assert
            Assert.IsNotNull(metadata);
            Assert.IsInstanceOf<FileMetadata>(metadata);
            Assert.AreEqual(path, metadata.PathDisplay);
        }

        [When(@"I delete file")]
        public async Task TestDropboxDelete(){

            var client = _dropboxConfig.getClient();
            var deleteTest = new DropboxApp(client);

            var result = await deleteTest.DeleteDropboxFile(path);

            // Asserts
            Assert.IsTrue(result);
        }

    }
}
