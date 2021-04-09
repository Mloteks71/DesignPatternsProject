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
    /// Interaction logic for Shop1.xaml
    /// </summary>
    public partial class Shop1 : Page
    {
        ZTPContext context;
        double result;
        DBConnection connection;
        Player player;
        Difficulty difficulty;
        public Shop1(DBConnection connection, double result,Player player,Difficulty difficulty)
        {
            InitializeComponent();
            if (connection.GetContext() == null)
                connection.CreateContext();
            this.connection = connection;
            this.context = connection.GetContext();
            this.result = result;
            this.player = player;
            this.difficulty = difficulty;
            Mon.Content = player.getMoney();
            Res.Content = "Twój Wynik: " + result.ToString();
            Hp.Content = player.getHealthPoints();
        }

    

        private void Save(object sender, RoutedEventArgs e)
        {
            StanGry save = new StanGry();
            save.hp = player.getHealthPoints();
            save.money = player.getMoney();
            save.result = result;
            List<String> s=new List<String>();
            while(!(player is PlayerSpaceShip)) 
                { 
                s.Add(player.GetType().ToString()); 
                player = player.getPlayer(); 
                }
            String deko="";
            for (int i=s.Count-1; i >=0; i--){
                deko += s[i]+",";
            }
            save.dekorator = deko;

            save.difficulty = difficulty.GetType().ToString();
            if (context.StanGry.FirstOrDefault() != null) 
            {
                context.StanGry.Remove(context.StanGry.First());
                context.SaveChanges();
            }
            context.StanGry.Add(save);
            context.SaveChanges();
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new MenuPage());
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            if (difficulty is Normal) difficulty = new Hard();
            if (difficulty is Easy) difficulty = new Normal();
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Game(connection,result,player,difficulty));
        }

        private void Dmg(object sender, RoutedEventArgs e)
        {
            if (player.getMoney() >= 10)
            {
                player.setMoney(player.getMoney() - 10);
                player = new FlatDamageBonus(player);
                Mon.Content = player.getMoney();
            }
        }

        private void DmgProcent(object sender, RoutedEventArgs e)
        {
            if (player.getMoney() >= 15)
            {
                player.setMoney(player.getMoney() - 15);
                player = new DamageMultiplier(player);
                Mon.Content = player.getMoney();
            }
        }

        private void Money(object sender, RoutedEventArgs e)
        {
            if (player.getMoney() >= 20)
            {
                player.setMoney(player.getMoney() - 20);
                player = new MoneyMultiplier(player);
                Mon.Content = player.getMoney();
            }
        }
    }
}
