using Moq;
using NUnit.Framework;
using RobWar.Core.Models;
using RobWar.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace RobWar.Core.Test.Services
{
  [TestFixture]
  public class RobotsService_Test
  {
    private IRobotsService _service;
    private readonly Mock<IInputService> _inputService = new Mock<IInputService>();

    [SetUp]
    public void Given_A_RobotsService()
    {
      _service = new RobotsService(_inputService.Object);
    }

    [Test]
    public void It_Should_Be_Able_To_Manage_Robots()
    {
      _inputService.Setup(e => e.GetGlobalInput()).Returns(new GlobalInputModel
      {
        UpperRight = new CoordinatesModel { X = 5, Y = 5 },
        RobotInputs = new List<RobotInputModel>
        {
          new RobotInputModel{ InitialPosition = new PositionModel(), Instructions = new List<Instruction>()},
          new RobotInputModel{ InitialPosition = new PositionModel(), Instructions = new List<Instruction>()},
          new RobotInputModel{ InitialPosition = new PositionModel(), Instructions = new List<Instruction>()},
          new RobotInputModel{ InitialPosition = new PositionModel(), Instructions = new List<Instruction>()},
          new RobotInputModel{ InitialPosition = new PositionModel(), Instructions = new List<Instruction>()},
          new RobotInputModel{ InitialPosition = new PositionModel(), Instructions = new List<Instruction>()},
          new RobotInputModel{ InitialPosition = new PositionModel(), Instructions = new List<Instruction>()},
          new RobotInputModel{ InitialPosition = new PositionModel(), Instructions = new List<Instruction>()},
        }
      });

      _service.Manage();

      var robots = _service.Robots;

      Assert.AreEqual(8, robots.Count());
    }
  }
}
