using APIFramework_01.Models.TestOutputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework_01.TestData.TestOutputData
{
    public static class BuildFreeUserOutputData
    {
        public static PlaylistsModel BuildGetFreeUserTest()
        {
            return new PlaylistsModel
            {
                playlists = new List<PlaylistsItemsModel>
                {
                    new PlaylistsItemsModel
                    {
                        id = "4ac7507f-9a99-4b3b-941d-a51c6dd6198e",
                        name = "Featured",
                        content = new List<UsersContentModel>
                        {
                            new UsersContentModel
                            {
                                id = "40463e78-e17f-457a-b5b9-c94aeb2a29db",
                                name = "The Shawshank Redemption"
                            },
                            new UsersContentModel
                            {
                                id = "77ed0926-04fa-44c4-bb94-d2b8f52a12f3",
                                name = "The Godfather"
                            }
                        },

                    },
                    new PlaylistsItemsModel
                    {
                        id = "7ba52fa7-e04d-4457-829f-cb99323ca5b4",
                        name = "Most watched",
                        content = new List<UsersContentModel>
                        {
                            new UsersContentModel
                            {
                                id = "439000c8-5b3d-41cc-bf6b-76c3ee157218",
                                name = "The Dark Knight"
                            },
                            new UsersContentModel
                            {
                                id = "51fe8a24-d806-44ad-98e3-634639205bfb",
                                name = "The Lord of the Rings: The Return of the King"
                            }
                        }

                    }
                   
                }
            };
        }
      
        
    }
}
