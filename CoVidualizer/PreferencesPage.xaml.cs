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


        }

        void pickerYourLocation_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            //Preferences.Set("YourLocation", X);
            //string countryName = Preferences.Get("YourLocation", X);

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
