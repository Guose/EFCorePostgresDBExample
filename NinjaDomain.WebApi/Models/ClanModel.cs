using LinqToDB.Mapping;

namespace NinjaDomain.WebApi.Models
{
    [Table("Clans")]
    public class ClanModel : BaseModel
    {
        [Column, NotNull]
        public string ClanName { get; set; }

        public virtual ICollection<NinjaModel> Ninjas { get; set; }

        public ClanModel()
        {
            ClanName = string.Empty;
            Ninjas = new HashSet<NinjaModel>();
        }
    }
}