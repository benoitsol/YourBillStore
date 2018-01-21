using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Benoit.YBS.App.Models;

namespace Benoit.YBS.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Invoice Invoice { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Invoice = new Invoice
            {
                SellerName = "Seller Name",
                InvoiceDate = "31/12/2017"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Invoice);
            await Navigation.PopModalAsync();
        }
    }
}