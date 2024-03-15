using IndividuellUppgift.Models;
using IndividuellUppgift.ViewModels;


namespace IndividuellUppgift
{

    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            var singletonInstance = CityEntrySingleton.GetCityAsync();
            if(singletonInstance.SearchCity != null)
            {
               weatherEntry.Text = singletonInstance.SearchCity;
            }
        }

        private async void OnUniversalClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.UniversalPage());
        }

        private async void OnTextChangedCity(object sender, TextChangedEventArgs e)
        {
            cityLabel.Text = e.NewTextValue;
            temperatureLabel.Text = ""; 
        }

        private async void OnClickedGetWeather(object sender, EventArgs e)
        {
            var singletonInstance = CityEntrySingleton.GetCityAsync();
            string city = weatherEntry.Text;
            singletonInstance.SearchCity = city;

            

            if (!string.IsNullOrWhiteSpace(city))
            {
                Models.Weather weather = await WeatherViewModel.GetWeatherAsync(city);
                if (weather != null)
                {
                    temperatureLabel.Text = $"Temperature: {weather.Temperature:F1}°C";
                }
                else
                {
                    temperatureLabel.Text = "Failed to fetch weather data.";
                }
            }
            if (!string.IsNullOrWhiteSpace(city))
            {
                Models.Weather weather = await WeatherViewModel.GetWeatherAsync(city);
                if (weather !=null && weather.Temperature > 15 )
                {
                    ColdOrWarm.Text = "It might be warm outside, have you considered going out and in the sun instead of sitting inside and play games?";
                }
                else if (weather != null && weather.Temperature < 15 )
                {
                    ColdOrWarm.Text = "It's cold today, you can stay inside and play some games :)";
                }
                else if (weather == null)
                {
                    ColdOrWarm.Text = "Failed to fetch weather data.";
                }
            }
        }

        private async void OnResourceClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.ResourcePage());
        }


        private void OnMaterialClicked(object sender, EventArgs e)
        {

        }
    }

}
