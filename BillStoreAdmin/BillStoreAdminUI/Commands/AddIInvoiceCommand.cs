using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace BillStoreAdminUI.Commands
{
    public class AddIInvoiceCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;        

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var invoice = parameter as Invoice;
        }

        private async Task SaveInvoiceAsync(Invoice invoice)
        {
            var  client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(invoice), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(
                $"api/Invoice/", content);
            response.EnsureSuccessStatusCode();            
            var invoiceResp = await response.Content.ReadAsStringAsync();

            invoice = new Invoice();
        }
    }    
}
