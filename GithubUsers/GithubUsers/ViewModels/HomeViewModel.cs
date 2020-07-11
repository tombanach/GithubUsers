using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GithubUsers.Models;
using GithubUsers.Views;
using Xamarin.Forms;

namespace GithubUsers.ViewModels
{
    public class HomeViewModel: BaseViewModel
    {
        private readonly INavigation _navigation;

        public HomeViewModel()
        {
            Initialize();
        }

        public HomeViewModel(INavigation navigation) : this()
        {
            _navigation = navigation;
        }

        private List<UserForList> _usersForList;
        public List<UserForList> UsersForList
        {
            get => _usersForList;
            set => SetProperty(ref _usersForList, value);
        }

        private async Task Initialize()
        {
            var usersForList = await GetResponse<List<UserForList>>("");
            UsersForList = usersForList;
        }

        private ICommand _goToDetailsCommand;
        public ICommand GoToDetailsCommand => _goToDetailsCommand ?? (_goToDetailsCommand = new Command<UserForList>(userForList => OnGoToDetails(userForList)));

        private void OnGoToDetails(UserForList userForList)
        {
            _navigation.PushAsync(new DetailsPage(userForList));
        }
    }
}
