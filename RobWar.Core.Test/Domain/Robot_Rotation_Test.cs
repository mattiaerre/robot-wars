using System.Collections.Generic;
using NUnit.Framework;
using RobWar.Core.Domain;
using RobWar.Core.Models;

namespace RobWar.Core.Test.Domain
{
  [TestFixture]
  public class Robot_Rotation_Test
  {
    private IRobot _robot;
    private PositionModel _initialPosition;

    [SetUp]
    public void Given_A_Robot()
    {
      _initialPosition = new PositionModel { Orientation = Orientation.N };

      _robot = new Robot(_initialPosition, null);
    }

    [Test]
    public void It_Should_Return_Its_Position()
    {
      var position = _robot.GetPosition();

      Assert.AreEqual(_initialPosition, position);
    }

    [Test]
    public void R_Should_Change_Its_Orientation_To_E()
    {
      _robot.Move(new List<Instruction> { Instruction.R });

      var position = _robot.GetPosition();

      Assert.AreEqual(Orientation.E, position.Orientation);
    }

    [Test]
    public void RR_Should_Change_Its_Orientation_To_S()
    {
      _robot.Move(new List<Instruction> { Instruction.R, Instruction.R });

      var position = _robot.GetPosition();

      Assert.AreEqual(Orientation.S, position.Orientation);
    }

    [Test]
    public void RRR_Should_Change_Its_Orientation_To_W()
    {
      _robot.Move(new List<Instruction> { Instruction.R, Instruction.R, Instruction.R });

      var position = _robot.GetPosition();

      Assert.AreEqual(Orientation.W, position.Orientation);
    }

    [Test]
    public void RRRR_Should_Change_Its_Orientation_To_N()
    {
      _robot.Move(new List<Instruction> { Instruction.R, Instruction.R, Instruction.R, Instruction.R });

      var position = _robot.GetPosition();

      Assert.AreEqual(Orientation.N, position.Orientation);
    }

    [Test]
    public void L_Should_Change_Its_Orientation_To_W()
    {
      _robot.Move(new List<Instruction> { Instruction.L });

      var position = _robot.GetPosition();

      Assert.AreEqual(Orientation.W, position.Orientation);
    }

    [Test]
    public void LL_Should_Change_Its_Orientation_To_S()
    {
      _robot.Move(new List<Instruction> { Instruction.L, Instruction.L });

      var position = _robot.GetPosition();

      Assert.AreEqual(Orientation.S, position.Orientation);
    }

    [Test]
    public void LLL_Should_Change_Its_Orientation_To_E()
    {
      _robot.Move(new List<Instruction> { Instruction.L, Instruction.L, Instruction.L });

      var position = _robot.GetPosition();

      Assert.AreEqual(Orientation.E, position.Orientation);
    }

    [Test]
    public void LLLL_Should_Change_Its_Orientation_To_N()
    {
      _robot.Move(new List<Instruction> { Instruction.L, Instruction.L, Instruction.L, Instruction.L });

      var position = _robot.GetPosition();

      Assert.AreEqual(Orientation.N, position.Orientation);
    }
  }
}
