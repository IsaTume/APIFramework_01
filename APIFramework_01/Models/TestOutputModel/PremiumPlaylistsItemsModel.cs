using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework_01.Models.TestOutputModel
{
    public class PremiumPlaylistsItemsModel
    {
        public string id {  get; set; }
        public string name { get; set; }
        public List<UsersContentModel> content { get; set; }
    }
}
