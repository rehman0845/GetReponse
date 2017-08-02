using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TestGet360.Models.Contacts;
using Newtonsoft.Json;
using TestGet360.Models;
using Newtonsoft.Json.Linq;

namespace TestGet360.Models.Icontacts
{
    public class GRContact : IGRContact
    {
        private HttpClient http;

        public GRContact()
        {
            http = new HttpClient();
        }

        public async Task<bool> CheckContact(string email)
        {
            var LC = JsonConvert.DeserializeObject<GetContacts>(await GetContacts());
            var ct = LC.contacts.Where(c => c.email == email).FirstOrDefault();
            if (ct != null)
                return false;
            return true;
        }
        public async Task<string> PostContact(PostContacts ct)
        {
            try
            {
                http.DefaultRequestHeaders.Clear();
                http.DefaultRequestHeaders.Add("X-Auth-Token", "api-key acb762adfeaace7c33f36af70b47cdc1");
                ct.dayOfCycle = "10";
                ct.campaign = new Postcampaign() { campaignId = "Txu09" };
                var stringPayload =JsonConvert.SerializeObject(ct);

                // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                // Do the actual request and await the response
                var httpResponse = await http.PostAsync("https://api.getresponse.com/v3/contacts", httpContent);

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Created || httpResponse.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    return httpResponse.ReasonPhrase;
                }
                // If the response contains content we want to read it!
                if (httpResponse.Content != null)
                {
                    var responseContent =/* await */ httpResponse.Content.ReadAsStringAsync().Result;
                    return responseContent;
                    // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "";
        }

        public async Task<string> GetContacts()
        {
            try
            {
                http.DefaultRequestHeaders.Clear();
                http.DefaultRequestHeaders.Add("X-Auth-Token", "api-key acb762adfeaace7c33f36af70b47cdc1");

                // Do the actual request and await the response
                var httpResponse = await  http.GetAsync("https://api.getresponse.com/v3/contacts");
               
                if (httpResponse.Content != null)
                {
                    var responseContent =/* await */ httpResponse.Content.ReadAsStringAsync().Result;
                    responseContent = "{\n \"contacts\":" + responseContent + "\n}";
                    //return JsonConvert.DeserializeObject<List<GetContact>>(responseContent);
                    return responseContent;
                }
            }
            catch (Exception e)
            {
                
            }
            return "";
        }
    }

    #region test
     //public string PostContact(PostContacts ct)
     //   {
     //       try
     //       {
     //           http = new HttpClient();
     //           http.DefaultRequestHeaders.Clear();
     //           http.DefaultRequestHeaders.Add("X-Auth-Token", "api-key acb762adfeaace7c33f36af70b47cdc1");
     //           //http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
     //           ct.dayOfCycle = "10";
     //           ct.campaign = new Postcampaign() { campaignId = "Txu09" };
     //           var stringPayload =/* await Task.Run(() =>*/ JsonConvert.SerializeObject(ct);

     //           // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
     //           var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

     //           //using (var httpClient = new HttpClient())
     //           //{
     //           //    httpClient.DefaultRequestHeaders.Clear();
     //           //    httpClient.DefaultRequestHeaders.Add("X-Auth-Token", "api-key acb762adfeaace7c33f36af70b47cdc1");
     //           // Do the actual request and await the response
     //           var httpResponse = /*await */ http.PostAsync("https://api.getresponse.com/v3/contacts", httpContent).Result;

     //           if (httpResponse.StatusCode == System.Net.HttpStatusCode.Created || httpResponse.StatusCode == System.Net.HttpStatusCode.Accepted)
     //           {
     //               return httpResponse.ReasonPhrase;
     //           }
     //           // If the response contains content we want to read it!
     //           if (httpResponse.Content != null)
     //           {
     //               var responseContent =/* await */ httpResponse.Content.ReadAsStringAsync().Result;
     //               return responseContent;
     //               // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
     //           }
     //           //}
     //           //var content = new StringContent(stct, Encoding.UTF8, "application/json");
     //           //content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

     //           //var response = http.PostAsync("https://api.getresponse.com/v3/contacts", content).Result;
     //           //return response.StatusCode.ToString();

     //       }
     //       catch (Exception e)
     //       {
     //           return e.Message;
     //       }
     //       return "";
     //   }
        #endregion
}