namespace UWorx.WorkplaceIQ;

public class EventPost : BaseContent
{
    DateTime? start;
    DateTime? end;

    public static EventPost GetInstance(string source, string text)
    {
        EventPost e = new EventPost();
        e.UpdateName(source);
        e.UpdateDescription(text);
        return e;
    }

    private EventPost()
    { }

    public EventPost UpdateStartTime(DateTime? start)
    {
        this.start = start;
        return this;
    }

    public EventPost UpdateEndTime(DateTime? end)
    {
        this.end = end;
        return this;
    }

    public void StoreIntoDb()
    { }
}
