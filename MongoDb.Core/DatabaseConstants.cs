namespace MongoDb.Core;

public static class DatabaseConstants
{
    /// <summary>
    /// The default page
    /// </summary>
    public const int DefaultPage = 0;

    /// <summary>
    /// The default page size
    /// </summary>
    public const int DefaultPageSize = (int)PageSize.PageSize20;
}

/// <summary>
/// 
/// </summary>
public enum PageSize
{
    /// <summary>
    /// The page size10
    /// </summary>
    PageSize10 = 10,

    /// <summary>
    /// The page size15
    /// </summary>
    PageSize15 = 15,

    /// <summary>
    /// The page size20
    /// </summary>
    PageSize20 = 20,

    /// <summary>
    /// The page size50
    /// </summary>
    PageSize50 = 50,

    /// <summary>
    /// The page size100
    /// </summary>
    PageSize100 = 100
}
