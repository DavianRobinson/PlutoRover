using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRover.Domain
{
    public class Planet
    {
      private string _planetName;
        private Coordinates _maxCoordinates = new Coordinates(0, 0);
        private Coordinates _minCoordinates = new Coordinates(0, 0);
        private Dictionary<string, Coordinates> _obstacles = new Dictionary<string, Coordinates>();



        public Planet(string planetName, int maxXCoordinate, int maxYCoordinate)
        {
            _planetName = planetName;
            this._maxCoordinates = new Coordinates(maxXCoordinate, maxYCoordinate);

        }

        public Boolean isWithinBounds(Coordinates coordinates)
        {
            return coordinates.XCoordinate <= this._maxCoordinates.XCoordinate && coordinates.YCoordinate <= this._maxCoordinates.YCoordinate
                   & coordinates.XCoordinate >= this._minCoordinates.XCoordinate & coordinates.YCoordinate >= this._minCoordinates.YCoordinate;
        }
        public Coordinates GetMaxCoordinates()
        { return _maxCoordinates; }
        public Coordinates GetMinCoordinates()
        { return _minCoordinates; }

        public void AddObstacle(int x, int y)
        {
            _obstacles.Add(x.ToString()+y.ToString(), new Coordinates ( x,y));

        }

        public Boolean  hasObstacle(Coordinates coordinate)
        {
            return _obstacles.ContainsKey(coordinate.XCoordinate.ToString() + coordinate.YCoordinate.ToString());

        }
    }
}
