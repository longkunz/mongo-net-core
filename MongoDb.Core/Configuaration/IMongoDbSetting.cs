namespace MongoDb.Core.Configuaration
{
    public interface IMongoDbSetting
    {
        string ConnectionStrings { get; set; }
        string DbName { get; set; }
    }
}
