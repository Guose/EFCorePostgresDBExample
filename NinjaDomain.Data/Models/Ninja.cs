using LinqToDB.Mapping;
using NinjaDomain.Data.Interfaces;

namespace NinjaDomain.Data.Models
{
    [Table("Ninjas")]
    public class Ninja : IModificationHistory
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public DateTimeOffset DateOfBirth { get; set; }

        [Column, NotNull]
        public bool ServedInOniwaban { get; set; }

        [Column]
        public DateTimeOffset DateModified { get; set; }

        [Column, NotNull]
        public DateTimeOffset DateCreated { get; set; }

        [Column, NotNull]
        public bool IsDirty { get; set; }

        [Column, NotNull]
        public int ClanId { get; set; }

        [Association(ThisKey = nameof(ClanId), OtherKey = nameof(Ninja.Clan.Id))]
        public Clan Clan { get; set; }

        public List<NinjaEquipment> EquipmentOwned { get; set; }

        public Ninja()
        {
            Name = string.Empty;
            Clan = new Clan();
            DateCreated = DateTimeOffset.UtcNow;
            EquipmentOwned = new List<NinjaEquipment>();
        }
    }
}
