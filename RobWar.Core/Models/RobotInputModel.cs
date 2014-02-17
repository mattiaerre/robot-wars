using System.Collections.Generic;

namespace RobWar.Core.Models
{
  public class RobotInputModel
  {
    public PositionModel InitialPosition { get; set; }
    public IEnumerable<Instruction> Instructions { get; set; }
  }
}