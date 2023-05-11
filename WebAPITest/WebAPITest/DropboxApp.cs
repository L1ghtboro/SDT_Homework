using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebAPITest
{
    internal class DropboxApp{
        private readonly DropboxClient _client;

        public DropboxApp(DropboxClient client){
            _client = client;
        }

        public async Task<Metadata> UploadDropboxFile(string path, string content){
            // Arrange area
            var mode = WriteMode.Overwrite.Instance;

            // Main body
            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);
            streamWriter.Write(content);
            streamWriter.Flush();
            memoryStream.Position = 0;
            var result = await _client.Files.UploadAsync(path, mode, body: memoryStream);

            return result;
        }

        public async Task<Metadata> GetFileMetadata(string path){
            // Arrange Area

            // Main Body
            var metadata = await _client.Files.GetMetadataAsync(path);

            return metadata;
        }

        public async Task<bool> DeleteDropboxFile(string path){
            // Arrange Area
            // Main Body
            var checkResult = await _client.Files.GetMetadataAsync(path);
            if (checkResult.IsDeleted){
                Assert.Inconclusive("File does not exist or is not a file.");
                return false;
            }

            var result = _client.Files.DeleteV2Async(path);

            //Need before checking because server ping
            await Task.Delay(200);

            try{
                var metadata = await _client.Files.GetMetadataAsync(path);
                // file or folder exists
                return false;
            }
            catch (ApiException<GetMetadataError> ex)
            {
                // file or folder does not exist

                if (ex.ErrorResponse.IsPath && ex.ErrorResponse.AsPath.Value.IsNotFound){
                    return true;
                }
                else{
                    // handle other error cases
                    throw;
                }
            }
        }
    }
}
