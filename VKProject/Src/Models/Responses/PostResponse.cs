namespace VKProject.Models;

public class PostResponse
{
    public int post_id { get; set; }
}

public class PostRoot
{
    public PostResponse response { get; set; }
}
