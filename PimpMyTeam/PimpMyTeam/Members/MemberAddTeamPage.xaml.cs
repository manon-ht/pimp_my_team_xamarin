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
            BindingContext = new TeamPickerPageViewModel
            {
                TeamsListing = TeamsListingContext()
            };
        }

        private async Task<IList<Team>> TeamsListingContext()
        {
            return await App.Database.GetTeamsAsync();
        }
    }
}