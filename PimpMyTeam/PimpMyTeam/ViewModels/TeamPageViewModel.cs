using System;

using Xamarin.Forms;

namespace PimpMyTeam.ViewModels
{
    public class TeamPageViewModel : ViewModelBase
    {
        public IList<Team> TeamsList { get; set; }

        public IList<Team> MemberTeamsList { get; set; }

        public Member Member { get; set; }

        public MemberPageViewModel(Member member)
        {
            Member = member;
            MemberTeamsList = Member.Teams;
            TeamsList = App.Database.GetTeamsAsync().Result;
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

