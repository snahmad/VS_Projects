using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = new WebClient();
            var content = client.DownloadString("http://192.168.4.1/load_data_servers_config");

            
        }
        public class DataServer
        {
            public int id { get; set; }

            public bool enable { get; set; }

            public string network_protocol { get; set; }


            public int data_direction { get; set; }


            public string data_protocol { get; set; }

            public string Port { get; set; }
        }
        public class ServerConfig
        {
            [JsonProperty("data_servers")]
            public List<DataServer> Servers = null;
        }
        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:8080/load_data_servers_config");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();


                var config = JsonConvert.DeserializeObject<ServerConfig>(responseBody);

                this.dataGrid.ItemsSource = config.Servers;
                
                this.dataGrid.Items.Refresh();

                



            }
            catch (HttpRequestException exp)
            {
                //MessageBox.Show(exp.Message);
            }
        }

        private async void Button2_Click(object sender, RoutedEventArgs e)
        {
            int i = 1;
            this.progress.Value = 1;

            var long_running_task = Task.Run(() =>
            {
                for (i=1; i < int.MaxValue; i ++);

            });

            Task UITask = long_running_task.ContinueWith(t =>
            {
                Dispatcher.Invoke(() =>
                {
                    this.progress.Value = 100;
                });
            });

            UITask.ContinueWith(t =>
            {
                Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("complete");
                });
            });
        }

        

    }
}
