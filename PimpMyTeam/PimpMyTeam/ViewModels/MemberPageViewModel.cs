using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PimpMyTeam
{
    public class MemberPageViewModel : ViewModelBase
    {
        public IList<Team> TeamsList { get; set; }
       
        IList<Team> memberTeamsList;
        public IList<Team> MemberTeamsList
        {
            get { return memberTeamsList; }
            set
            {
                if (memberTeamsList != value)
                {
                    memberTeamsList = value;
                    OnPropertyChanged();
                }
            }
        }

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

