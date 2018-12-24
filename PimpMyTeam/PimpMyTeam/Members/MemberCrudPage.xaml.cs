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

        async void OnTeamsClicked(object sender, EventArgs e)
        {
            var memberTeamPage = new MemberTeamPage();
            MemberCollectionViewModel binding = (MemberCollectionViewModel)this.BindingContext;
            memberTeamPage.BindingContext = new MemberTeamsViewModel(binding.MemberViewModel.Member);
            await Navigation.PushAsync(memberTeamPage);
        }
    }
}