using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using Shmapper;
using Xunit;

namespace SharePointMapper.Tests
{
    public class SharepointClientTests
    {
        private readonly string siteUrl;
        private readonly ICredentials credentials;
        public SharepointClientTests()
        {

            //TODO:GetUsername and encrypted password
            this.siteUrl = "https://mySharePointSite.sharepoint.com";
            string userName = "userName@email.com";
            var securePassword = "password".ToSecureString();
            credentials = new SharePointOnlineCredentials(userName,securePassword);
        }

        [Fact]
        public void CreateNew_SharePointClient()
        {
            var client = new SharepointClient(siteUrl,credentials);

            Assert.NotNull(client);
        }

        [Fact]
        public void CreateNew_SharePointClientEmptySiteName_ThrowNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                //create with both null and empty strings
                new SharepointClient(null, credentials);
                new SharepointClient("", credentials);
            });



        }
    }
}
