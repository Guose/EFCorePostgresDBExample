namespace NinjaDomain.WebApi.Interfaces
{
    public interface IModificationHistory
    {
        int Id { get; set; }
        DateTimeOffset DateModified { get; set; }
        DateTimeOffset DateCreated { get; set; }
        bool IsDirty { get; set; }
    }
}