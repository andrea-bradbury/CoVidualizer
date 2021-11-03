using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;


namespace CoVidualizer
{
    public partial class PreferencesPage : ContentPage
    {
        

        public PreferencesPage()
        {
            InitializeComponent();

            labelYourLocationSet.Text = Preferences.Get("YourLocation", "Australia");


            
        }

        

        void pickerYourLocation_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            Preferences.Set("YourLocation", pickerYourLocation.SelectedItem.ToString());
           

            labelYourLocationSet.Text = Preferences.Get("YourLocation", "Australia");

            

            DisplayAlert("Your location has been changed.", "", "OK");



        }



        async void buttonBack_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                await Navigation.PopModalAsync();
            }
            catch
            {

            }
        }




        public async Task<bool> populatePicker(List<string> listOfCountryNames)
        {
            try
            {
                
                pickerYourLocation.ItemsSource = listOfCountryNames;

                return true;
            }
            catch
            {
                return false;
            }

            

           
        }
    }


}
