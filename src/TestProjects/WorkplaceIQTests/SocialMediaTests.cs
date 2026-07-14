using UWorx.WorkplaceIQ;

namespace WorkplaceIQTests;

public class SocialMediaTests
{
    [Test]
    public void Test1()
    {
        SocialMediaPost p = SocialMediaPost.GetInstance(
            platform: "linkedin",
            text: "I am learning OOP");
        //p.UpdateName("Facebook");
            //.UpdateLabels(["label1", "label2"]); // is optional
        
        p.StoreIntoDb();

        Assert.Pass();
    }
}
