using System;

namespace WebAPITest{
    public class DropboxConfig{
        private const string AccessToken = "sl.BePNrjknd1uA8jMxwE2jEm0av9GNPxOUYqqMPpr0YOMKijMplr7NsWQ91RaaUqVteuAZS0Gkoc93Ar-SBTeXLdkfsLTT8DCIoxHG5GyADons_eTwDgXRFF-V-At4ySqF4kLr7KeoOzfs";
        private readonly DropboxClient _client;

        public DropboxConfig(){
            _client = new DropboxClient(AccessToken);
        }

        public DropboxClient getClient(){ return _client; }

    }
}
