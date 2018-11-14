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
    public partial class TeamCrudPage : ContentPage
    {
        public TeamCrudPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var teamItem = (Team)BindingContext;
            App.Database.SaveTeamAsync(teamItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var teamItem = (Team)BindingContext;
            await App.Database.DeleteTeamAsync(teamItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}