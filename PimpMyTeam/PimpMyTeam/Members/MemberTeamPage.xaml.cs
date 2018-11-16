using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PimpMyTeam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MemberTeamPage : ContentPage
	{
		public MemberTeamPage()
		{
			InitializeComponent();

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            //MemberPageViewModel context = (MemberPageViewModel)BindingContext;
            //teamListView.BindingContext = context.MemberTeamsList;
            // var memberItem = (Member)BindingContext;
            //  var memberTeams = memberItem.Teams;

            //teamListView.ItemsSource = memberTeams;
        }

        async void OnAddClicked(object sender, SelectedItemChangedEventArgs e)
        {
            MemberPageViewModel viewModel = (MemberPageViewModel)BindingContext;

            await Navigation.PushAsync(new MemberAddTeamPage
            {
                BindingContext = viewModel
            });
        }
    }
}