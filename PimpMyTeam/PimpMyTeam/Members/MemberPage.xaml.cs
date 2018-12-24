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
	public partial class MemberPage : ContentPage
    {
		public MemberPage ()
		{
			InitializeComponent();
            MemberCollectionViewModel memberCollection = new MemberCollectionViewModel(Navigation);
            this.BindingContext = memberCollection;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            var memberCrudPage = new MemberCrudPage();
            MemberCollectionViewModel mcvm = (MemberCollectionViewModel)this.BindingContext;
            mcvm.InitMemberViewModel();
            memberCrudPage.BindingContext = mcvm;
            await Navigation.PushAsync(memberCrudPage);
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
            if (e.SelectedItem != null)
            {
                var memberCrudPage = new MemberCrudPage();

                MemberCollectionViewModel binding = (MemberCollectionViewModel)this.BindingContext;
                binding.MemberViewModel = e.SelectedItem as MemberViewModel;
                memberCrudPage.BindingContext = binding;

                await Navigation.PushAsync(memberCrudPage);
            }
        }
    }
}