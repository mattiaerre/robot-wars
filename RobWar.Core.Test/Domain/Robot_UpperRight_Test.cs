using System.Collections.Generic;
using NUnit.Framework;
using RobWar.Core.Domain;
using RobWar.Core.Models;

namespace RobWar.Core.Test.Domain
{
  [TestFixture]
  public class Robot_UpperRight_Test
  {
    private IRobot _robot;
    private PositionModel _initialPosition;
    private readonly CoordinatesModel _upperRight = new CoordinatesModel{ X = 3, Y = 3};

    [SetUp]
    public void Given_A_Robot()
    {
      _initialPosition = new PositionModel { Orientation = Orientation.N, Coordinates = new CoordinatesModel { X = _upperRight.X, Y = _upperRight.Y } };

      _robot = new Robot(_initialPosition, _upperRight);
    }

    [Test]
    public void M_Should_Remain_Into_33()
    {
      _robot.Move(new List<Instruction> { Instruction.M });

      var position = _robot.GetPosition();

      Assert.AreEqual(_upperRight.X, position.Coordinates.X);
      Assert.AreEqual(_upperRight.Y, position.Coordinates.Y);
    }

    [Test]
    public void RM_Should_Remain_Into_33()
    {
      _robot.Move(new List<Instruction> { Instruction.R, Instruction.M });

      var position = _robot.GetPosition();

      Assert.AreEqual(_upperRight.X, position.Coordinates.X);
      Assert.AreEqual(_upperRight.Y, position.Coordinates.Y);
    }
  }
}