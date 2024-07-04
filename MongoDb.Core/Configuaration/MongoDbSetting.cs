namespace MongoDb.Core.Configuaration
{
    public class MongoDbSetting : IMongoDbSetting
    {
        public string ConnectionStrings { get; set; }
        public string DbName { get; set; }
    }
}
