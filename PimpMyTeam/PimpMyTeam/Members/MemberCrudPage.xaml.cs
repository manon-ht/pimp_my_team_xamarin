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

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            Member t = (Member)BindingContext;
            if (t != null && t.Id != 0)
            {
                var deleteBtn = new Button()
                {
                    Text = "Delete",
                };
                deleteBtn.Clicked += (sender, e) => {
                    OnDeleteClicked(sender, e);
                };
                memberCrudStack.Children.Add(deleteBtn);
            }
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var memberItem = (Member)BindingContext;
            if (memberItem.Name != "") {
                App.Database.SaveMemberAsync(memberItem);
                await Navigation.PopAsync();
            }
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
            var memberTeamPage = new MemberTeamPage();
            Member member = (Member)BindingContext;
            memberTeamPage.BindingContext = new MemberPageViewModel(member);
            await Navigation.PushAsync(memberTeamPage);
        }
    }
}