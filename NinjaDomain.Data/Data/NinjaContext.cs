using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using NinjaDomain.Data.Models;

namespace NinjaDomain.Data.Data
{
    public abstract partial class NinjaContext : DataConnection
    {
        internal static byte[] EncryptionKey { get; set; } = Array.Empty<byte>();

        public NinjaContext(LinqToDBConnectionOptions<NinjaContext> options) : base(options) 
        {
            //MappingSchema.SetConvertExpression<Encry>
        }

        public ITable<Ninja> Ninjas => this.GetTable<Ninja>();
        public ITable<Clan> Clans => this.GetTable<Clan>();
        public ITable<NinjaEquipment> NinjaEquipment => this.GetTable<NinjaEquipment>();
    }
}
