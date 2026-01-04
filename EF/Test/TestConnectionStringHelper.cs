using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;

namespace ef;

public static class TestConnectionStringHelper
{
    public static string SqlConnectionString =>
    @"Data Source =.\sqlexpress;Integrated Security = True;Initial Catalog=adatvez; Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;
    Encrypt=False;TrustServerCertificate=True;Application Name = SQL Server Management Studio; Command Timeout = 30";
}
