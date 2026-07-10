namespace UWorx.WorkplaceIQ
{
    public class SocialMediaPost
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

        string platform;
        string text;
        List<string> labels;

        private SocialMediaPost()
        {

        }

        private SocialMediaPost(string platform, string text, string[] labels)
        { }

        public static SocialMediaPost GetInstance(string platform, string text)
        {
            return new SocialMediaPost()
                .UpdatePlatform(platform)
                .UpdateText(text);
        }

        public SocialMediaPost UpdatePlatform(string platform)
        {
            this.platform = platform;
            return this;
        }

        public SocialMediaPost UpdateText(string text)
        {
            this.text = text;
            return this;
        }

        public SocialMediaPost UpdateLabels(string[] labels)
        {
            this.labels.AddRange(labels);
            return this;
        }

        public void StoreIntoDb()
        { }
    }
}
