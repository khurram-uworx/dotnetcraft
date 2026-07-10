using UWorx.WorkplaceIQ;

namespace WorkplaceIQTests
{
    public class SocialMediaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            SocialMediaPost p = SocialMediaPost.GetInstance(
                platform: "linkedin",
                text: "I am learning OOP");
                //.UpdateLabels(["label1", "label2"]); // is optional
            
            p.StoreIntoDb();

            Assert.Pass();
        }
    }
}
