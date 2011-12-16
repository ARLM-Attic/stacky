using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stacky
{
    /// <summary>
    /// See: http://api.stackexchange.com/docs/types/access-token
    /// </summary>
    public class AccessToken : Entity
    {
        private string token;
        [JsonProperty("access_token")]
        public string Token
        {
            get { return token; }
            set { token = value; NotifyOfPropertyChange(() => Token); }
        }

        private DateTime expiresOn;
        [JsonProperty("expires_on_date")]
        public DateTime ExpiresOn
        {
            get { return expiresOn; }
            set { expiresOn = value; NotifyOfPropertyChange(() => ExpiresOn); }
        }

        private int accountId;
        [JsonProperty("account_id")]
        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; NotifyOfPropertyChange(() => AccountId); }
        }

        private List<string> scope;
        [JsonProperty("scope")]
        public List<string> Scope
        {
            get { return scope; }
            set { scope = value; NotifyOfPropertyChange(() => Scope); }
        }
    }
}