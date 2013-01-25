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
    public class GamePick
    {
        public GamePick(string player_name, string user)
        {
            this.PlayerName = player_name;
            this.User = user;
        }
        public String PlayerName;
        public String User;
    }
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
        public List<GamePick> TestContract()
        {
            OAuthTokens tokens = GetOAuthTokens();

            List<GamePick> response = new List<GamePick>();

            TwitterResponse<TwitterStatusCollection> userResponse = TwitterTimeline.Mentions(tokens);
            foreach (TwitterStatus status in userResponse.ResponseObject)
            {
                if (IsStatusFromGameDay(status.CreatedDate))
                {
                    response.Add(new GamePick("test_player", status.User.Name));
                }
            }
            return response;
        }

        private bool IsStatusFromGameDay(DateTime status_date)
        {
            DateTime game_day = GetNextGameDay();
            return game_day.DayOfYear == status_date.DayOfYear;
        }

        private DateTime GetNextGameDay()
        {
            // TODO get the actual game day
            return DateTime.Today;
        }

    }
}
