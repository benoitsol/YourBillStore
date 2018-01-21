

using Benoit.YBS.App.Interfaces;
using Benoit.YBS.App.Models;
using SQLite;
using Xamarin.Forms;

namespace Benoit.YBS.App.Services
{
    static class DataConnectionHelper
    {
        private static SQLiteAsyncConnection database;

        internal static SQLiteAsyncConnection Database
        {
            get
            {
                if (database == null)
                {
                    var dbPath = DependencyService.Get<IFileHelper>().GetLocalFilePath("ybsData.db3");
                    database = new SQLiteAsyncConnection(dbPath);
                    database.CreateTableAsync<Invoice>().Wait();
                    database.CreateTableAsync<Seller>().Wait();
                    database.CreateTableAsync<User>().Wait();
                    database.CreateTableAsync<Item>().Wait();
                    return Database;
                }
                return database;
            }
        }


}
}
