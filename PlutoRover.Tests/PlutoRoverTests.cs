using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using PlutoRover.Domain;
using PlutoRover.Domain.Commands;

namespace PlutoRover.Tests
{
    public class PlutoRoverTests
    {
        [Fact]
        public void Given_A_Rover_at_00_then_Move_To_22_Facing_East()
        {
            //Arrange
            var planet = new Planet("Pluto", 100, 100);
            var coordinates = new Coordinates(0, 0);
            var direction = new Direction();
            var command = new MoveForwardCommand();
            var sut = new Rover(planet, coordinates, direction);
            //Act
            sut.Run("FFRFF");
            var actualResult = sut.CurrentLocation();
            //Assert
            Assert.Equal("2,2 facing East", actualResult);
        }
        [Fact]
        public void Given_A_New_Rover_When_Placed_On_Planet_Current_Location_Returns_00_Facing_North()
        {
            //Arrange
            var planet = new Planet("Pluto", 100, 100);
            var coordinates = new Coordinates(0, 10);
            var direction = new Direction();
            var sut = new Rover(planet, coordinates, direction);
            //Act           
            var actualResult = sut.CurrentLocation();
            //Assert
            Assert.Equal("0,10 facing North", actualResult);
        }

        [Fact]
        public void Given_A_New_Rover_When_given_Command_F_Current_Location_Returns_01_Facing_North()
        {
            //Arrange
            var planet = new Planet("Pluto", 100, 100);
            var coordinates = new Coordinates(0, 0);
            var direction = new Direction();
            var sut = new Rover(planet, coordinates, direction);
            //Act 
            sut.Run("F");
            var actualResult = sut.CurrentLocation();
            //Assert
            Assert.Equal("0,1 facing North", actualResult);
        }
        [Fact]
        public void Given_A_New_Command_when_rover_is_at_the_edge_of_grid_it_will_wrap()
        {
            //Arrange
            var planet = new Planet("Pluto", 100, 100);
            var coordinates = new Coordinates(0, 100);
            var direction = new Direction();
            var sut = new Rover(planet, coordinates, direction);
            //Act 
            sut.Run("F");
            var actualResult = sut.CurrentLocation();
            //Assert
            Assert.Equal("0,0 facing North", actualResult);
        }
        [Fact]
        public void Given_A_New_Command_when_rover_encounters_an_obstacle_it_moves_to_the_last_Possible_Point()
        {
            // Arrange
            var planet = new Planet("Pluto", 100, 100);
            planet.AddObstacle(0, 2);
            var coordinates = new Coordinates(0, 1);
            var direction = new Direction();
            var sut = new Rover(planet, coordinates, direction);
            //Act 
            sut.Run("FFFFF");
            var actualResult = sut.CurrentLocation();
            //Assert
            Assert.Equal("0,1 facing North, Obstacle found:0,2", actualResult);
        }


    }
}
