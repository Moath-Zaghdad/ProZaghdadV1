using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ProZaghdadV1.EntityFrameworkCore
{
    public static class ProZaghdadV1DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ProZaghdadV1DbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ProZaghdadV1DbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
