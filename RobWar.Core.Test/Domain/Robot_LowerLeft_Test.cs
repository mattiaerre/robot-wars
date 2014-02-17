using System.Collections.Generic;
using NUnit.Framework;
using RobWar.Core.Domain;
using RobWar.Core.Models;

namespace RobWar.Core.Test.Domain
{
  [TestFixture]
  public class Robot_LowerLeft_Test
  {
    private IRobot _robot;
    private PositionModel _initialPosition;

    [SetUp]
    public void Given_A_Robot()
    {
      _initialPosition = new PositionModel { Orientation = Orientation.S, Coordinates = new CoordinatesModel { X = 0, Y = 0 } };

      _robot = new Robot(_initialPosition, new CoordinatesModel { X = 3, Y = 3 });
    }

    [Test]
    public void M_Should_Remain_Into_00()
    {
      _robot.Move(new List<Instruction> { Instruction.M });

      var position = _robot.GetPosition();

      Assert.AreEqual(0, position.Coordinates.X);
      Assert.AreEqual(0, position.Coordinates.Y);
    }

    [Test]
    public void RM_Should_Remain_Into_00()
    {
      _robot.Move(new List<Instruction> { Instruction.R, Instruction.M });

      var position = _robot.GetPosition();

      Assert.AreEqual(0, position.Coordinates.X);
      Assert.AreEqual(0, position.Coordinates.Y);
    }
  }
}