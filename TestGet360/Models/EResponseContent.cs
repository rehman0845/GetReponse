using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace TestGet360.Models
{
    public class EResponseContent
    {
        [JsonProperty("httpStatus")]
        public System.Net.HttpStatusCode httpStatus{get;set;}
        
        [JsonProperty("code")]
        public code code { get; set; }
        
        [JsonProperty("codeDescription")]
        public string codeDescription { get; set; }
        
        [JsonProperty("message")]
        public string message { get; set; }
        
        [JsonProperty("moreInfo")]
        public string moreInfo { get; set; }
        
        [JsonProperty("content")]
        public string content { get; set; }
        
        [JsonProperty("uuid")]
        public string uuid { get; set; }
    }
}

public enum code
{
    InternalError =1,
    GeneralErrorOfValidationProcess=1000,
    ResourceCannotBeFound=1001,
    Forbid = 1002,
    ParameterHasWrongFormat=1003 
}