using AwesomeXamarinFormsRoller.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AwesomeXamarinFormsRoller
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;

        public MainPage()
        {
            viewModel = new MainPageViewModel();

            BindingContext = viewModel;

            InitializeComponent();

            lvMenuList.ItemsSource = viewModel.MenuItems;
        }
    }
}
