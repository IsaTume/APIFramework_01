using APIFramework_01.Helpers;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework_01.Hooks
{
    public static class Context
    {
        // This is the base url playlist API
        public static string baseUrl = CommonVariables.baseUserUrl;

        public static string content = string.Empty;// this will hold the content of the request response
        public static string StatusCode = string.Empty; // this will hold the response status code
        public static string responseDescription = string.Empty;// this will hold the response description


        public static void HttpCallMethod(string urlToUse, string jsonInputBody, Method method, List<KeyValuePair<string, string>> parametersList, string tokenToUse)
        {
            var client = new RestClient();
            var request = new RestRequest(urlToUse, method);//Setting the urls which will be used, and the type of call to make

            //if we use a json body
            if (!string.IsNullOrEmpty(jsonInputBody))
            {
                request.RequestFormat = DataFormat.Json;//Specifying the test input data format
                request.AddBody(jsonInputBody);//Parsing the test input file as a Json body 
            }

            //if we have parameters
            if (parametersList != null && parametersList.Any())
                foreach (var parameter in parametersList)
                    request.AddParameter(parameter.Key, parameter.Value);

            //if we have a token
            if (!string.IsNullOrEmpty(tokenToUse))
                client.Authenticator = new JwtAuthenticator(tokenToUse);


            //exeuting the call
            var result = client.Execute(request);


            //the results
            StatusCode = result.StatusCode.ToString();
            responseDescription = result.StatusDescription;
            content = result.Content;

        }
        
    }
}
