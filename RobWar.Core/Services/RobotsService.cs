using RobWar.Core.Domain;
using System.Collections.Generic;

namespace RobWar.Core.Services
{
  public class RobotsService : IRobotsService
  {
    private readonly IInputService _inputService;
    public IEnumerable<Robot> Robots { get; set; }
    public RobotsService(IInputService inputService)
    {
      _inputService = inputService;
    }
    public void Manage()
    {
      var input = _inputService.GetGlobalInput();

      var robots = new List<Robot>();
      foreach (var robotInput in input.RobotInputs)
      {
        var robot = new Robot(robotInput.InitialPosition, input.UpperRight);
        robot.Move(robotInput.Instructions);
        robots.Add(robot);
      }
      Robots = robots;
    }
  }
}