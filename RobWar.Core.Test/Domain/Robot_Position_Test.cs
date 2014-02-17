using System.Collections.Generic;
using NUnit.Framework;
using RobWar.Core.Domain;
using RobWar.Core.Models;

namespace RobWar.Core.Test.Domain
{
  [TestFixture]
  public class Robot_Position_Test
  {
    private readonly CoordinatesModel _upperRight = new CoordinatesModel { X = 5, Y = 5 };

    [Test]
    public void LMLMLMLMM_Should_Result_Into_13N()
    {
      var initialPosition = new PositionModel { Orientation = Orientation.N, Coordinates = new CoordinatesModel { X = 1, Y = 2 } };

      var robot = new Robot(initialPosition, _upperRight);

      robot.Move(new List<Instruction>
      {
        Instruction.L, 
        Instruction.M, 
        Instruction.L, 
        Instruction.M, 
        Instruction.L, 
        Instruction.M, 
        Instruction.L, 
        Instruction.M, 
        Instruction.M
      });

      var position = robot.GetPosition();

      Assert.AreEqual(1, position.Coordinates.X);
      Assert.AreEqual(3, position.Coordinates.Y);
      Assert.AreEqual(Orientation.N, position.Orientation);
    }

    [Test]
    public void MMRMMRMRRM_Should_Result_Into_51E()
    {
      var initialPosition = new PositionModel { Orientation = Orientation.E, Coordinates = new CoordinatesModel { X = 3, Y = 3 } };

      var robot = new Robot(initialPosition, _upperRight);

      robot.Move(new List<Instruction>
      {
        Instruction.M, 
        Instruction.M, 
        Instruction.R, 
        Instruction.M, 
        Instruction.M, 
        Instruction.R, 
        Instruction.M, 
        Instruction.R, 
        Instruction.R, 
        Instruction.M
      });

      var position = robot.GetPosition();

      Assert.AreEqual(5, position.Coordinates.X);
      Assert.AreEqual(1, position.Coordinates.Y);
      Assert.AreEqual(Orientation.E, position.Orientation);
    }
  }
}