using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;


namespace CoVidualizer
{
    public partial class HotLowSpots : ContentPage
    {
        


        public HotLowSpots()
        {
            InitializeComponent();

            
        }

        async void buttonBack3_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                await Navigation.PopModalAsync();
            }
            catch
            {

            }
        }

        


        //Filling based on the preference "YourLocation". The default is Australia
        public async Task<bool> populateYourLocationUI(Models.Country yourLocation)
        {

            labelYourLocationTitle2.Text = yourLocation.name;

            //Assume that if 0 cases per million then there must not be data recorded at this time

            if (yourLocation.cases_per_million_population <=0 )
            {
                labelYLCasesPerMillionAmount.Text = "No data provided at this time";
            }
            else
            {
                labelYLCasesPerMillionAmount.Text = $" {yourLocation.cases_per_million_population.ToString("#,##0")} cases per million";

            }

            return true;

        }

        public async Task<bool> populateHotSpotUI(List<Models.Country> listOfHotSpots)
        {
            try
            {
                foreach (Models.Country country in listOfHotSpots)
                {
                    //Create vertical stack
                    StackLayout stack = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                    };


                    //Set up smaller stack for data

                    Label labelHotCountry = new Label()
                    {
                        Text = $"{country.name}",
                        HorizontalOptions = LayoutOptions.EndAndExpand,
                        TextColor = Color.DarkRed,
                    };
                    stack.Children.Add(labelHotCountry);

                    Label labelHotCountryCPM = new Label()
                    {
                        Text = $"{country.cases_per_million_population.ToString("#,##0")} cases per million",
                        HorizontalOptions = LayoutOptions.EndAndExpand,
                        TextColor = Color.DarkRed,
                    };
                    stack.Children.Add(labelHotCountryCPM);

                    //For each object in the list create the horizontal stack and add to main vertical stack
                    stackViewHotSpot.Children.Add(stack);

                }

                


                return true;
            }
            catch
            {
                return false;
            }
            


        }

        public async Task<bool> populateLowSpotsUI(List<Models.Country> listOfLowSpots)
        {

            List<Models.Country> threeLowSpots = new List<Models.Country>();

            try
            {
                for (int i = 0; i < 3; i++)
                {
                    threeLowSpots.Add(listOfLowSpots[i]);
                }


                foreach (Models.Country country in threeLowSpots)
                {
                    //Create vertical stack
                    StackLayout stack = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                    };


                    //Set up smaller stack for data

                    Label labelLowCountry = new Label()
                    {
                        Text = $"{country.name}",
                        HorizontalOptions = LayoutOptions.EndAndExpand,
                        TextColor = Color.DarkBlue,
                    };
                    stack.Children.Add(labelLowCountry);

                    Label labelLowCountryCPM = new Label()
                    {
                        Text = $"{country.cases_per_million_population.ToString("#,##0")} case per million",
                        HorizontalOptions = LayoutOptions.EndAndExpand,
                        TextColor = Color.DarkBlue,
                    };
                    stack.Children.Add(labelLowCountryCPM);


                    //For each object in the list create the horizontal stack and add to main vertical stack
                    stackViewLowSpot.Children.Add(stack);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
