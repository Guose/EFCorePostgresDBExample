using LinqToDB.Mapping;
using NinjaDomain.Data.Enums;

namespace NinjaDomain.Data.Models
{
    [Table("NinjaEquipment")]
    public class NinjaEquipment : BaseModel
    {
        [Column]
        public string Name { get; set; }

        [Column, NotNull]
        public EquipmentType EquipmentType { get; set; }

        [Column, NotNull]
        public int NinjaId { get; set; }

        [Association(ThisKey = nameof(NinjaId), OtherKey = nameof(NinjaEquipment.Ninja.Id))]
        public virtual Ninja Ninja { get; set; }

        public NinjaEquipment()
        {
            Name = string.Empty;
            Ninja = new Ninja();
        }
    }
}
