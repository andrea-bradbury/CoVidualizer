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

        Services.APIService api = new Services.APIService();

        //List of countries as names
        List<string> listOfCountries = new List<string>();


        public PreferencesPage()
        {
            InitializeComponent();

            labelYourLocationSet.Text = Preferences.Get("YourLocation", "Australia");

            
        }

        

        void pickerYourLocation_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

            for (int i =0; i < listOfCountries.Count; i++ )
            {
                if (pickerYourLocation.SelectedItem.ToString() == root.data[i].name)
                {
                    Preferences.Set("YourLocation", root.data[i].name);
                }
            }

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




        public async Task<bool> populatePicker()
        {
            try
            {
                //Pulling a list by country names

                listOfCountries = root.data.Select(data => data.name).ToList();


                pickerYourLocation.ItemsSource = listOfCountries;

                return true;
            }
            catch
            {
                return false;
            }

            

           
        }
    }


}
