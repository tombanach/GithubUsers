using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GithubUsers.Models;
using GithubUsers.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GithubUsers.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(UserForList userForList)
        {
            InitializeComponent();
            BindingContext = new DetailsViewModel(Navigation, userForList);
        }
    }
}