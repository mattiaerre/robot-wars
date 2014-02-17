using System.Collections.Generic;
using NUnit.Framework;
using RobWar.Core.Domain;
using RobWar.Core.Models;

namespace RobWar.Core.Test.Domain
{
  [TestFixture]
  public class Robot_Coordinates_Test
  {
    private IRobot _robot;
    private PositionModel _initialPosition;

    [SetUp]
    public void Given_A_Robot()
    {
      _initialPosition = new PositionModel { Orientation = Orientation.N, Coordinates = new CoordinatesModel { X = 1, Y = 1 } };

      _robot = new Robot(_initialPosition, new CoordinatesModel { X = 3, Y = 3 });
    }

    [Test]
    public void M_Should_Move_Into_12()
    {
      _robot.Move(new List<Instruction> { Instruction.M });

      var position = _robot.GetPosition();

      Assert.AreEqual(1, position.Coordinates.X);
      Assert.AreEqual(2, position.Coordinates.Y);
    }

    [Test]
    public void RM_Should_Move_Into_21()
    {
      _robot.Move(new List<Instruction> { Instruction.R, Instruction.M });

      var position = _robot.GetPosition();

      Assert.AreEqual(2, position.Coordinates.X);
      Assert.AreEqual(1, position.Coordinates.Y);
    }

    [Test]
    public void RRM_Should_Move_Into_10()
    {
      _robot.Move(new List<Instruction> { Instruction.R, Instruction.R, Instruction.M });

      var position = _robot.GetPosition();

      Assert.AreEqual(1, position.Coordinates.X);
      Assert.AreEqual(0, position.Coordinates.Y);
    }

    [Test]
    public void RRRM_Should_Move_Into_01()
    {
      _robot.Move(new List<Instruction> { Instruction.R, Instruction.R, Instruction.R, Instruction.M });

      var position = _robot.GetPosition();

      Assert.AreEqual(0, position.Coordinates.X);
      Assert.AreEqual(1, position.Coordinates.Y);
    }
  }
}