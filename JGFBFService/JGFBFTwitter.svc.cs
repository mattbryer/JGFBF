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
    public class JGFBFTwitter : IJGFBFTwitter
    {
        public OAuthTokens GetOAuthTokens()
        {
            OAuthTokens tokens = new OAuthTokens();
            tokens.ConsumerKey = ConfigurationManager.AppSettings.Get("ConsumerKey");
            tokens.ConsumerSecret = ConfigurationManager.AppSettings.Get("ConsumerSecret");
            tokens.AccessToken = ConfigurationManager.AppSettings.Get("AccessToken");
            tokens.AccessTokenSecret = ConfigurationManager.AppSettings.Get("AccessTokenSecret");
            
            return tokens;
        }

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string TestContract()
        {
            OAuthTokens tokens = GetOAuthTokens();

            TwitterResponse<TwitterUser> userResponse = TwitterUser.Show(tokens, "Diamondroad");
            return userResponse.Content;
        }
    }
}
