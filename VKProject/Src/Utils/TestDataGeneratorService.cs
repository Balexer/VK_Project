using Bogus;
using VKProject.Models;

namespace VKProject.Utils;

public class TestDataGeneratorService
{
    public static Post GetFakePost() =>
        new Faker<Post>()
            .RuleFor(x => x.Text, f => f.Lorem.Paragraph());

    public static Comment GetFakeComment() =>
        new Faker<Comment>()
            .RuleFor(x => x.Text, f => f.Lorem.Paragraph());
}
