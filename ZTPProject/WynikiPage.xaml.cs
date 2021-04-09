using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZTPProject
{
    /// <summary>
    /// Interaction logic for WynikiPage.xaml
    /// </summary>
    public partial class WynikiPage : Page
    {
        private List<Wyniki> Wyniki;
        public WynikiPage(ZTPContext context)
        {
            InitializeComponent();
            var NotSortedWyniki = context.Wyniki.ToList();
            Wyniki = NotSortedWyniki.OrderByDescending(x => x.result).ToList();
            string Results="";
            int i = 1;
            foreach(Wyniki x in Wyniki)
            {
                Results += i.ToString() + ". " + x.result.ToString()+" "+x.nick + Environment.NewLine;
                i++;
                if (i == 11)
                    break;
            }
            results.Text = Results;

        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);

            nav.Navigate(new MenuPage());
        }
    }
}
