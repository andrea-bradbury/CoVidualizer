using System;
using System.Collections.Generic;
using Xamarin.Essentials;

using Xamarin.Forms;

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


            //string selectedCountry = pickerYourLocation.SelectedItem;

            //Preferences.Set("YourLocation", );
            //string countryName = Preferences.Get("YourLocation", "Australia");

            //labelYourLocationSet.Text = countryName;
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
    }


}
