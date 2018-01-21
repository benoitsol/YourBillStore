﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Benoit.YBS.UiReference
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public IList<Item> ItemList = new List<Item>();

        public MainWindow()
        {
            ItemList.Add(new Item() { Name = "sdsadsad", Rate = "sasasa", Amount = "sasassaSAAxasxsaxsaxsx" });
            ItemList.Add(new Item() { Name = "sdsadsad", Rate = "sasasa", Amount = "sasaSXSAXSs" });
            ItemList.Add(new Item() { Name = "sdsadsad", Rate = "sasasa", Amount = "sasaSXSs" });

            ItemList.Add(new Item() { Name = "sdsadsad", Rate = "sasasa", Amount = "sasSXSXas" });

            ItemList.Add(new Item() { Name = "sdsadsad", Rate = "sasasa", Amount = "sasXXas" });

            InitializeComponent();
            ItemsListView.ItemsSource = ItemList;
        }

        private void ItemsListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            GridView gView = listView.View as GridView;

            var workingWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth; // take into account vertical scrollbar
            double col1 = 5.1 / 7;
            double col2 = 1.9 / 7;


            gView.Columns[0].Width = workingWidth * col1;
            gView.Columns[1].Width = workingWidth * col2;

        }
    }

    public class Item
    {
        public string Name { get; set; }
        public string Rate { get; set; }
        public string Amount { get; set; }
    }


}
