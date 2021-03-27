using GitEventTrackingApi.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace GitEventTrackingApi.Test.Helper
{
    public class SqliteDbContext : IDisposable
    {
        private DbConnection _connection;

        private DbContextOptions<GitEventTrackingContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<GitEventTrackingContext>()
                .UseSqlite(_connection).Options;
        }

        public GitEventTrackingContext CreateContext()
        {
            if (_connection != null)
            {
                return new GitEventTrackingContext(CreateOptions());
            }

            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var options = CreateOptions();
            using var context = new GitEventTrackingContext(options);
            context.Database.EnsureCreated();

            return new GitEventTrackingContext(CreateOptions());
        }

        public void Dispose()
        {
            if (_connection == null)
            {
                return;
            }
            _connection.Dispose();
            _connection = null;
        }
    }
}
