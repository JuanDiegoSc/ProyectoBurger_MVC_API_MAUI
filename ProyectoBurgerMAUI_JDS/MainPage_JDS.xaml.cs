using Newtonsoft.Json;
using ProyectoBurgerMAUI_JDS.Models;
namespace ProyectoBurgerMAUI_JDS
{
    public partial class MainPage : ContentPage
    {
        //int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked_JDS(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7271/api/");
            var response = client.GetAsync("burger").Result;
            if (response.IsSuccessStatusCode)
            {
                var burgers = response.Content.ReadAsStringAsync().Result;
                var burgersList = JsonConvert.DeserializeObject<List<Burger_JDS>>(burgers);
                listView_JDS.ItemsSource = burgersList;
            }
        }
    }

}
