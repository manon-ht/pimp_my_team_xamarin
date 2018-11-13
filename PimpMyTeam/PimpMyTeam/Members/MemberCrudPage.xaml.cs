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
	public partial class MemberCrudPage : ContentPage
	{
		public MemberCrudPage ()
		{
			InitializeComponent ();
		}

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var memberItem = (Member)BindingContext;
            await App.Database.SaveMemberAsync(memberItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var memberItem = (Member)BindingContext;
            await App.Database.DeleteMemberAsync(memberItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void OnTeamsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MemberTeamPage()
            {
                BindingContext = (Member)BindingContext
            });
        }
    }
}