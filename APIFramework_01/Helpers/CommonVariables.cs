using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework_01.Helpers
{
    public static class CommonVariables
    {
        //This is to read the Config.json file
        public static string appConfigFileData = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "ConfigFile.json"));

        //We desrialize the data held in the appConfigFiledata string
        static dynamic configData = JsonConvert.DeserializeObject(appConfigFileData);

        //Then the respective items in the file when needed
        public static string baseUserUrl = configData.BaseUrl;
        public static string premiumUserEndpoint = configData.PremiumUserEndpoint;
        public static string freeUserEndpoint = configData.FreeUserEndpoint;
        public static string otherUserEndpoint = configData.OtherUserEndpoint;

    }
}
