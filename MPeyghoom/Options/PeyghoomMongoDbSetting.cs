namespace MPeyghoom.Options;

public class PeyghoomMongoDbSetting
{
    public const string Key = "PeyghoomMongoDbSetting";
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string BooksCollectionName { get; set; } = null!;
}