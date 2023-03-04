using LinqToDB.Mapping;
using NinjaDomain.WebApi.Interfaces;

namespace NinjaDomain.WebApi.Models
{
    public class BaseModel : IModificationHistory
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Column]
        public DateTimeOffset DateModified { get; set; }

        [Column, NotNull]
        public DateTimeOffset DateCreated { get; set; }

        [Column, NotNull]
        public bool IsDirty { get; set; }
    }
}