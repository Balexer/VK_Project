using System.Collections.Generic;

namespace VKProject.Models.Responses.Likes;

public class ResponseBody
{
    public int Count { get; set; }
    public List<int> Items { get; set; }
}
