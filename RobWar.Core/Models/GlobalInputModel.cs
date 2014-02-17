using System.Collections.Generic;

namespace RobWar.Core.Models
{
  public class GlobalInputModel
  {
    public CoordinatesModel UpperRight { get; set; }
    public IEnumerable<RobotInputModel> RobotInputs { get; set; }
  }
}