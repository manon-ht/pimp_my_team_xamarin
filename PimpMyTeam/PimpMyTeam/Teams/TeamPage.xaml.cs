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
    public partial class TeamPage : ContentPage
    {
        public TeamPage()
        {
            InitializeComponent();
            TeamCollectionViewModel teamCollection = new TeamCollectionViewModel(Navigation);
            this.BindingContext = teamCollection;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            //listView.ItemsSource = await App.Database.GetTeamsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            var teamCrudPage = new TeamCrudPage();
            TeamCollectionViewModel tcvm = (TeamCollectionViewModel)this.BindingContext;
            tcvm.InitTeamViewModel();
            //tcvm.TeamViewModel = new TeamViewModel();
            teamCrudPage.BindingContext = tcvm;
            await Navigation.PushAsync(teamCrudPage);
            //await Navigation.PushAsync(new TeamCrudPage());
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
            if (e.SelectedItem != null)
            {
                var teamCrudPage = new TeamCrudPage();

                TeamCollectionViewModel binding = (TeamCollectionViewModel)this.BindingContext;
                binding.TeamViewModel = e.SelectedItem as TeamViewModel;
                teamCrudPage.BindingContext = binding;

                await Navigation.PushAsync(teamCrudPage);
            }
        }
    }
}