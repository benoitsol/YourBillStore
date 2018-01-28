using Common;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BillStoreAdminUI
{
    public class InvoiceDetailViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<BillingItem> _items;

        private Invoice _invoice;

        private ICommand addItemsCommand;

        private ICommand addInvoiceCommand;

        public ICommand AddItemsCommand
        {
            get => addItemsCommand;
            set
            {
                addItemsCommand = value;
                NotifyPropertyChanged("AddItemsCommand");
            }
        }

        public ICommand AddInvoiceCommand
        {
            get => addInvoiceCommand;
            set
            {
                addInvoiceCommand = value;
                NotifyPropertyChanged("AddInvoiceCommand");
             }
        }       
        

        public ObservableCollection<BillingItem> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                NotifyPropertyChanged("Items");
            }
        }

        public Invoice Invoice
        {
            get => _invoice;
            set
            {
                _invoice = value;
                NotifyPropertyChanged("Invoice");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public InvoiceDetailViewModel()
        {
            this.Items = new ObservableCollection<BillingItem>();
            this.Items.CollectionChanged += Items_CollectionChanged;
            this.AddItemsCommand = new DelegateCommand<BillingItem>(AddItems);
            this.Invoice = new Invoice();
        }

        private void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var items = sender as IEnumerable<BillingItem>;

            if (items.Any())
            {
                this.Invoice.BillItems = JsonConvert.SerializeObject(items);
            }

        }

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void AddItems(BillingItem T )
        {
              this.Items.Add(new BillingItem());
        }

    }
}
