using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Benoit.YBS.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GroupHeaderView : ContentView
	{
		public GroupHeaderView ()
		{
			InitializeComponent ();
		}
	}

    public class GroupHeader : ViewCell
    {
        public GroupHeader()
        {           

            View = new GroupHeaderView();
        }
    }
}