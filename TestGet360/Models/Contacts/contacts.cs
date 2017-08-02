using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TestGet360.Models.Contacts
{
    public class PostContacts
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("dayOfCycle")]
        public string dayOfCycle { get; set; }

        [JsonProperty("campaign")]
        public Postcampaign campaign { get; set; }
        //public string ipAddress { get; set; }
    }

    public class Postcampaign
    {
         [JsonProperty("campaignId")]
        public string campaignId { get; set; }
    }

    public class GetContacts
    {
        [JsonProperty("contacts")]
        public GetContact[] contacts { get; set; }
    }
    public class GetContact
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("createdOn")]
        public string createdOn { get; set; }

        [JsonProperty("changedOn")]
        public string changedOn { get; set; }

        [JsonProperty("href")]
        public string href { get; set; }

        [JsonProperty("campaign")]
        public GetCampaign campaign { get; set; }
    }

    public class GetCampaign
    {
        [JsonProperty("campaignId")]
        public string campaignId { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("href")]
        public string href { get; set; }
    }
}