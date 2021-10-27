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
        //Instantiate the data model
        public Models.Rootobject root = new Models.Rootobject();


        public PreferencesPage()
        {
            InitializeComponent();

            labelYourLocationSet.Text = Preferences.Get("YourLocation", "Australia");

            populatePicker();
        }

        

        void pickerYourLocation_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            

            //Models.Datum selectedCountry = pickerYourLocation.SelectedItem.name;

            //Preferences.Set("YourLocation", selectedCountry.name);


            labelYourLocationSet.Text = Preferences.Get("YourLocation", "Australia");
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

        public void populatePicker()
        {


            //Pulling a list by country names

            List<string> listOfCountries = root.data.Select(data => data.name).ToList();


            pickerYourLocation.ItemsSource = listOfCountries;

           
        }
    }


}
