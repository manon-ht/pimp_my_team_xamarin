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
    public partial class MemberTeamPage : ContentPage
	{
		public MemberTeamPage()
		{
			InitializeComponent();

            //BindingContext = new MemberTeamsViewModel((Member)BindingContext);


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((MemberTeamsViewModel)BindingContext).OnAppearing();
        }

        async void OnAddClicked(object sender, SelectedItemChangedEventArgs e)
        {
            MemberPageViewModel viewModel = (MemberPageViewModel)BindingContext;

            await Navigation.PushAsync(new MemberAddTeamPage
            {
                BindingContext = viewModel
            });
        }
    }
}