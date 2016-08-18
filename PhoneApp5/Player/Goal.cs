using System;
using System.Collections.Generic;
using static System.Math;
namespace PhoneApp5.Player
{

    public class Goal
    {
        public static Random rand = new Random();
        private Guid ID { get; set; }
        private int CountGoal { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public int Weight { get; set; }
        public int WeightForPhone { get; set; }
        public bool FirstVizualiz { get; set; }
        private const int LEFT_MAP = 1;
        private const int RIGTH_MAP = 11;
        private const int TOP_MAP = 1;
        private const int BOTTOM_MAP = 11;
        private const int MIN_WEIGHT_GOAL = 5;
        private const int MAX_WEIGHT_GOAL =25;
        private const int COUNT_GOAL = 3;
        private const int MIN_DISTANSE_GOAL = 1;
        public static void FirstGenerationGoals(List<Goal> ListGoal)
        {
            for (int i = 0; i < COUNT_GOAL; i++)
            {
                Goal ElementListGoal = new Goal();
                ListGoal.Add(ElementListGoal);
            }
        }
        public static void GenerationGoal(int goalindex, Human playerhuman, Phone phoneplayer, List<Goal> ListGoals)
        {
            while (true)
            {
                int NewX = rand.Next(LEFT_MAP,RIGTH_MAP);
                int NewY = rand.Next(TOP_MAP,BOTTOM_MAP);
                if (IsGoalСorrect(NewX, NewY, ListGoals, playerhuman, phoneplayer))
                {
                    ListGoals[goalindex].CoordinateX = NewX;
                    ListGoals[goalindex].CoordinateY = NewY;
                    ListGoals[goalindex].Weight = rand.Next(MIN_WEIGHT_GOAL, MAX_WEIGHT_GOAL);
                    ListGoals[goalindex].WeightForPhone = ListGoals[goalindex].Weight - Abs(NewX - phoneplayer.CoordinateX) + Abs(NewY - phoneplayer.CoordinateY);
                    ListGoals[goalindex].FirstVizualiz = true;
                    break;
                }
            }
        }

        public static void GenerationListGoal(List<Goal> ListGoals, Human playerhuman, Phone phoneplayer)
        {
            int i = 0;
            while (true)
            {
                int NewX = rand.Next(LEFT_MAP,RIGTH_MAP);
                int NewY = rand.Next(TOP_MAP,BOTTOM_MAP);
                if (IsGoalСorrect(NewX,NewY,ListGoals,playerhuman,phoneplayer))
                {
                    ListGoals[i].CoordinateX = NewX;
                    ListGoals[i].CoordinateY = NewY;
                    ListGoals[i].Weight = rand.Next(MIN_WEIGHT_GOAL, MAX_WEIGHT_GOAL);
                    ListGoals[i].WeightForPhone = ListGoals[i].Weight - Abs(NewX - phoneplayer.CoordinateX) + Abs(NewY - phoneplayer.CoordinateY);
                    ListGoals[i].FirstVizualiz = true;
                    i++;
                }
                if (i == COUNT_GOAL) break;
            }
        }
        public static bool  IsGoalСorrect(int X, int Y, List<Goal> ListGoals, Human playerhuman, Phone phoneplayer)
        {
            for(int i = 0; i < ListGoals.Count; i++)
            {
                if (!(Abs(X - ListGoals[i].CoordinateX) >= MIN_DISTANSE_GOAL && Abs(Y - ListGoals[i].CoordinateY) >= MIN_DISTANSE_GOAL && Abs(X - playerhuman.CoordinateX) >= MIN_DISTANSE_GOAL && Abs(Y - playerhuman.CoordinateY) >= MIN_DISTANSE_GOAL && Abs(X - phoneplayer.CoordinateX) >= MIN_DISTANSE_GOAL && Abs(Y - phoneplayer.CoordinateY) >= MIN_DISTANSE_GOAL))
                {
                    return false;
                }
            }
            return true;
        }
        public static void MinusWeight(List<Goal> listgoal, Human player, Phone phone)
        {
            for(int i = 0; i < listgoal.Count; i++)
            {
                listgoal[i].Weight--;
                listgoal[i].FirstVizualiz = false;
                if(listgoal[i].Weight == 0)
                {
                    GenerationGoal(i, player, phone, listgoal);
                }
            }
        }
    }
}
