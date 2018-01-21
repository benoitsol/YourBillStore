using System.Collections.Generic;
using System.Threading.Tasks;
using Benoit.YBS.App.Models;

namespace Benoit.YBS.App.Services
{
    public class EntityDataStore : IEntityDataStore
    {
		public async Task<IEnumerable<T>> GetItemsAsync<T>() where T : new()
		{
            return await DataConnectionHelper.Database.Table<T>().ToListAsync();
		}

		public async Task<T> GetItemAsync<T>(string id) where T : EntityBase, new()
        {
            var items = await DataConnectionHelper.Database.Table<T>().Where(i => i.Id == id).ToListAsync();

			if (items == null || items.Count == 0)
				return null;

			return items[0];
		}

		public async Task<int> AddItemAsync<T>(T item) where T : EntityBase, new()
        {
            int result;
            if (item.Id != null)
            {
                result = await DataConnectionHelper.Database.UpdateAsync(item);
            }
            else
            {
                result = await DataConnectionHelper.Database.InsertAsync(item);
            }
            return result;
        }

		public async Task<int> UpdateItemAsync<T>(T item) where T : new()
        {
			return await DataConnectionHelper.Database.UpdateAsync(item);
        }

		public async Task<int> DeleteItemAsync<T>(T item) where T : new()
        {
            return await DataConnectionHelper.Database.DeleteAsync(item);
        }

		
	}
}