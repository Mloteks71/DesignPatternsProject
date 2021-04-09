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
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        private DBConnection connection;
        private ZTPContext con;
        public MenuPage()
        {
            InitializeComponent();
            
            connection = DBConnection.GetInstance();
  

            /*  int i = 1;
              for (int j = 0; j < 10; j++)
              {
                  Wyniki wyn = new Wyniki();
                  wyn.nick = "us"+i.ToString();
                  wyn.result = i;
                  con.Wyniki.Add(wyn);
                  i++;
                  con.SaveChanges();
              } */
          
        }

        private void Wyniki(object sender, RoutedEventArgs e)
        {
            if (connection.GetContext() == null)
                connection.CreateContext();
            con = connection.GetContext();
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new WynikiPage(con));
        }
        private void NowaGra(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Game(connection));
        }

        private void Wyjście(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void Continue(object sender, RoutedEventArgs e)
        {
            if (connection.GetContext() == null)
                connection.CreateContext();
            con = connection.GetContext();
            if (con.StanGry.ToList().Count >0)
            {
                var load = con.StanGry.First();
                Player player = new PlayerSpaceShip();
                player.setHealthPoints(load.hp);
                player.setMoney(load.money);
                var deko = load.dekorator.Split(',');
                foreach (string s in deko)
                {
                    if (s != null || s != "")
                    {
                        if (s == "ZTPProject.DamageMultiplier")
                        {
                            player = new DamageMultiplier(player);
                        }
                        if (s == "ZTPProject.MoneyMultiplier")
                        {
                            player = new MoneyMultiplier(player);
                        }
                        if (s == "ZTPProject.FlatDamageBonus")
                        {
                            player = new FlatDamageBonus(player);
                        }
                    }
                }
                Difficulty dif;
                string ss = load.difficulty;
                if (load.difficulty == "ZTPProject.Easy")
                {
                    dif = new Normal();
                }
                else
                {
                    dif = new Hard();
                }

                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new Game(connection, load.result, player, dif));
                con.StanGry.Remove(load);
                con.SaveChanges();
            }
        }
    }
}
