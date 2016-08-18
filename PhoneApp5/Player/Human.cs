using System.Collections.Generic;

namespace PhoneApp5.Player
{

    public class Human
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public int PointPalyer { get; set; }
        private const int LEFT_MAP = 0;
        private const int RIGTH_MAP = 11;
        private const int TOP_MAP = 0;
        private const int BOTTOM_MAP = 11;
        private const int START_POSITION_X = 10;
        private const int START_POSITION_Y = 1;
        private const int START_POINT = 0;
        public Human()
        {
            CoordinateY = START_POSITION_Y;
            CoordinateX = START_POSITION_X;
            PointPalyer = START_POINT;
        }
        public void ChangeOfСoordinates(int NewX, int NewY, Phone Phone, List<Goal> listgooal)
        {
            if (IsCoordinateСorrect(NewX, NewY, Phone.CoordinateX, Phone.CoordinateY))
            {
                this.CoordinateX = NewX;
                this.CoordinateY = NewY;
                for(int i = 0; i < listgooal.Count; i++)
                {
                    if (listgooal[i].CoordinateX == NewX && listgooal[i].CoordinateY == NewY)
                    {
                        
                        PointPalyer += listgooal[i].Weight;
                        Goal.GenerationGoal(i, this, Phone, listgooal);
                        break;
                    }
                }
                
            }
        } 
        public bool IsCoordinateСorrect(int X, int Y, int XPhone, int YPhone)
        {
            if (X == LEFT_MAP || Y == TOP_MAP || X == RIGTH_MAP || Y == BOTTOM_MAP )
            {
                return false;
            }
            return true;
        }
    }
}
