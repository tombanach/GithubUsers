using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GithubUsers.ViewModels;
using Xamarin.Forms;

namespace GithubUsers
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel(Navigation);
        }

        private void UserList_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var context = BindingContext as HomeViewModel;
            context.GoToDetailsCommand.Execute(e.Item);
        }
    }
}
