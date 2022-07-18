﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InToGuideApp.ViewModels
{
    public class ResetPasswordPageViewModel : ViewModelBase
    {
        public ResetPasswordPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Reset Password Page";
        }
    }
}
