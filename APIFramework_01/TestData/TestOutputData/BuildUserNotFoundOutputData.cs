using APIFramework_01.Models.TestOutputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework_01.TestData.TestOutputData
{
    public static class BuildUserNotFoundOutputData
    {
        public static UserNotFoundModel BuildUserNotFoundTest()
        {
            return new UserNotFoundModel
            {
                messsage = "Unknown user type"
            };
        }
    }
}
