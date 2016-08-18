using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using PhoneApp5.Player;
namespace PhoneApp5
{
    public partial class MainPage : PhoneApplicationPage
    {
        public const int COUNT_GOAL = 3;
        public const int MIN_DISTANCE_SWYPE = 55;
        public const int POINT_LEVEL1 = 100;
        public const int POINT_LEVEL2 = 200;
        public const int POINT_LEVEL3 = 300;
        public const int POINT_LEVEL4 = 400;
        public const int POINT_LEVEL5 = 500;
        public const int POINT_LEVEL6 = 600;
        public const int POINT_LEVEL7 = 700;
        public const int POINT_LEVEL8 = 800;
        public const int POINT_LEVEL9 = 900;
        public const int POINT_WIN = 1000;
        public bool FirstSwip = true;
        public Human PlayerHuman = new Human();
        public Phone playerPhone = new Phone();
        public List<Goal> ListGoal = new List<Goal>();
        public Point Start = new Point();
        public Point Finish = new Point();
        public MainPage()
        {
            InitializeComponent();
            ListGoal.Clear();
            Goal.FirstGenerationGoals(ListGoal);
            Goal.GenerationListGoal(ListGoal, PlayerHuman, playerPhone);
            PaintGoal();
            PaintHumanPlayer();
            PaintPhonePlayer();
        }
       
        public void PaintProgresPlayer(object sender, Human human)
        {
            ProgressBarPlayer.Value = human.PointPalyer;
            ProgressBarPlayerTextBlock.Text = $"Points{Convert.ToString(human.PointPalyer)}/1000"; 
        }
        public void PaintProgresPhone(object sender, int point)
        {
            ProgressBarPhoneTextBlock.Text = $"Points{Convert.ToString(point)}/1000"; 
            ProgressBarPhone.Value = point;   
        }
        private void PaintHumanPlayer()
        {
            Grid.SetColumn(PlayerHumanInterface, PlayerHuman.CoordinateX);
            Grid.SetRow(PlayerHumanInterface, PlayerHuman.CoordinateY);
        }
        private void PaintPhonePlayer()
        {
            Grid.SetColumn(PlayerPhoneInterface, playerPhone.CoordinateX);
            Grid.SetRow(PlayerPhoneInterface, playerPhone.CoordinateY);
        }
        public void PaintGoal(object sender = null)
        {
            Grid.SetColumn(GoalInterface_1, ListGoal[0].CoordinateX);
            Grid.SetRow(GoalInterface_1, ListGoal[0].CoordinateY);
            Grid.SetColumn(GoalInterface_2, ListGoal[1].CoordinateX);
            Grid.SetRow(GoalInterface_2, ListGoal[1].CoordinateY);
            Grid.SetColumn(GoalInterface_3, ListGoal[2].CoordinateX);
            Grid.SetRow(GoalInterface_3, ListGoal[2].CoordinateY);
            
            Grid.SetColumn(Weight_Goal_1, ListGoal[0].CoordinateX);
            Grid.SetRow(Weight_Goal_1, ListGoal[0].CoordinateY);
            Weight_Goal_1.Text = Convert.ToString(ListGoal[0].Weight - 1);
            Grid.SetColumn(Weight_Goal_2, ListGoal[1].CoordinateX);
            Grid.SetRow(Weight_Goal_2, ListGoal[1].CoordinateY);
            Weight_Goal_2.Text = Convert.ToString(ListGoal[1].Weight - 1);
            Grid.SetColumn(Weight_Goal_3, ListGoal[2].CoordinateX);
            Grid.SetRow(Weight_Goal_3, ListGoal[2].CoordinateY);
            Weight_Goal_3.Text = Convert.ToString(ListGoal[2].Weight - 1);
        }

        private void LayoutRoot_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Start.X = e.GetPosition(LayoutRoot).X;
            Start.Y = e.GetPosition(LayoutRoot).Y;
        }

        private void LayoutRoot_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Finish.X = e.GetPosition(LayoutRoot).X;
            Finish.Y = e.GetPosition(LayoutRoot).Y;
            
            if((Math.Abs( Math.Abs(Start.Y) - Math.Abs(Finish.Y)) > Math.Abs(Math.Abs(Start.X) - Math.Abs(Finish.X))) &&(Math.Abs(Math.Abs(Start.Y) - Math.Abs(Finish.Y)) > 55 || Math.Abs(Math.Abs(Start.X) - Math.Abs(Finish.X)) > 55) )
            {
                if(Start.Y > Finish.Y)
                {
                    SwypeUp(sender,e);
                }
                else
                {
                    SwypeDown(sender, e);
                }
            }
            else if(Math.Abs(Math.Abs(Start.Y) - Math.Abs(Finish.Y)) >= MIN_DISTANCE_SWYPE || Math.Abs(Math.Abs(Start.X) - Math.Abs(Finish.X)) >= MIN_DISTANCE_SWYPE)
            {
                if (Start.X > Finish.X)
                {
                    SwypeLeft(sender, e);
                }
                else
                {
                    SwypeRight(sender, e);
                }
            }
        }

        public void SwypeRemove(object sender)
        {
            PaintHumanPlayer();
            if (ProgressBarPlayer.Value <= POINT_LEVEL1)
            {
                playerPhone.SearchGoalLevel_1(ListGoal);
                LeveltextBlock.Text = "Level 1";
            }
            else if (ProgressBarPlayer.Value > POINT_LEVEL1 && ProgressBarPlayer.Value <= POINT_LEVEL2)
            {
                playerPhone.SearchGoalLevel_2(ListGoal);
                LeveltextBlock.Text = "Level 2";
            }else if (ProgressBarPlayer.Value > POINT_LEVEL2 && ProgressBarPlayer.Value <= POINT_LEVEL3)
            {
                playerPhone.SearchGoalLevel_3(ListGoal);
                LeveltextBlock.Text = "Level 3";
            }else if (ProgressBarPlayer.Value > POINT_LEVEL3 && ProgressBarPlayer.Value <= POINT_LEVEL4)
            {
                playerPhone.SearchGoalLevel_3(ListGoal);
                LeveltextBlock.Text = "Level 4";
            }
            else if (ProgressBarPlayer.Value > POINT_LEVEL4 && ProgressBarPlayer.Value <= POINT_LEVEL5)
            {
                playerPhone.SearchGoalLevel_1(ListGoal);
                playerPhone.GoToSelectedGoal(ListGoal, PlayerHuman, playerPhone);
                LeveltextBlock.Text = "Level 5";
            }else if (ProgressBarPlayer.Value > POINT_LEVEL5 && ProgressBarPlayer.Value <= POINT_LEVEL6)
            {
                playerPhone.SearchGoalLevel_2(ListGoal);
                playerPhone.GoToSelectedGoal(ListGoal, PlayerHuman, playerPhone);
                LeveltextBlock.Text = "Level 6";
            } else if (ProgressBarPlayer.Value > POINT_LEVEL6 && ProgressBarPlayer.Value <= POINT_LEVEL7)
            {
                playerPhone.SearchGoalLevel_3(ListGoal);
                playerPhone.GoToSelectedGoal(ListGoal, PlayerHuman, playerPhone);
                LeveltextBlock.Text = "Level 7";
            }
            else if (ProgressBarPlayer.Value > POINT_LEVEL7 && ProgressBarPlayer.Value <= POINT_LEVEL8)
            {
                playerPhone.SearchGoalLevel_1(ListGoal);
                playerPhone.GoToSelectedGoal(ListGoal, PlayerHuman, playerPhone);
                LeveltextBlock.Text = "Level 8";
            }
            else if (ProgressBarPlayer.Value > POINT_LEVEL8 && ProgressBarPlayer.Value <= POINT_LEVEL9)
            {
                playerPhone.SearchGoalLevel_3(ListGoal);
                playerPhone.GoToSelectedGoal(ListGoal, PlayerHuman, playerPhone);
                LeveltextBlock.Text = "Level 9";
            }
            else if (ProgressBarPlayer.Value > POINT_LEVEL9 && ProgressBarPlayer.Value <= POINT_WIN)
            {
                playerPhone.SearchGoalLevel_3(ListGoal);
                playerPhone.GoToSelectedGoal(ListGoal, PlayerHuman, playerPhone);
                LeveltextBlock.Text = "Level 10";
            }
            playerPhone.GoToSelectedGoal(ListGoal, PlayerHuman, playerPhone);
            PaintPhonePlayer();
            PaintGoal(sender);         
            PaintProgresPhone(sender, playerPhone.PointPhone);
            PaintProgresPlayer(sender, PlayerHuman);
            if ((ProgressBarPlayer.Value >= POINT_LEVEL3 && ProgressBarPlayer.Value < POINT_LEVEL4) || ProgressBarPlayer.Value >= POINT_LEVEL7  )
            {
                //Phone.Level4(FirstSwip, ListGoal);
                if (!ListGoal[0].FirstVizualiz)
                {
                    Weight_Goal_1.Text = "?";
                }
                if (!ListGoal[1].FirstVizualiz)
                {
                    Weight_Goal_2.Text = "?";
                }
                if (!ListGoal[2].FirstVizualiz)
                {
                    Weight_Goal_3.Text = "?";
                }
                
            }
            if ((ProgressBarPhone.Value - ProgressBarPlayer.Value) > 100)
            {
                NavigationService.Navigate(new Uri("/GameOver.xaml", UriKind.Relative));
            }
            if (ProgressBarPlayer.Value >= POINT_WIN)
            {
                NavigationService.Navigate(new Uri("/Win.xaml", UriKind.Relative));
            }
            Goal.MinusWeight(ListGoal, PlayerHuman, playerPhone);
        }
        private void SwypeLeft(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PlayerHuman.ChangeOfСoordinates(PlayerHuman.CoordinateX - 1, PlayerHuman.CoordinateY, playerPhone,ListGoal);
            SwypeRemove(sender);          
        }
        private void SwypeRight(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PlayerHuman.ChangeOfСoordinates(PlayerHuman.CoordinateX + 1, PlayerHuman.CoordinateY, playerPhone, ListGoal);
            SwypeRemove(sender);
        }
        private void SwypeUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PlayerHuman.ChangeOfСoordinates(PlayerHuman.CoordinateX, PlayerHuman.CoordinateY - 1, playerPhone,ListGoal);
            SwypeRemove(sender);
        }
        private void SwypeDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PlayerHuman.ChangeOfСoordinates(PlayerHuman.CoordinateX, PlayerHuman.CoordinateY + 1, playerPhone,ListGoal);
            SwypeRemove(sender);
        }
    }
}