﻿using InToGuideApp.Services.Interfaces;
using InToGuideApp.Services;
using InToGuideApp.Views.Dialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InToGuideApp.Validations;
using Prism.Services.Dialogs;
using Prism.Events;
using Xamarin.CommunityToolkit.UI.Views;
using InToGuideApp.Helpers;
using InToGuideWebAPI.Enum;

namespace InToGuideApp.ViewModels
{
    public class MentorCreateAccountPageViewModel : ViewModelBase
    {

        //CreateAccountService _createAccountService = new CreateAccountService();
        private ICreateAccount _createAccountService;
        private IDialogService _dialogService;
        private IEventAggregator _eventAggregator;
        public string Message { get; set; }
        //public string AccountType { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Qualification { get; set; }

        //public string Institution { get; set; }
        //public string City { get; set; }
        //public string Province { get; set; }
        //public string Hobbies { get; set; }
        //public string PhoneNumber { get; set; }
        //public string EmailAddress { get; set; }
        //public string Password { get; set; }

        private ValidatableObject<string> _accountType;
        public ValidatableObject<string> AccountType
        {
            get { return _accountType; }
            set { SetProperty(ref _accountType, value); }
        }

        private ValidatableObject<string> _firstName;
        public ValidatableObject<string> FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private ValidatableObject<string> _lastName;
        public ValidatableObject<string> LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private ValidatableObject<string> _qualification;
        public ValidatableObject<string> Qualification
        {
            get { return _qualification; }
            set { SetProperty(ref _qualification, value); }
        }

        private ValidatableObject<string> _institution;
        public ValidatableObject<string> Institution
        {
            get { return _institution; }
            set { SetProperty(ref _institution, value); }
        }

        private ValidatableObject<string> _city;
        public ValidatableObject<string> City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }

        private ValidatableObject<string> _province;
        public ValidatableObject<string> Province
        {
            get { return _province; }
            set { SetProperty(ref _province, value); }
        }

        private ValidatableObject<string> _hobbies;
        public ValidatableObject<string> Hobbies
        {
            get { return _hobbies; }
            set { SetProperty(ref _hobbies, value); }
        }

        private ValidatableObject<string> _phoneNumber;
        public ValidatableObject<string> PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }

        private ValidatableObject<string> _emailAddress;
        public ValidatableObject<string> EmailAddress
        {
            get { return _emailAddress; }
            set { SetProperty(ref _emailAddress, value); }
        }

        private ValidatableObject<string> _password;
        public ValidatableObject<string> Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private DelegateCommand _createMentorAccountCommand;
        public DelegateCommand CreateMentorAccountCommand =>
            _createMentorAccountCommand ?? (_createMentorAccountCommand = new DelegateCommand(ExecuteCreateMentorAccountCommand));

        private async void ExecuteCreateMentorAccountCommand()
        {

            //activityindicator.isrunning = true
            try
            {
                var user = await _createAccountService.CreateNewUser((int) AccountTypeEnum.Mentor, FirstName.Value, LastName.Value, Qualification.Value, Institution.Value, City.Value, Province.Value, Hobbies.Value, PhoneNumber.Value, EmailAddress.Value, Password.Value );
            
                if (user != null)
                {

                    await NavigationService.NavigateAsync("LoginPage");
                }

                else
                {
                    var param = new DialogParameters()
                        {
                            { "message", Constants.Errors.UserCreateError }
                        };
                    _dialogService.ShowDialog(nameof(ErrorDialog), param);
                }
            }
            catch (Exception ex)
            {
                var param = new DialogParameters()
                {
                    { "message", Constants.Errors.GeneralError }
                };
                _dialogService.ShowDialog(nameof(ErrorDialog), param);
            }
            
        }

        
        public MentorCreateAccountPageViewModel(INavigationService navigationService, ICreateAccount createAccount, IDialogService dialogService)
            : base(navigationService)
        {
            
            _createAccountService = createAccount;
            _dialogService = dialogService;
            AddValidations();
        }

        public override void Initialize(INavigationParameters parameters)
        {
            Title = "Mentor Create Account Page";
            

        }

        private void AddValidations()
        {
            AccountType = new ValidatableObject<string>();
            FirstName = new ValidatableObject<string>();
            LastName = new ValidatableObject<string>();
            Qualification = new ValidatableObject<string>();
            Institution = new ValidatableObject<string>();
            City = new ValidatableObject<string>();
            Province = new ValidatableObject<string>();
            Hobbies = new ValidatableObject<string>();
            PhoneNumber = new ValidatableObject<string>();
            EmailAddress = new ValidatableObject<string>();
            Password = new ValidatableObject<string>();

        }

    }
}
