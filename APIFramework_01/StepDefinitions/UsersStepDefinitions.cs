using APIFramework_01.Helpers;
using APIFramework_01.Hooks;
using APIFramework_01.TestData.TestOutputData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Diagnostics;
using System.Text.Json.Nodes;
using TechTalk.SpecFlow;

namespace APIFramework_01.StepDefinitions
{
    [Binding]
    public class UsersStepDefinitions
    {
        [Given(@"that I have the correct url '([^']*)' and I perform the Get request")]
        public void GivenThatIHaveTheCorrectUrlAndIPerformTheGetRequest(string userTypeUrl)
        {
            string fullResourceUrl = string.Empty;

            switch(userTypeUrl)
            {
                case "Premium":
                    fullResourceUrl = string.Format("{0}{1}", CommonVariables.baseUserUrl, CommonVariables.premiumUserEndpoint);//this code will add baseurl and the request url together
                break;

                case "Free User":
                    fullResourceUrl = string.Format("{0}{1}", CommonVariables.baseUserUrl, CommonVariables.freeUserEndpoint);
                    break;

                case "Other User":
                    fullResourceUrl = string.Format("{0}{1}", CommonVariables.baseUserUrl, CommonVariables.otherUserEndpoint);
                    break;
            }
                    
            Context.HttpCallMethod(fullResourceUrl, "", Method.GET, new List<KeyValuePair<string, string>>(), "");


        }

        [Then(@"the status code should be '([^']*)'")]
        public void ThenTheStatusCodeShouldBe(string expectedStatusCode)
        {
  
            switch (expectedStatusCode)
            {
                case "OK":
                    Assert.AreEqual(expectedStatusCode, Context.StatusCode);
                    break;

                case "BadRequest":
                    Assert.AreEqual(expectedStatusCode, Context.StatusCode);
                    break;

            }
        }


        [Then(@"the actual results of the Get requests should be equal to the expected results for user type '([^']*)'")]
        public void ThenTheActualResultsOfTheGetRequestsShouldBeEqualToTheExpectedResultsForUserType(string userType)
        {
            //this method is used because when we run the request on postman the actual results come as a json format. But in the automation test we deserialize and serialize to get results as a string
            string expectedBuildResult = string.Empty;

            //first we serialize the expected result we build -breaking down to smaller bits
            switch (userType)
            {
                case "Free User Results":
                    expectedBuildResult = JsonConvert.SerializeObject(BuildFreeUserOutputData.BuildGetFreeUserTest());
                    break;
                case "Premium User Results":
                    expectedBuildResult = JsonConvert.SerializeObject(BuildPremiumUserOutputData.BuildGetRequestOutputData());
                    break;
                case "Other User Results":
                    expectedBuildResult = JsonConvert.SerializeObject(BuildUserNotFoundOutputData.BuildUserNotFoundTest());
                    break;

            }

            var deserializeActualResult = JsonConvert.DeserializeObject(Context.content);//then deserialize the content we get when the request is run
            string actualResult = JsonConvert.SerializeObject(deserializeActualResult);//we serialize the content as a string

            var deserializeExpectedResult = JsonConvert.DeserializeObject(expectedBuildResult);//then deserialize the expected result
            string expectedResult = JsonConvert.SerializeObject(deserializeExpectedResult);//serialize expected result as a string


            Assert.AreEqual(actualResult, expectedResult);//compare both actual and expected strings
        }


    }
}
