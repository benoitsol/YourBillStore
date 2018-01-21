using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Benoit.YBS.App.Models;
using Benoit.YBS.App.Views;
using Benoit.YBS.App.ViewModels;

namespace Benoit.YBS.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InvoiceListPage : ContentPage
	{
        InvoiceListViewModel viewModel;

        public InvoiceListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new InvoiceListViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Invoice;
            if (item == null)
                return;

            await Navigation.PushAsync(new InvoiceDetailPage(new InvoiceDetailViewModel(item)));

            // Manually deselect item.
            InvoicesList.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        async void Settings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }

        }
    }
}