using Microsoft.EntityFrameworkCore;
using RealEstate;
using RealEstateGUI.Models;
using System;
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

namespace RealEstateGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ingatlanContext ingatlanContext = new ingatlanContext();
        public MainWindow()
        {
            InitializeComponent();

            ingatlanContext.Sellers.Load();
            ingatlanContext.Realestates.Load();
            ingatlanContext.Categories.Load();

            lbNames.ItemsSource = (from e in ingatlanContext.Sellers select e).ToList();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            List<Realestates> realEstates = (from x in ingatlanContext.Realestates where x.SellerId == ((Sellers)lbNames.SelectedItem).Id select x).ToList();
            //(from s in ingatlanContext.Realestates where s.SellerId == ((Seller)lbNames.SelectedItem).Id select s).ToList().Count();
            lblAdCount.Content = realEstates.Count;
        }

        private void lbNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            spData.DataContext = lbNames.SelectedItem;
        }
    }
}
