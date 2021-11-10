using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace CoVidualizer
{
    public partial class YourLocation : ContentPage
    {
        


        public YourLocation()
        {
            
            InitializeComponent();

            labelYourLocationTitle2.Text = Preferences.Get("YourLocation", "Australia");

            

        }

        async void buttonBack2_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                await Navigation.PopModalAsync();
            }
            catch
            {

            }
        }

        async void buttonSeeWorldHotSpots_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                HotLowSpots hotLowSpots = new HotLowSpots();

                await Navigation.PushModalAsync(hotLowSpots);


                //Need to add in populate Hot Spot Low Spot Page data 


            }
            catch
            {

            }
        }

        public async Task<bool> populateCountryData(Models.Country yourLocationData)
        {
            try
            {
                //Assume that if there's zero then data has not been entered for that day yet

                if (yourLocationData.totalConfirmed != 0)
                {
                    labelTotalCasesAmount.Text = yourLocationData.totalConfirmed.ToString("#,##0");
                }
                else
                {
                    labelTotalCasesAmount.Text = "No data yet today";
                }


                if (yourLocationData.totalDeaths != 0)
                {
                    labelTotalDeathsAmount.Text = yourLocationData.totalDeaths.ToString("#,##0");
                }
                else
                {
                    labelTotalDeathsAmount.Text = "No data yet today";
                }


                if (yourLocationData.todaysConfirmed != 0)
                {
                    labelTodaysCasesAmount.Text = yourLocationData.todaysConfirmed.ToString("#,##0");
                }
                else
                {
                    labelTodaysCasesAmount.Text = "No data yet today";
                }



                if (yourLocationData.todaysDeaths != 0)
                {
                    labelTodaysDeathsAmount.Text = yourLocationData.todaysDeaths.ToString("#,##0");
                }
                else
                {
                    labelTodaysDeathsAmount.Text = "No data yet today";
                }


                if (yourLocationData.death_rate != 0)
                {
                    decimal recoveryRate = (decimal)yourLocationData.death_rate;

                    labelRecoveryRateAmount.Text = $" {Math.Round(recoveryRate,2).ToString()}%";
                }
                else
                {
                    labelRecoveryRateAmount.Text = "No data yet today";
                }


                if (yourLocationData.recovery_rate != 0)
                {
                    decimal deathRate = (decimal)yourLocationData.recovery_rate;
                    labelDeathRateAmount.Text = $" {Math.Round(deathRate, 2).ToString()}%";
                }
                else
                {
                    labelDeathRateAmount.Text = "No data yet today";
                }



                return true;
            }
            catch
            {
                await DisplayAlert("An issue has arisen with the data for this country", " ", "OK");

                return false; 
            }

            
        }
    }
}
