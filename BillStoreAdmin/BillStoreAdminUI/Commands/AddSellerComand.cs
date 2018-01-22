using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BillStoreAdminUI.Commands
{
    public class AddSellerComand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var seller = parameter as SellerDetails;
            SaveUser(seller);
        }

        private void SaveUser(SellerDetails seller)
        {
            var client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(seller), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(
                $"api/user/", content).Result;
            response.EnsureSuccessStatusCode();
            var invoiceResp = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
    }
}
