using LinqToDB.Mapping;
using NinjaDomain.WebApi.Enums;

namespace NinjaDomain.WebApi.Models
{
    [Table("NinjaEquipment")]
    public class NinjaEquipmentModel : BaseModel
    {
        [Column]
        public string Name { get; set; }

        [Column, NotNull]
        public EquipmentTypes EquipmentType { get; set; }

        [Column, NotNull]
        public int NinjaId { get; set; }

        [Association(ThisKey = nameof(NinjaId), OtherKey = nameof(NinjaEquipmentModel.Ninja.Id))]
        public virtual NinjaModel Ninja { get; set; }

        public NinjaEquipmentModel()
        {
            Name = string.Empty;
            Ninja = new NinjaModel();
        }
    }
}