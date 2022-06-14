using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WeatherFeed
{
    public partial class Home : Form
    {
        string? _country = string.Empty;
        public Home()
        {
            InitializeComponent();
        }
       

        private async void button1_Click(object sender, EventArgs e)
        {
         HttpResponseMessage response = await   GetWeather(_country,"no", "802f561edce9491685393952222105");

           var result = response.Content.ReadAsStringAsync().Result;
           WeatherFeedModel data = JsonConvert.DeserializeObject<WeatherFeedModel>(result);
            label7.Text= data.location?.name;
            label8.Text = data.location?.region;
            label9.Text = data.location?.country;
            pictureBox3.LoadAsync("https://cdn.weatherapi.com/weather/64x64/day/113.png");
            label10.Text = data.location?.lat.ToString();
            label11.Text = data.location?.lon.ToString();
            label12.Text = data.location?.tz_id?.ToString();
            label13.Text = data.location?.localtime.ToString();
            label14.Text = data.current?.temp_f.ToString();
            label15.Text = data.current?.temp_c.ToString();
            label22.Text = data.current?.condition?.text?.ToString();
            label24.Text = data.current?.last_updated.ToString();
            label6.Text= comboBox1.SelectedValue.ToString();
            label3.Text= data.current?.condition?.text?.ToString();





        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
          
            Application.Exit();
            
        }


        private async Task<HttpResponseMessage> GetWeather(string city, string aqi , string apiKey)
        {

            HttpClient client = new HttpClient();

            // Put the following code where you want to initialize the class
            // It can be the static constructor or a one-time initializer
            client.BaseAddress = new Uri("https://api.weatherapi.com/v1/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync($"current.json?key={apiKey}&q={city}&aqi={aqi}");

            return response;

        }
        private async Task <HttpResponseMessage> GetCountries()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://restcountries.com/v3.1/all"),

            };
            var response = await client.SendAsync(request);
            
                response.EnsureSuccessStatusCode();
                response.EnsureSuccessStatusCode();
           
                
            return response;
        }

        private async void Home_Load(object sender, EventArgs e)
        {
             HttpResponseMessage response = await GetCountries();
              var result = response.Content.ReadAsStringAsync().Result;
            List<Countries> data = JsonConvert.DeserializeObject<List<Countries>>(result);
            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "common";
            comboBox1.ValueMember = "common";
     

           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

           _country= (sender != null )? ((ComboBox)sender).SelectedValue.ToString() : string.Empty;
        }
    }
}
