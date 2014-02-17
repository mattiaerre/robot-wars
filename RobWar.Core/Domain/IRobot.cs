using System.Collections.Generic;
using RobWar.Core.Models;

namespace RobWar.Core.Domain
{
  public interface IRobot
  {
    PositionModel GetPosition();
    void Move(IEnumerable<Instruction> instructions);
  }
}