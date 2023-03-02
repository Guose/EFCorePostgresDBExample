using LinqToDB.Mapping;
using NinjaDomain.Data.Enums;
using NinjaDomain.Data.Interfaces;
using System.Security.Claims;

namespace NinjaDomain.Data.Models
{
    [Table("NinjaEquipment")]
    public class NinjaEquipment : IModificationHistory
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column, NotNull]
        public EquipmentType EquipmentType { get; set; }

        [Column, NotNull]
        public DateTimeOffset DateModified { get; set; }

        [Column, NotNull]
        public DateTimeOffset DateCreated { get; set; }

        [Column, NotNull]
        public bool IsDirty { get; set; }

        [Column, NotNull]
        public int NinjaId { get; set; }

        [Association(ThisKey = nameof(NinjaId), OtherKey = nameof(NinjaEquipment.Ninja.Id))]
        public Ninja Ninja { get; set; }

        public NinjaEquipment()
        {
            Name = string.Empty;
            Ninja = new Ninja();
            DateCreated = DateTimeOffset.UtcNow;
        }
    }
}
