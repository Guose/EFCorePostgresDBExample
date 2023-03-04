using LinqToDB.Mapping;

namespace NinjaDomain.WebApi.Models
{
    [Table("Ninjas")]
    public class NinjaModel : BaseModel
    {
        [Column]
        public int Age { get; set; }
        
        [Column]
        public string Name { get; set; }

        [Column]
        public DateTimeOffset DateOfBirth { get; set; }

        [Column, NotNull]
        public bool ServedInOniwaban { get; set; }

        [Column, NotNull]
        public int ClanId { get; set; }

        [Association(ThisKey = nameof(ClanId), OtherKey = nameof(NinjaModel.Clan.Id))]
        public virtual ClanModel Clan { get; set; }

        public virtual ICollection<NinjaEquipmentModel> EquipmentOwned { get; set; }

        public NinjaModel()
        {
            Clan = new ClanModel();
            Name = string.Empty;
            EquipmentOwned = new HashSet<NinjaEquipmentModel>();
        }
    }
}