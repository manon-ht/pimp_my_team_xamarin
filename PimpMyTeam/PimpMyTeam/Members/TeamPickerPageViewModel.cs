using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PimpMyTeam
{
    class TeamPickerPageViewModel : ViewModelBase
    {
        public Task<IList<Team>> TeamsListing { get; set; }

        public async Task<IList<Team>> TeamsListingAsync()
        {
            return await App.Database.GetTeamsAsync();

        }

        Team selectedTeam;
        public Team SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                if (selectedTeam != value)
                {
                    selectedTeam = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
