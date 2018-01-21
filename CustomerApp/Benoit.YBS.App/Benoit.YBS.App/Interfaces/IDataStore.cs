using Benoit.YBS.App.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Benoit.YBS.App.Services
{
    public interface IDataStore<T>
    {
        Task<int> AddItemAsync(T item);
        Task<int> UpdateItemAsync(T item);
        Task<int> DeleteItemAsync(T item);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync();
    }


    public interface IEntityDataStore
    {
        Task<int> AddItemAsync<T>(T item) where T : EntityBase, new();
        Task<int> UpdateItemAsync<T>(T item) where T : new();
        Task<int> DeleteItemAsync<T>(T item) where T : new();
        Task<T> GetItemAsync<T>(string id) where T : EntityBase, new();
        Task<IEnumerable<T>> GetItemsAsync<T>() where T : new();
    }
}
