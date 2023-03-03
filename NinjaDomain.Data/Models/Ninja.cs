using LinqToDB.Mapping;
using NinjaDomain.Data.Interfaces;

namespace NinjaDomain.Data.Models
{
    [Table("Ninjas")]
    public class Ninja : BaseModel
    {
        [Column]
        public string Name { get; set; }

        [Column]
        public DateTimeOffset DateOfBirth { get; set; }

        [Column, NotNull]
        public bool ServedInOniwaban { get; set; }

        [Column, NotNull]
        public int ClanId { get; set; }

        [Association(ThisKey = nameof(ClanId), OtherKey = nameof(Ninja.Clan.Id))]
        public virtual Clan Clan { get; set; }

        public virtual ICollection<NinjaEquipment> EquipmentOwned { get; set; }

        public Ninja()
        {
            Clan = new Clan();
            Name = string.Empty;
            EquipmentOwned = new HashSet<NinjaEquipment>();
        }
    }
}
