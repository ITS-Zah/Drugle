using System.Collections.Generic;
namespace PhoneApp5.Player
{
    public class Phone
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public int InedexSelectGoal { get; set; }
        public int PointPhone { get; set; }
        private const int LEFT_MAP = 0;
        private const int RIGTH_MAP = 11;
        private const int TOP_MAP = 0;
        private const int BOTTOM_MAP = 11;
        private const int START_POSITION_X = 1;
        private const int START_POSITION_Y = 10;
        private const int START_POINT = 0;
        public Phone()
        {
            CoordinateY = START_POSITION_Y;
            CoordinateX = START_POSITION_X;
            PointPhone = START_POINT;
        }
        public void ChangeOfСoordinates(int NewX, int NewY, Human human, List<Goal> listgooal, Phone phone)
        {
            if (IsCoordinateСorrect(NewX, NewY, human.CoordinateX, human.CoordinateY))
            {
                phone.CoordinateX = NewX;
                phone.CoordinateY = NewY;
                    for (int i = 0; i < listgooal.Count; i++)
                    {
                        if (listgooal[i].CoordinateX == NewX && listgooal[i].CoordinateY == NewY)
                        {
                            PointPhone += listgooal[i].Weight;
                            Goal.GenerationGoal(i, human, this, listgooal);
                            listgooal[i].FirstVizualiz = true;
                            break;
                        }
                    }
                
            }
        }
        public bool IsCoordinateСorrect(int X, int Y, int XHuman, int YHuman)
        {
            if (X == LEFT_MAP || Y == TOP_MAP || X == RIGTH_MAP || Y == BOTTOM_MAP)
            {
                return false;
            }
            return true;
        }
        public void SearchGoalLevel_1(List<Goal> listgoal)
        {
            int max = -1;
            for (int i = 0; i < listgoal.Count; i++)
            {
                if (listgoal[i].Weight > max)
                {
                    max = listgoal[i].Weight;
                    InedexSelectGoal = i;
                }
            }
        }
        public void SearchGoalLevel_2(List<Goal> listgoal)
        {
            InedexSelectGoal = 0;    
        }
        public void SearchGoalLevel_3(List<Goal> listgoal)
        {
            double max = -1;
            for (int i = 0; i < listgoal.Count; i++)
            {
                if (listgoal[i].WeightForPhone > max)
                {
                    InedexSelectGoal = i;
                    max = listgoal[i].WeightForPhone;
                }
            }
        }

        public static void Level4(bool IsFirstSwype,List<Goal> ListGoal)
        {
            if (IsFirstSwype)
            {
                IsFirstSwype = false;
                ListGoal[0].FirstVizualiz = false;
                ListGoal[1].FirstVizualiz = false;
                ListGoal[2].FirstVizualiz = false;
            }
        }
        public void GoToSelectedGoal(List<Goal> listgoal, Human human, Phone phone)
        {
            if(listgoal[InedexSelectGoal].CoordinateX > CoordinateX)
            {
                ChangeOfСoordinates(++CoordinateX, CoordinateY, human, listgoal, phone);
            }else
            if (listgoal[InedexSelectGoal].CoordinateX < CoordinateX)
            {
                ChangeOfСoordinates(--CoordinateX, CoordinateY, human, listgoal, phone);
            }
            else
            if (listgoal[InedexSelectGoal].CoordinateY > CoordinateY)
            {
                ChangeOfСoordinates(CoordinateX, ++CoordinateY, human, listgoal, phone);
            }
            else
            if (listgoal[InedexSelectGoal].CoordinateY < CoordinateY)
            {
                ChangeOfСoordinates(CoordinateX, --CoordinateY, human, listgoal, phone);
            }
        }
    }
}
