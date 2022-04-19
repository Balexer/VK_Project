using System.Collections.Generic;

namespace VKProject.Models.Responses.Like;

public class ResponseBody
{
    public int Count { get; set; }
    public List<LikedUsers> Users { get; set; }
}
