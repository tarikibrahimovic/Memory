using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace memorijaIspit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Increment { get; set; }
        public int Semafor { get; set; }
        public string TbVrednost1 { get; set; }
        public string TbVrednost2 { get; set; }
        DispatcherTimer dt = new DispatcherTimer();
        public int Poeni { get; set; }
        public int Prosli { get; set; }
        public int Start { get; set; }

        List<string> Nazivi { get; set; }
        List<char> Vrednosti { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            dt.Interval = TimeSpan.FromSeconds(1);
            Nazivi = new List<string>();
            Vrednosti = new List<char>();
            Semafor = 0;
            Poeni = 0;
            dt.Tick += Dt_Tick;

            Vrednosti.Add('a');
            Vrednosti.Add('a');

            Vrednosti.Add('b');
            Vrednosti.Add('b');

            Vrednosti.Add('c');
            Vrednosti.Add('c');

            Vrednosti.Add('d');
            Vrednosti.Add('d');

            Vrednosti.Add('e');
            Vrednosti.Add('e');

            Vrednosti.Add('f');
            Vrednosti.Add('f');

            Vrednosti.Add('g');
            Vrednosti.Add('g');

            Vrednosti.Add('h');
            Vrednosti.Add('h');


            Nazivi.Add("tb11");
            Nazivi.Add("tb12");
            Nazivi.Add("tb13");
            Nazivi.Add("tb14");

            Nazivi.Add("tb21");
            Nazivi.Add("tb22");
            Nazivi.Add("tb23");
            Nazivi.Add("tb24");

            Nazivi.Add("tb31");
            Nazivi.Add("tb32");
            Nazivi.Add("tb33");
            Nazivi.Add("tb34");

            Nazivi.Add("tb41");
            Nazivi.Add("tb42");
            Nazivi.Add("tb43");
            Nazivi.Add("tb44");
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            Increment++;
            brojac.Content = Increment.ToString();
            if (Increment == 60)
            {
                MessageBox.Show("Izgubili ste");
                for (int i = 0; i < Nazivi.Count; i++)
                {
                    TextBlock t = (TextBlock)FindName(Nazivi[i]);
                    t.Text = "?";
                    t.Background = Brushes.White;
                    start.IsEnabled = true;
                    Poeni = 0;
                    Increment = 0;
                }
            }
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            dt.Start();
            Shuffle(Nazivi);
            Start++;
            if (Start != 0)
            {
                Button b = (Button)sender;
                b.IsEnabled = false;
            }
        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
            dt.Stop();
            Increment = 0;
            start.IsEnabled = true;
            end.IsEnabled = false;
        }

        public void Shuffle(List<string> list)
        {
            Random rng = new Random();
            var randomized = list.OrderBy(item => rng.Next());
            Nazivi = randomized.ToList();
        }
        private void tb_Click(object sender, EventArgs e)
        {
            if (Start == 1)
            {
                TextBlock tb = (TextBlock)sender;
                int index = Nazivi.IndexOf(tb.Name);
                if (Semafor < 3)
                {
                    Semafor++;
                    tb.Text = Vrednosti[index].ToString();
                    if (Semafor == 1)
                    {
                        TbVrednost1 = Vrednosti[index].ToString();
                        Prosli = index;
                    }
                    else
                    {
                        TbVrednost2 = Vrednosti[index].ToString();
                    }
                }
                if (Semafor == 2)
                {
                    if (TbVrednost1 == TbVrednost2)
                    {
                        Semafor = 0;
                        Poeni++;
                        tb.Background = Brushes.Green;
                        TextBlock tb2 = (TextBlock)FindName(Nazivi[Prosli]);
                        tb2.Background = Brushes.Green;
                    }
                    else
                    {
                        Semafor = 0;
                        MessageBox.Show("Pogresno");
                        TextBlock tb2 = (TextBlock)FindName(Nazivi[Prosli]);
                        tb2.Text = "?";
                        tb.Text = "?";
                    }
                }
                if (Poeni == 8)
                {
                    for (int i = 0; i < Nazivi.Count; i++)
                    {
                        TextBlock t = (TextBlock)FindName(Nazivi[i]);
                        t.Text = "?";
                        t.Background = Brushes.White;
                        start.IsEnabled = true;
                        Poeni = 0;
                        Increment = 0;
                    }
                    MessageBox.Show("Bravo");
                }
            }
        }
    }
}
