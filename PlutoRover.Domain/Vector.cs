using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRover.Domain
{
    public class Vector
    {
        private Coordinates _coordinates;
        private Direction _direction;
        private Planet _planet;
        private const int  STEP= 1;
        private string _message = String.Empty;
        public Vector(Coordinates coordinates,Direction direction,Planet planet)
        {
            _coordinates = coordinates;
            _direction = direction;
            _planet = planet;
            
        }

        public void MoveForward()
        {
            Coordinates finalPosition = new Coordinates(0, 0);
            switch (_direction)
            {
             
                case Direction.North:
                    finalPosition = new Coordinates
                (
                   _coordinates.XCoordinate,
                    _coordinates.YCoordinate + STEP
                );
                    if (_planet.hasObstacle(finalPosition))
                    {
                        _message = string.Format(", Obstacle found:{0}", finalPosition.ToString());
                    }
                    else
                    {
                        if (_planet.isWithinBounds(finalPosition))
                        {
                            _coordinates = finalPosition;
                        }
                        else
                        {
                            finalPosition = new Coordinates(_coordinates.XCoordinate, _planet.GetMinCoordinates().YCoordinate);
                            _coordinates = finalPosition;
                        };
                    }
                    
                    break;
                case Direction.South:
                    finalPosition = new Coordinates
                  (
                     _coordinates.XCoordinate,
                      _coordinates.YCoordinate - STEP
                  );
                    if (_planet.isWithinBounds(finalPosition))
                    {
                        _coordinates = finalPosition;
                    }
                    else
                    {
                        finalPosition = new Coordinates(_coordinates.XCoordinate, _planet.GetMaxCoordinates().YCoordinate);
                        _coordinates = finalPosition;
                    };
                    break;
                case Direction.East:
                    finalPosition = new Coordinates
               (
                  _coordinates.XCoordinate + 1,
                   _coordinates.YCoordinate
               );
                    if (_planet.isWithinBounds(finalPosition))
                    {
                        _coordinates = finalPosition;
                    };
                    break;
                case Direction.West:
                    finalPosition = new Coordinates
                  (
                      _coordinates.XCoordinate - STEP,
                    _coordinates.YCoordinate
                );
                    if (_planet.isWithinBounds(finalPosition))
                    {
                        _coordinates = finalPosition;
                    };
                    break;
                default:
                    break;
            }
        }

        public void MoveBackwards()
        {
            Coordinates finalPosition = new Coordinates(0, 0);
            switch (_direction)
            {
                case Direction.North:
                    finalPosition = new Coordinates
                (
                   _coordinates.XCoordinate,
                    _coordinates.YCoordinate - STEP
                );
                    if (_planet.isWithinBounds(finalPosition))
                    {
                        _coordinates = finalPosition;
                    };
                    break;
                case Direction.South:
                    finalPosition = new Coordinates
                  (
                     _coordinates.XCoordinate,
                      _coordinates.YCoordinate + STEP
                  );
                    if (_planet.isWithinBounds(finalPosition))
                    {
                        _coordinates = finalPosition;
                    };
                    break;
                case Direction.East:
                    finalPosition = new Coordinates
               (
                  _coordinates.XCoordinate - 1,
                   _coordinates.YCoordinate
               );
                    if (_planet.isWithinBounds(finalPosition))
                    {
                        _coordinates = finalPosition;
                    };
                    break;
                case Direction.West:
                    finalPosition = new Coordinates
                  (
                      _coordinates.XCoordinate + STEP,
                    _coordinates.YCoordinate
                );
                    if (_planet.isWithinBounds(finalPosition))
                    {
                        _coordinates = finalPosition;
                    };
                    break;
                default:
                    break;
            }

        }

        public void TurnRight()
        {
            switch (_direction)
            {
                case Direction.North:
                    _direction = Direction.East;
                    break;
                case Direction.South:
                    _direction = Direction.West;
                    break;
                case Direction.East:
                    _direction = Direction.South;
                    break;
                case Direction.West:
                    _direction = Direction.North;
                    break;
                default:
                    break;
            }
        }

       
        public void TurnLeft()
        {
            switch (_direction)
            {
                case Direction.North:
                    _direction = Direction.West;
                    break;
                case Direction.South:
                    _direction = Direction.East;
                    break;
                case Direction.East:
                    _direction = Direction.North;
                    break;
                case Direction.West:
                    _direction = Direction.South;
                    break;
                default:
                    break;
            }
        }
        public string CurrentLocation()
        {
            return string.Format("{0} facing {1}{2}", _coordinates.ToString(), _direction.ToString(), _message);  
        }
    }
}
