using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Benoit.YBS.App.Models;
using Benoit.YBS.App.ViewModels;

namespace Benoit.YBS.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InvoiceDetailPage : ContentPage
	{
        InvoiceDetailViewModel viewModel;

        public InvoiceDetailPage(InvoiceDetailViewModel viewModel)
        {

           
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        
    }
}