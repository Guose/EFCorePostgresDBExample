using LinqToDB.Mapping;
using NinjaDomain.Data.Interfaces;

namespace NinjaDomain.Data.Models
{
    public class BaseModel : IModificationHistory
    {
        public BaseModel()
        {
            DateModified = DateTimeOffset.UtcNow;
        }
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