using System.Collections.Generic;

namespace VKProject.Models;

public class LikesResponse
{
    public int count { get; set; }
    public List<LikedUsers> users { get; set; }
}

public class LikedUsers
{
    public int uid { get; set; }
    public int copied { get; set; }
}

public class Likes
{
    public LikesResponse response { get; set; }
}
