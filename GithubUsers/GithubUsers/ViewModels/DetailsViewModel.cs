﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GithubUsers.Models;
using Xamarin.Forms;

namespace GithubUsers.ViewModels
{
    public class DetailsViewModel: BaseViewModel
    {
        private readonly INavigation _navigation;
        private readonly UserForList _userForList;
        public DetailsViewModel(INavigation navigation, UserForList userForList)
        {
            _navigation = navigation;
            _userForList = userForList;
            Initialize();
        }

        private string _avatar;
        public string AvatarUrl
        {
            get => _avatar;
            set => SetProperty(ref _avatar, value);
        }

        private string _login;
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        private string _city;
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        private int _followers;
        public int Followers
        {
            get => _followers;
            set => SetProperty(ref _followers, value);
        }

        private int _following;
        public int Following
        {
            get => _following;
            set => SetProperty(ref _following, value);
        }

        private async Task Initialize()
        {
            var userDetails = await GetResponse<UserForDetails>($"{App.ApiUrl}/{_userForList.Login}");
            Login = userDetails.Login;
            City = userDetails.Location;
            AvatarUrl = userDetails.AvatarUrl;
            Followers = userDetails.Followers;
            Following = userDetails.Following;
        }
    }
}
