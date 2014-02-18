using RobWar.Core.Services;
using RobWar.Infra.Services;
using System;

namespace RobWar.App
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("insert input file path ...");
      var path = Console.ReadLine();

      var service = new RobotsService(new TxtInputService(path));

      try
      {
        service.Manage();
        foreach (var robot in service.Robots)
        {
          var position = robot.GetPosition();
          Console.WriteLine("{0} {1} {2}",
            position.Coordinates.X,
            position.Coordinates.Y,
            position.Orientation);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

      Console.WriteLine("press any key to continue ...");
      Console.ReadLine();
    }
  }
}
