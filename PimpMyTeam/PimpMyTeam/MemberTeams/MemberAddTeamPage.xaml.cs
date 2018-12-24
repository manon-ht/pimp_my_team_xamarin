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
			InitializeComponent();
           
          /*  BindingContext = new MemberPageViewModel
            {
                Member = (Member)BindingContext
            };*/
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Reset the 'resume' id, since we just want to re-start here
          //  ((App)App.Current).ResumeAtTodoId = -1;
         //   //TeamsPicker.ItemsSource = await App.Database.GetTeamsAsync();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            MemberPageViewModel viewModel = (MemberPageViewModel)BindingContext;
            Team t = (Team)TeamsPicker.SelectedItem;
            if (t != null) {
               //App.Database.SaveTeamAsync(t);
                if (viewModel.Member.Teams == null) {
                    viewModel.Member.Teams = new List<Team> { t };
                } else {
                    viewModel.Member.Teams.Add(t);
                }
                App.Database.SaveMemberAsync(viewModel.Member);
                await Navigation.PopAsync();
            }
         
        }
    }
}