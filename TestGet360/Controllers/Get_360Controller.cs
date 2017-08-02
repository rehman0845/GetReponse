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
using TestGet360.Models.Icontacts;
namespace TestGet360.Controllers
{
    public class Get_360Controller : Controller
    {
        private readonly IGRContact _IGRContact;
        public Get_360Controller()
        {
            _IGRContact = new GRContact();
        }
        //
        // GET: /Get_360/
        public ActionResult Index()
        {
            return View();
        }


        //public async Task<ActionResult> GetContacts()
        //{
        //    var LC=JsonConvert.DeserializeObject<GetContacts>(await _IGRContact.GetContacts());
        //    return Json(LC, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public ActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateContact(PostContacts ct)
        //public ActionResult CreateContact(contacts ct)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    if(await _IGRContact.CheckContact(ct.email))
                    {
                        var msg = await _IGRContact.PostContact(ct);
                        //if (JsonConvert.DeserializeObject(msg) is EResponseContent)
                        if (msg == System.Net.HttpStatusCode.Accepted.ToString())
                        {
                            TempData["Msg"] = msg;
                            return RedirectToAction("Index");
                        }
                        TempData["Msg"] = JsonConvert.DeserializeObject<EResponseContent>(msg);
                        //TempData["Msg"] = (JObject)JsonConvert.DeserializeObject(msg).ToString();
                        //TempData["Msg"] = msg.Replace("\"", "").Replace("{","").Replace("}","");
                        //else
                        //    TempData["Msg"] = msg;
                        return RedirectToAction("CreateContact");
                    }
                    TempData["Msg"]="Contact is already present";
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return Json(e.Message, JsonRequestBehavior.AllowGet);
                }
            }

            return View(ct);
            //return Json("failure",JsonRequestBehavior.AllowGet);
        }

        //[NonAction]
        //public /*async Task<*/string/*>*/ PostContact(PostContacts ct)
        //{
        //    try
        //    {
        //        http = new HttpClient();
        //        http.DefaultRequestHeaders.Clear();
        //        http.DefaultRequestHeaders.Add("X-Auth-Token", "api-key acb762adfeaace7c33f36af70b47cdc1");
        //        //http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        ct.dayOfCycle = "10";
        //        ct.campaign = new Postcampaign() { campaignId = "Txu09" };
        //        var stringPayload =/* await Task.Run(() =>*/ JsonConvert.SerializeObject(ct);

        //        // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
        //        var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

        //        //using (var httpClient = new HttpClient())
        //        //{
        //        //    httpClient.DefaultRequestHeaders.Clear();
        //        //    httpClient.DefaultRequestHeaders.Add("X-Auth-Token", "api-key acb762adfeaace7c33f36af70b47cdc1");
        //            // Do the actual request and await the response
        //        var httpResponse = /*await */ http.PostAsync("https://api.getresponse.com/v3/contacts", httpContent).Result;

        //            if (httpResponse.StatusCode == System.Net.HttpStatusCode.Created || httpResponse.StatusCode == System.Net.HttpStatusCode.Accepted)
        //            {
        //                return httpResponse.ReasonPhrase;
        //            }
        //            // If the response contains content we want to read it!
        //            if (httpResponse.Content != null)
        //            {
        //                var responseContent =/* await */ httpResponse.Content.ReadAsStringAsync().Result;
        //                return responseContent;
        //                // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
        //            }
        //        //}
        //        //var content = new StringContent(stct, Encoding.UTF8, "application/json");
        //        //content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

        //        //var response = http.PostAsync("https://api.getresponse.com/v3/contacts", content).Result;
        //        //return response.StatusCode.ToString();

        //    }
        //    catch (Exception e)
        //    {
        //        return e.Message;
        //    }
        //    return "";
        //}
        
        //---------------4
        //private void PostContact(contacts ct)
        //{
        //    ct.dayOfCycle = "10";
        //    ct.campaign = new Postcampaign() { campaignId = "Txu09" };
        //    http = new HttpClient();
        //    http.DefaultRequestHeaders.Clear();

        //    //http.DefaultRequestHeaders.Add("X-Auth-Token", "api-key acb762adfeaace7c33f36af70b47cdc1");
        //    //http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    //Encoding encoding = new UTF8Encoding();
        //    string stct = JsonConvert.SerializeObject(ct);
        //    //byte[] data = encoding.GetBytes(stct);
        //    byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(stct);

        //    HttpContent content = new ByteArrayContent(messageBytes);
        //    content.Headers.Add("X-Auth-Token", "api-key acb762adfeaace7c33f36af70b47cdc1");
        //    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            
        //    HttpResponseMessage response = http.PostAsync("https://api.getresponse.com/v3/contacts", content).Result;

        //    content.Dispose();
        //    response.Dispose();

        //}
        
        //-----------------3
        //[NonAction]
        //public string PostContact(contacts ct)
        //{
        //    try
        //    {
        //        http = new HttpClient();
        //        http.DefaultRequestHeaders.Clear();
        //        http.DefaultRequestHeaders.Add("X-Auth-Token", "api-key acb762adfeaace7c33f36af70b47cdc1");
        //        http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        ct.dayOfCycle = "10";
        //        ct.campaign = new Postcampaign() { campaignId = "Txu09" };
        //        var stct = JsonConvert.SerializeObject(ct);
        //        byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(stct);
        //        HttpContent content = new ByteArrayContent(messageBytes);
        //        //var content = new StringContent(stct, Encoding.UTF8, "application/json");
        //        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

        //        var response = http.PostAsync("https://api.getresponse.com/v3/contacts", content).Result;
        //        return response.StatusCode.ToString();

        //    }
        //    catch (Exception e)
        //    {
        //        return e.Message;
        //    }
        //}
        
        //--------------1
        //[NonAction]
        //public async Task<string> PostContact(contacts ct)
        //{
        //    try
        //    {
        //        http = new HttpClient();
        //        http.DefaultRequestHeaders.Clear();
        //        http.DefaultRequestHeaders.Add("X-Auth-Token", "api-key acb762adfeaace7c33f36af70b47cdc1");
        //        http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        //http.DefaultRequestHeaders.Add("Content-Type", "application/json");
        //        ct.dayOfCycle = "10";
        //        ct.campaign = new Postcampaign() { campaignId = "Txu09" };
        //        var stct = JsonConvert.SerializeObject(ct);
        //        //byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(stct);
        //        //var content = new ByteArrayContent(messageBytes);
        //        var content = new StringContent(stct, Encoding.UTF8, "application/json");
        //        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

        //        var response = await http.PostAsync("https://api.getresponse.com/v3/contacts", content);
        //        //if(response.StatusCode == System.Net.HttpStatusCode.)
        //        //{
        //        //    Console.WriteLine(response);
        //        //}
        //        return response.StatusCode.ToString();

        //    }
        //    catch(Exception e)
        //    {
        //        return e.Message;
        //    }
        //}

        //-------------2
        //public async Task PostContact(contacts ct)
        //{
        //    //contacts ct1 = new contacts()
        //    //{
        //    //    name = "D Rehman",
        //    //    email = "rehman.d09@gmail.com",
        //    //    dayOfCycle = "10",
        //    //    campaign = new Postcampaign() { campaignId = "Txu09" }
        //    //};

        //    ct.dayOfCycle = "10";
        //    ct.campaign = new Postcampaign() { campaignId = "Txu09" };
        //    var stct = JsonConvert.SerializeObject(ct);

        //    using(var http = new HttpClient())
        //    {
        //        http.DefaultRequestHeaders.Clear();
        //        http.DefaultRequestHeaders.Add("X-Auth-Token", "api-key acb762adfeaace7c33f36af70b47cdc1");
        //       //http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        http.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

        //        //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "relativeAddress");
        //        using (var content = new StringContent(stct, Encoding.UTF8, "application/json"))
        //        {
        //            //var request = new HttpRequestMessage
        //            //{
        //            //    Method= HttpMethod.Post,
        //            //    Content = content
        //            //};
        //            //request.Headers.Add("X-Auth-Token", "api-key acb762adfeaace7c33f36af70b47cdc1");
        //            using (var response = await http.PostAsJsonAsync("https://api.getresponse.com/v3/contacts", content))
        //            {
        //                //Console.WriteLine(response.Headers);
        //                //Console.ReadKey(true);
        //            }
        //        }
                
        //    }
            
           
        //}

        // try
        //{
        //    client = new HttpClient();
        //    client.DefaultRequestHeaders.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        //    client.DefaultRequestHeaders.TryAddWithoutValidation("icSessionId", icSessionId);

        //    string message = JSONSerializer.Serialize(jobRequest);
        //    message = message.Insert(1, "\"@type\": \"job\",");
        //    byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
        //    var content = new ByteArrayContent(messageBytes);
        //    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

        //    var response = client.PostAsync(loggedUser.serverUrl + "/api/v2/job", content).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return response.Content.ReadAsAsync<JobResponse>().Result;
        //    }
        //    else
        //    {
        //        var result = response.Content.ReadAsStringAsync().Result;
        //        Console.WriteLine(result);
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex);
        //}
        //return null;
	}
}