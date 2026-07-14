namespace UWorx.WorkplaceIQ;

public abstract class BaseContent
{
    string contentName;
    string contentDescription;
    List<string> contentTags;

    protected BaseContent UpdateName(string name)
    {
        this.contentName = name;
        return this;
    }

    protected BaseContent UpdateDescription(string description)
    {
        this.contentDescription = description;
        return this;
    }

    public BaseContent UpdateTags(string[] tags)
    {
        this.contentTags.AddRange(tags);
        return this;
    }
}
