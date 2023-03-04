using LinqToDB.Mapping;

namespace NinjaDomain.Data.Models
{
    [Table("Clans")]
    public class Clan : BaseModel
    {
        [Column, NotNull]
        public string ClanName { get; set; }

        public virtual ICollection<Ninja> Ninjas { get; set; }

        public Clan()
        {
            ClanName = string.Empty;
            Ninjas = new HashSet<Ninja>();
        }
    }
}
