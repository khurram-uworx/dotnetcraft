namespace UWorx.WorkplaceIQ;

public class SocialMediaPost : BaseContent
{
    private static class Helper
    {
        public static void DoSomething()
        { }

        public static void DoSomething2()
        { }

        public static void DoSomething3()
        { }
    }


    public static SocialMediaPost GetInstance(string platform, string text)
    {
        SocialMediaPost p = new SocialMediaPost();
        p.UpdateName(platform);
        p.UpdateDescription(text);
        return p;
    }

    private SocialMediaPost()
    { }

    public SocialMediaPost UpdateLabels(string[] labels)
    {
        base.UpdateTags(labels);
        return this;
    }

    public void StoreIntoDb()
    { }
}
