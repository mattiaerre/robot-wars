using System.Collections.Generic;
using RobWar.Core.Domain;

namespace RobWar.Core.Services
{
  public interface IRobotsService
  {
    void Manage();
    IEnumerable<Robot> Robots { get; set; }
  }
}