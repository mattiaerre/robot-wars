using RobWar.Core.Models;
using System.Collections.Generic;

namespace RobWar.Core.Domain
{
  public interface IRobot
  {
    PositionModel GetPosition();
    void Move(IEnumerable<Instruction> instructions);
  }
}