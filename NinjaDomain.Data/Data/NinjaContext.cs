using LinqToDB;
using LinqToDB.Data;
using NinjaDomain.Data.Models;

namespace NinjaDomain.Data.Data
{
    public class NinjaContext : DataConnection
    {
        public NinjaContext(DataOptions options) : base(options) { }

        public ITable<Ninja> Ninjas => this.GetTable<Ninja>();
        public ITable<Clan> Clans => this.GetTable<Clan>();
        public ITable<NinjaEquipment> NinjaEquipment => this.GetTable<NinjaEquipment>();
    }
}
