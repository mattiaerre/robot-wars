using RobWar.Core.Models;
using RobWar.Core.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace RobWar.Infra.Services
{
  public class TxtInputService : IInputService
  {
    private readonly string _path;
    public TxtInputService(string path)
    {
      _path = path;
    }
    public GlobalInputModel GetGlobalInput()
    {
      var model = new GlobalInputModel();
      using (var reader = new StreamReader(_path))
      {
        var list = new List<RobotInputModel>();
        var counter = 0;
        string line;
        while ((line = reader.ReadLine()) != null)
        {
          if (counter == 0)
            model.UpperRight = GetUpperRight(line);
          else
            list.Add(GetRobotInput(line, reader.ReadLine()));
          counter++;
        }
        model.RobotInputs = list;
      }
      return model;
    }
    private static RobotInputModel GetRobotInput(string position, string instructions)
    {
      var model = new RobotInputModel
      {
        InitialPosition = GetPosition(position),
        Instructions = GetInstructions(instructions),
      };
      return model;
    }
    private static IEnumerable<Instruction> GetInstructions(string instructions)
    {
      var parts = instructions.ToArray();
      var list = new List<Instruction>();
      foreach (var part in parts)
      {
        list.Add((Instruction)Enum.Parse(typeof(Instruction), part.ToString(CultureInfo.InvariantCulture)));
      }
      return list;
    }
    private static PositionModel GetPosition(string position)
    {
      var parts = position.Split(' ');
      return new PositionModel
      {
        Coordinates = new CoordinatesModel
        {
          X = Convert.ToInt32(parts[0]),
          Y = Convert.ToInt32(parts[1]),
        },
        Orientation = (Orientation)Enum.Parse(typeof(Orientation), parts[2]),
      };
    }
    private static CoordinatesModel GetUpperRight(string line)
    {
      var coordinates = line.Split(' ');
      return new CoordinatesModel { X = Convert.ToInt32(coordinates[0]), Y = Convert.ToInt32(coordinates[1]) };
    }
  }
}