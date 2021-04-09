using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace ZTPProject
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    /// //Width=600
    public partial class Game : Page
    {
        private DispatcherTimer aTimer = new DispatcherTimer();
        private DispatcherTimer bTimer = new DispatcherTimer();
        private DispatcherTimer cTimer = new DispatcherTimer();
        private DispatcherTimer dTimer = new DispatcherTimer();
        private DispatcherTimer eTimer = new DispatcherTimer();
        private short mov;
        private Random rnd = new Random();
        private Image ima1;
        private List<IShot> list = new List<IShot>();
        private int cooldown = 0;
        private List<Image> self = new List<Image>();
        private EnemyList enemys;
        private List<ProxyEnemy> incombat=new List<ProxyEnemy>();
        private ProxyEnemy en;
        private Player player = new PlayerSpaceShip();
        private Difficulty difficulty;
        private EnemySpaceShip[] org=new EnemySpaceShip[5];
        private int buffor;
        private bool isEnemy = false;
        private EnemysIterator iter;
        private double result;
        private int killed;
        private DBConnection connection;
        private int Count;
        public Game(DBConnection connection, double result=0, Player player=null,Difficulty difficulty=null)
        {
            InitializeComponent();
            if(player==null)
            {
                player = new PlayerSpaceShip();
                player.setHealthPoints(20);
            }
            if (difficulty == null) difficulty = new Easy();
            this.result = result;
            this.player = player;
            this.difficulty = difficulty;
            imgspace.ImageSource = this.difficulty.getBackground();
            this.connection = connection;
            SetTimer();
            SetTimer2();
            SetTimer3();
            SetTimer4();
            SetTimer5();
            ima1 = new Image
            {

            };
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri("/Files/MYship.png", UriKind.Relative);
            bi1.EndInit();
            ima1.Source = bi1;
            canvas.Children.Add(ima1);
            double a = canvas.ActualWidth;
            double b = ima1.Width;
            double c = canvas.ActualHeight;
            double d = ima1.Height;
            Canvas.SetLeft(ima1, canvas.Width/2-49);//139
            Canvas.SetTop(ima1, canvas.Height-84);//129
            Loaded += (xx, yy) => Keyboard.Focus(grid);
            player.setMoneyMultiplier(difficulty.getMoneyMultiplier());
            org[0] = new NormalEnemySS();
            set(org[0],1,(int)((double)6*difficulty.getScoreMultiplier()),3,"Enemy1.png",new Szarża(),-1);
            org[1] = new GoodEnemySS();
            set(org[1], 2, (int)((double)6 * difficulty.getScoreMultiplier()), 1, "Enemy2.png", new Nieruchome(),5);
            org[2] = new BetterEnemySS();
            set(org[2], 3, (int)((double)10 * difficulty.getScoreMultiplier()), 2, "Enemy3.png", new Teleportacja(),5);
            org[3] = new BestEnemySS();
            set(org[3], 4, (int)((double)12 * difficulty.getScoreMultiplier()), 3, "Enemy4.png", new PoosiachXY(),5);
            org[4] = new BestestEnemySS();
            set(org[4], 10, (int)((double)144 * difficulty.getScoreMultiplier()), 5, "Boss.png", new PoosiX(),5);
            enemys = difficulty.enemyGenerate(org);
            Count = enemys.Count();
            iter = (EnemysIterator)enemys.CreateIterator();
            xmlhp.Content = player.getHealthPoints();
            xmlmoney.Content = player.getMoney();
            xmlresult.Content = "Wynik: " + result;
        }
        private void set(EnemySpaceShip ss,int Money,int HP, int Damage,string plik,Strategia str,int cd)
        {
            ss.setMoney(Money);
            ss.setHealthPoints(HP);
            ss.setDamage(Damage);
            ss.setImgString("/Files/"+plik);
            ss.setStrategia(str);
            ss.setCD(cd);
         
          
           
        }
        private void SetTimer()
        {
            aTimer.Tick += OnTimedEvent;
        }
        private void SetTimer2()
        {
            bTimer.Tick += OnTimedEvent2;
            bTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            bTimer.Start();
        }
        private void SetTimer3()
        {
            cTimer.Tick += OnTimedEvent3;
            cTimer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            cTimer.Start();
        }
        private void SetTimer4()
        {
            dTimer.Tick += OnTimedEvent4;
            dTimer.Interval = new TimeSpan(0, 0, 0, 0, 40);
            dTimer.Start();
        }
        private void SetTimer5()
        {
            eTimer.Tick += OnTimedEvent5;
            eTimer.Interval=new TimeSpan(0, 0, 0, 0, 500);
            eTimer.Start();
        }
        private void OnTimedEvent5(Object source, EventArgs e)
        {
            for(int i=0;i<incombat.Count;i++)
            {
                if (incombat[i].getEnemySpaceShip().getCD()>0)
                {
                    incombat[i].getEnemySpaceShip().setCD(incombat[i].getEnemySpaceShip().getCD() - 1);
                  
                }
                
                else
                {
                    EnemySpaceShip temp = incombat[i].getEnemySpaceShip();
                    list=incombat[i].getEnemySpaceShip().shoot(list,canvas);
                    incombat[i].getEnemySpaceShip().setCD(5);
                 
                }
            }
        }
        private void startTimer()
        {
            if (aTimer.IsEnabled == false) { aTimer.Interval = new TimeSpan(0); aTimer.Start(); }
        }
        private void stopTimer()
        {
            if (aTimer.IsEnabled == true) aTimer.Stop();
        }
        public void OnTimedEvent(Object source, EventArgs e)
        {
            aTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            if((Canvas.GetLeft(ima1)+5*mov>0&&mov<0)|| (Canvas.GetLeft(ima1) + 5 * mov<canvas.Width-100)&&mov>0)
            Canvas.SetLeft(ima1, Canvas.GetLeft(ima1) + 5 * mov);
        }
        public Boolean check(Image shot, Image target)
        {
            var p1y = Canvas.GetTop(shot);//a
            var p1x = Canvas.GetLeft(shot);//b
            var p2y = shot.ActualHeight + p1y;//c
            var p2x = shot.ActualWidth + p1x;//d
            var pl1y = Canvas.GetTop(target);//e
            var pl1x = Canvas.GetLeft(target);//f
            var pl2y = target.ActualHeight + pl1y;//g
            var pl2x = target.ActualWidth + pl1x;//h
            if (((p1y <= pl2y && p1y >= pl1y) || (p2y <= pl2y && p2y >= pl1y)) && ((p1x <= pl2x && p1x >= pl1x) || (p2x <= pl2x && p2x >= pl1x)))
                return true;
            return false;
        }
        public void OnTimedEvent2(Object source, EventArgs e)
        {
            if (cooldown > 0) cooldown--;
            for (int i = 0; i < self.Count; i++)
            {
                Image im = self[i];
                Canvas.SetTop(im, Canvas.GetTop(im) - 10); 
                for (int j = 0; j < incombat.Count; j++)
                {
                    ProxyEnemy en = incombat[j];
                    Image img = en.getEnemySpaceShip().getImage();
                    if (check(im, img))
                    {

                        canvas.Children.Remove(im);
                        self.Remove(im);
                        int check = 1;
                        if (en.getEnemySpaceShip() is BestEnemySS)
                        {
                            if (((BestEnemySS)en.getEnemySpaceShip()).getShield() == true)
                            {
                                ((BestEnemySS)en.getEnemySpaceShip()).setShield(false); check = 0;
                            }
                        }
                        if (check == 1)
                        {
                            en.getEnemySpaceShip().setHealthPoints(en.getEnemySpaceShip().getHealthPoints() - player.getDamage());
                        }
                        if (en.getEnemySpaceShip().getHealthPoints() <= 0)
                        {
                            incombat.Remove(en);
                            canvas.Children.Remove(en.getEnemySpaceShip().getImage());
                            killed++;
                            player.setMoney(player.getMoney() + en.getEnemySpaceShip().getMoney()  * player.getMoneyMultiplier());
                            result += en.getEnemySpaceShip().getMoney() * difficulty.getScoreMultiplier();
                            xmlresult.Content = "Wynik: " + result;
                            xmlmoney.Content = player.getMoney();

                        }
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                Image im = list[i].getImage();
                
                Metoda check = new Check();
                if((Boolean)list[i].wykonaj(check, canvas,ima1))
                {
                    int ii = player.getHealthPoints();
                    int j = list[i].getDamage();
                    player.setHealthPoints(player.getHealthPoints() - list[i].getDamage());
                    canvas.Children.Remove(list[i].getImage());
                    list.Remove(list[i]);
                    xmlhp.Content = player.getHealthPoints();
                }
                Canvas.SetTop(im, Canvas.GetTop(im) + 10);
            }
        }


        public void OnTimedEvent3(Object source, EventArgs e)
        {
            if (buffor == 0 && isEnemy == false)
            {
                if (iter.hasNext())
                {en = (ProxyEnemy)iter.Next();
                    if(!(en.getEnemySpaceShip() is BestestEnemySS))
                    {
                        en.setX(rnd.Next(0, 6));
                    }
                    else
                    {
                        en.setX(3);
                    }
                    Image ima = new Image
                    {

                    };
                    BitmapImage bi1 = new BitmapImage();
                    bi1.BeginInit();
                    bi1.UriSource = new Uri(en.getEnemySpaceShip().getImgString(), UriKind.Relative);
                    bi1.EndInit();
                    ima.Source = bi1;
                    en.getEnemySpaceShip().setImage(ima);

                    //canvas.Children.Remove(ima);
                    canvas.Children.Add(ima);
                    Canvas.SetLeft(ima, en.getX() * 80);
                    Canvas.SetTop(ima, 0);
                    incombat.Add(en);
                }
                else if (killed == Count)
                {   /// tu if do engame jak jestesmy na hard;
                    
                    this.aTimer.Stop();
                    this.bTimer.Stop();
                    this.cTimer.Stop();
                    this.dTimer.Stop();
                    NavigationService nav = NavigationService.GetNavigationService(this);
                    if(difficulty.getScoreMultiplier()!=2)
                    nav.Navigate(new Shop1(connection,result,player,difficulty));
                    else
                        nav.Navigate(new EndGame(connection, result));
                }
                buffor = 100;
            }
            buffor--;
        
        }

        public void OnTimedEvent4(Object source, EventArgs e)
        {
            var x = canvas.Height;
           
            if (incombat.Count > 0)
            {
                int j = incombat.Count;
                for (int i = j-1; i >=0; i--)
                {
                    incombat[i].porusz();
                    if (incombat[i].getEnemySpaceShip().getMoney() == 1)
                    {
                        Image img = incombat[i].getEnemySpaceShip().getImage();
                        Point p1 = new Point();
                        var p1y = Canvas.GetTop(img);
                        var p1x = Canvas.GetLeft(img);
                        var p2y = img.ActualHeight + p1y;
                        var p2x = img.ActualWidth + p1x;
                        var pl1y = Canvas.GetTop(ima1);
                        var pl1x = Canvas.GetLeft(ima1);
                        var pl2y = ima1.ActualHeight + pl1y;
                        var pl2x = ima1.ActualWidth + pl1x;
                        if (p2y >= pl1y && p1x <= pl2x && p1x >= pl1x || p2y >= pl1y && p2x <= pl2x && p2x >= pl1x)
                        {
                           
                            canvas.Children.Remove(img);
                            killed++;
                            //bez pointow i hajsu
                            player.setHealthPoints(player.getHealthPoints() - incombat[i].getEnemySpaceShip().getDamage());
                            xmlhp.Content = player.getHealthPoints();
                            incombat.Remove(incombat[i]);
                        }
                        if (Canvas.GetTop(img) >= canvas.ActualHeight)
                        {
                            incombat.Remove(incombat[i]);
                            canvas.Children.Remove(img);
                            killed++;
                            
                        }
                    }

                }

                if (player.getHealthPoints() <= 0)
                {
                    NavigationService nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(new Lose(connection, result));
                    this.aTimer.Stop();
                    this.bTimer.Stop();
                    this.cTimer.Stop();
                    this.dTimer.Stop();
                }
            }
        }
        private void KeyEvent(object sender, System.Windows.Input.KeyEventArgs e)
        {

            Keyboard.Focus(grid);
            switch (e.Key)
            {
                case Key.Left:
                    mov = -1;
                    startTimer();
                   
                    break;
                case Key.Right:
                    mov = 1;
                    startTimer();
            
                    break;
                case Key.Up:

                    if (cooldown == 0)
                    {
                        Image ima = new Image
                        {

                        };
                        BitmapImage bi1 = new BitmapImage();
                        bi1.BeginInit();
                        bi1.UriSource = new Uri("/Files/Shot.png", UriKind.Relative);
                        bi1.EndInit();
                        ima.Source = bi1;
                        canvas.Children.Add(ima);
                        Canvas.SetLeft(ima, Canvas.GetLeft(ima1) + 38);
                        Canvas.SetTop(ima, Canvas.GetTop(ima1) - 32);
                        self.Add(ima);
                        cooldown = 10;
                    }
                    break;

            }
        }
        private void KeyEvent2(object sender, System.Windows.Input.KeyEventArgs e)
        {
            stopTimer();
            mov = 0;

        }
     
    }
}
