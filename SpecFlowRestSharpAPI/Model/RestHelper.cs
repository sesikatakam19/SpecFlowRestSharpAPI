using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;



namespace SpecFlowRestSharpAPI.Model
{
    public class RestHelper
    {
        private RestClient client = null;
        private RestRequest request = null;
        public string content = null;
        private Locations location;
          

        public RestClient SetEndPoint(string endpoint)
        {
            
            try
            {
                client = new RestClient(endpoint);
                return client;
            }
            catch(Exception ex)
            {
              throw new Exception(ex.Message);
            }
            
        }

        public string SetRequest(string req)
        {
            request = new RestRequest(req, Method.GET);
            IRestResponse response = client.Execute(request);
            content = response.Content;
            return JsonConvert.SerializeObject(content.Replace(@"\", @"\\"));
        }
       
        public bool SearchforCityandCountry(string c, string cou)
        {
            var networkInfo = DeserialiseObject();
            try
           
            
            {
               location = networkInfo.networks.ToList().Find(x => String.Equals(x.location.city, c, StringComparison.CurrentCultureIgnoreCase) && String.Equals(x.location.country, cou, StringComparison.CurrentCultureIgnoreCase)).location;
               return true;
            }
            catch(Exception)
            {
                return false;
            }
          
        }
       
       public Networkinfo DeserialiseObject()
        {
            return JsonConvert.DeserializeObject<Networkinfo>(content);
        }
        
        public Locations GetLatandLong()
        {
            return location;
        }
    }
}