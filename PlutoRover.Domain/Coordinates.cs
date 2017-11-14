namespace PlutoRover.Domain
{
    public class Coordinates
    {
        private int xCoordinate;
        private int yCoordinate;
      
        public Coordinates(int x, int y )
        {
            xCoordinate = x;
            yCoordinate = y;

        }

        public int XCoordinate
        {
            get
            {
                return xCoordinate;
            }           
        }

        public int YCoordinate
        {
            get
            {
                return yCoordinate;
            }
           
        }
        public override string ToString()
        {
            return string.Format("{0},{1}", this.xCoordinate, this.yCoordinate);
        }
    }
}