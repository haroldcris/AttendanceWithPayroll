public interface ISave
{
    bool FileSave();
    DirtyChecker DirtyStatus { get; }
}

internal interface IMDIForm
{
    string Title { get; set; }
}

public interface IDirty
{
    DirtyChecker DirtyStatus { get; set; }
}
