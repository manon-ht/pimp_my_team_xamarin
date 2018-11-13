using System;

using Xamarin.Forms;

namespace PimpMyTeam.Teams
{
    public class TeamPage : ContentPage
    {
        public TeamPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

