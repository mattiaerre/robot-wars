using System.Collections.Generic;
using RobWar.Core.Domain;

namespace RobWar.Core.Services
{
  public class RobotsService : IRobotsService
  {
    public void Manage()
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<Robot> Robots { get; set; }
  }
}