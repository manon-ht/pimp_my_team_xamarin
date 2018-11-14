using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PimpMyTeam
{
	public partial class MemberAddTeamPage : ContentPage
	{
		public MemberAddTeamPage ()
		{
			InitializeComponent ();
           /* BindingContext = new TeamPickerPageViewModel
            {
                TeamsListing = TeamsListingContext()
            };*/
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            teamsPicker.ItemsSource = await App.Database.GetTeamsAsync();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            Team t = (Team)teamsPicker.SelectedItem;
            if (t != null) {
                App.Database.SaveTeamAsync(t);
                Member memberItem = (Member)BindingContext;
                List<Team> mTeams = memberItem.Teams;
                if (mTeams == null) {
                    memberItem.Teams = new List<Team> { t };
                } else {
                    memberItem.Teams.Add(t);
                }
                App.Database.SaveMemberAsync(memberItem);
                await Navigation.PopAsync();
            }
        }
    }
}