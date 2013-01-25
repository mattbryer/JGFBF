using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Twitterizer;
using System.Configuration;

namespace JGFBFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class JGFBFTwitter : IJGFBFTwitter
    {
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string TestContract()
        {
            OAuthTokens tokens = new OAuthTokens();
            AppSettingsReader reader = new AppSettingsReader();
            tokens.ConsumerKey = ConfigurationManager.AppSettings.Get("ConsumerKey");
            tokens.ConsumerSecret = ConfigurationManager.AppSettings.Get("ConsumerSecret");
            tokens.AccessToken = ConfigurationManager.AppSettings.Get("AccessToken");
            tokens.AccessTokenSecret = ConfigurationManager.AppSettings.Get("AccessTokenSecret");


            
            TwitterResponse<TwitterUser> userResponse = TwitterUser.Show(tokens, "Diamondroad");
            return userResponse.Content;
        }
    }
}
