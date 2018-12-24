using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace PimpMyTeam
{
    public class MemberCollectionViewModel : ViewModelBase
    {
        IList<MemberViewModel> members;
        public IList<MemberViewModel> Members
        {
            set { SetProperty(ref members, value); }
            get { return members; }
        }

        MemberViewModel memberViewModel;
        public MemberViewModel MemberViewModel
        {
            set { SetProperty(ref memberViewModel, value); }
            get { return memberViewModel; }
        }

        public void InitMemberViewModel()
        {
            MemberViewModel = new MemberViewModel();
            MemberViewModel.PropertyChanged += OnMemberEditPropertyChanged;
        }

        public INavigation Navigation { get; set; }

        public MemberCollectionViewModel(INavigation navigation)
        {
            Navigation = navigation;
            InitMemberViewModel();
            //IsEditing = true;
            members = new List<MemberViewModel>();
            IList<Member> MembersList = App.Database.GetMembersAsync().Result;
            foreach (Member m in MembersList)
            {
                MemberViewModel Mvm = new MemberViewModel();
                Mvm.Member = m;
                Mvm.PropertyChanged += OnMemberEditPropertyChanged;
                Members.Add(Mvm);
            }
            SubmitCommand = new Command(
                execute: () =>
                {
                    MemberViewModel.PropertyChanged -= OnMemberEditPropertyChanged;
                    App.Database.SaveMemberAsync(MemberViewModel.Member);
                    Members.Add(MemberViewModel);
                    MemberViewModel = null;
                    //IsEditing = false;

                    RefreshCanExecutes();
                    NavigationPushAsync();

                },
                canExecute: () =>
                {
                    //if (TeamViewModel != null) {
                    //        return true;
                    //}
                    //return false;
                    return MemberViewModel != null &&
                    MemberViewModel.Member != null &&
                    MemberViewModel.Member.FirstName != null &&
                    MemberViewModel.Member.FirstName.Length > 0 &&
                    MemberViewModel.Member.LastName != null &&
                    MemberViewModel.Member.LastName.Length > 0;
                });

            CancelCommand = new Command(
                execute: () =>
                {
                    MemberViewModel.PropertyChanged -= OnMemberEditPropertyChanged;
                    MemberViewModel = null;
                    //IsEditing = false;
                    RefreshCanExecutes();
                    NavigationPopAsync();
                },
                canExecute: () =>
                {
                    return true;
                    // return IsEditing;
                });

            DeleteCommand = new Command(
                execute: () =>
                {
                    MemberViewModel.PropertyChanged -= OnMemberEditPropertyChanged;
                    App.Database.DeleteMemberAsync(MemberViewModel.Member);
                    //Teams.Add(TeamViewModel);
                    MemberViewModel = null;
                    //IsEditing = false;

                    RefreshCanExecutes();
                    NavigationPushAsync();
                },
                canExecute: () =>
                {
                    return MemberViewModel != null &&
                    MemberViewModel.Member != null &&
                    MemberViewModel.Member.Id != 0;
                });

        }

        void OnMemberEditPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            (SubmitCommand as Command).ChangeCanExecute();
            (CancelCommand as Command).ChangeCanExecute();
            (DeleteCommand as Command).ChangeCanExecute();
        }

        void RefreshCanExecutes()
        {
            (SubmitCommand as Command).ChangeCanExecute();
            (CancelCommand as Command).ChangeCanExecute();
            (DeleteCommand as Command).ChangeCanExecute();
        }

        public async void NavigationPushAsync()
        {
            await Navigation.PushAsync(new MemberPage());
        }

        public async void NavigationPopAsync()
        {
            await Navigation.PopAsync();
        }

        public ICommand SubmitCommand { private set; get; }
        public ICommand CancelCommand { private set; get; }
        public ICommand DeleteCommand { private set; get; }
    }
}
