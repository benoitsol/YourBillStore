using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Benoit.YBS.App.Models;
using Benoit.YBS.App.Views;
using System.Linq;

namespace Benoit.YBS.App.ViewModels
{
    public class InvoiceListViewModel : BaseViewModel
    {
        public ObservableCollection<Invoice> Items { get; set; }
        public ObservableCollection<IGrouping<string, Invoice>> ItemsGrouped { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command ReloadInvoicesFromServer { get; set; }


        public InvoiceListViewModel()
        {
            Title = "Invoices";
            Items = new ObservableCollection<Invoice>();
            ItemsGrouped = new ObservableCollection<IGrouping<string, Invoice>>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ReloadInvoicesFromServer = new Command(async () => await ExecuteReloadInvoicesFromServerCommand());

            MessagingCenter.Subscribe<NewItemPage, Invoice>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Invoice;
                Items.Add(_item);
                await DataStoreNew.AddItemAsync(_item);
            });
        }

        private Task ExecuteReloadInvoicesFromServerCommand()
        {
            return ExecuteLoadItemsCommand();
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                ItemsGrouped.Clear();
                var items = await DataStoreNew.GetItemsAsync<Invoice>();
                foreach (var item in items)
                {
                    Items.Add(item);                    
                }


                foreach(var group in items.GroupBy(x => x.SellerName))
                {
                    ItemsGrouped.Add(group);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}