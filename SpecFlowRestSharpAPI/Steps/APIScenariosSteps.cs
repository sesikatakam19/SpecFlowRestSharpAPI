using NUnit.Framework;
using SpecFlowRestSharpAPI.Model;
using TechTalk.SpecFlow;
using SpecFlowRestSharpAPI.Hooks;

namespace SpecFlowRestSharpAPI.Steps
{
    [Binding]
    public class APIScenariosSteps
    {
        public readonly RestHelper Rest = new RestHelper();
       
        [Given(@"the endpoint (.*)")]
        public void GivenTheEndpoint(string endpoint)  { Rest.SetEndPoint(endpoint);}

        [Given(@"the result  '(.*)'")]
        public void GivenTheResult(string res)
        {
            Rest.SetRequest(res);
            MyHooks.UpdateFile("Endpoint ping successfull");
        }
        
        [When(@"I provide City '(.*)' and CountryCode '(.*)'")]
        public void WhenIProvideCityAndCountryCode(string city, string country)
        {
            Assert.That(Rest.SearchforCityandCountry(city, country), Is.True, $"Cannot find Location for City : {city} and Country : {country}");
            //Assert.That(Rest.SearchforCityandCountry(city, country), Is.True, MyHooks.UpdateFile($"Cannot find Location for City : {city} and Country : {country}"));
            
        }

        [Then(@"retrieve Longitude and Latitude from Location")]
        public void ThenRetrieveLongitudeAndLatitudeFromLocation()
        {
            var location = Rest.GetLatandLong();
            MyHooks.UpdateFile("City: " + location.city.ToString());
            MyHooks.UpdateFile("Country Code: " + location.country.ToString());
            MyHooks.UpdateFile("Latitude: " + location.latitude.ToString());
            MyHooks.UpdateFile("Longitud: " + location.longtitude.ToString());
            
            


        }
    }
}
