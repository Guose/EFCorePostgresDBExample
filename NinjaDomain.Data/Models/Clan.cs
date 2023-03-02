using LinqToDB.Mapping;
using NinjaDomain.Data.Interfaces;

namespace NinjaDomain.Data.Models
{
    [Table("Clans")]
    public class Clan : IModificationHistory
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Column, NotNull]
        public string ClanName { get; set; }

        [Column]
        public DateTimeOffset DateModified { get; set; }

        [Column, NotNull]
        public DateTimeOffset DateCreated { get; set; }

        [Column, NotNull]
        public bool IsDirty { get; set; }

        public List<Ninja> Ninjas { get; set; }

        public Clan()
        {
            ClanName = string.Empty;
            Ninjas = new List<Ninja>();
            DateModified = DateTimeOffset.UtcNow;
        }
    }
}
