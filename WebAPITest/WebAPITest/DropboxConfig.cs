using System;



namespace WebAPITest
{
    public class DropboxConfig{ //got some troubles using env variables so sry
        private string AccessToken = "sl.BePjnNr4m0wTztP1l98vCcx01hF-C09ZPfv77U-rar_o4rW1fBd1NvGGixBZ8rY5P31VB1iNc4zz0DAFZ997xGwZ8wlMEQag-JyZSJnpm0y7QlFzazw_9SyCnQ2X_ZMB-s4zUSmXX7zy";
        private readonly DropboxClient _client;

        public DropboxConfig(){
            _client = new DropboxClient(AccessToken);
        }

        public DropboxClient getClient(){ return _client; }

    }
}
