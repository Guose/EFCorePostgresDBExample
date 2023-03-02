namespace NinjaDomain.Data.Interfaces
{
    public interface IModificationHistory
    {
        DateTimeOffset DateModified { get; set; }
        DateTimeOffset DateCreated { get; set; }
        bool IsDirty { get; set; }
    }
}
