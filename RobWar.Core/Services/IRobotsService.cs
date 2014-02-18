using RobWar.Core.Domain;
using System.Collections.Generic;

namespace RobWar.Core.Services
{
  public interface IRobotsService
  {
    void Manage();
    IEnumerable<Robot> Robots { get; set; }
  }
}