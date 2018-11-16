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

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            Team t = (Team)BindingContext;
            if (t != null && t.Id != 0)
            {
                var deleteBtn = new Button()
                {
                    Text = "Delete",
                };
                deleteBtn.Clicked += (sender, e) => {
                    OnDeleteClicked(sender, e);
                };
                teamCrudStack.Children.Add(deleteBtn);
            }
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