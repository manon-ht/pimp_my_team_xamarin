
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace PimpMyTeam
{
    public class MemberTeamsViewModel : ViewModelBase
    {
        public static List<SelectableData<Team>> SelectedData { get; set; }

        public List<SelectableData<Team>> DataSource { get; set; }

        protected Member Member;

        public MemberTeamsViewModel(Member member)
        {
            Member = member;

            // Load Data
            SelectedData = new List<SelectableData<Team>>();
            if (Member.Teams != null)
            {
                foreach (Team t in Member.Teams)
                {
                    SelectableData<Team> selectabledData = new SelectableData<Team>();
                    selectabledData.Data = t;
                    SelectedData.Add(new SelectableData<Team>());
                }
            }
        }

        public void OnAppearing()
        {
            DataSource = SelectedData.Where(x => x.Selected).ToList();
            OnPropertyChanged(nameof(DataSource));
        }


        public ICommand SelectCommand
        {
            get
            {
                return new Command(() =>
                {
                   // App.NavPage.PushAsync(new MultiSelect(SelectedData));
                });
            }

        }
    }
}
