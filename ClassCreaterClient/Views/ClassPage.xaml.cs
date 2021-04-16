using ClassCreaterClient.Data;
using ClassCreaterClient.Moldes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClassCreaterClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClassPage : ContentPage
    {
        App thisApp;
        List<ClassType> classTypes;

        public ClassPage()
        {
            InitializeComponent();
            thisApp = Application.Current as App;
            thisApp.needClassRefresh = true;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (thisApp.needClassRefresh)
            {
                refreshClasses();
            }
            else
            {
                classList.IsVisible = true;
            }
            classList.SelectedItem = null;
        }

        private void refreshClasses()
        {
            thisApp = Application.Current as App;
            showClasses();
        }

        private async void showClasses()
        {
            // Getting all Classes
            ClassRepository c = new ClassRepository();
            try
            {
                List<Class> classes;
                classes = await c.GetClasses();
                classList.ItemsSource = classes;
                classList.IsVisible = true;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    if (ex.GetBaseException().Message.Contains("connection with the server"))
                    {

                        await DisplayAlert("Error", "No connection with the server. Check that the Web Service is running and available and then click the Refresh button.", "Ok");
                    }
                    else
                    {
                        await DisplayAlert("Error", "If the problem persists, please call your system administrator.", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("General Error", "If the problem persists, please call your system administrator.", "Ok");
                }
            }
        }

        private void AddClicked(object sender, EventArgs e)
        {

        }

        private void classSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var classSelected = (Class)e.SelectedItem;
                var classDetailPage = new ClassDetailPage();
                classDetailPage.BindingContext = classSelected;
                classList.IsVisible = false;
                Navigation.PushAsync(classDetailPage);
            }
        }

        private async void Tank_Clicked(object sender, EventArgs e)
        {
            ClassRepository c = new ClassRepository();
            try
            {

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    if (ex.GetBaseException().Message.Contains("connection with the server"))
                    {

                        await DisplayAlert("Error", "No connection with the server. Check that the Web Service is running and available and then click the Refresh button.", "Ok");
                    }
                    else
                    {
                        await DisplayAlert("Error", "If the problem persists, please call your system administrator.", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("General Error", "If the problem persists, please call your system administrator.", "Ok");
                }
            }
        }

        private void Melee_Clicked(object sender, EventArgs e)
        {

        }

        private void Range_Clicked(object sender, EventArgs e)
        {

        }

        private void Healer_Clicked(object sender, EventArgs e)
        {

        }


    }
}