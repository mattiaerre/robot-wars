using RobWar.Core.Models;
using System;
using System.Collections.Generic;

namespace RobWar.Core.Domain
{
  public class Robot : IRobot
  {
    private readonly CoordinatesModel _lowerLeft = new CoordinatesModel { X = 0, Y = 0 };
    private readonly PositionModel _position;
    private readonly CoordinatesModel _upperRight;
    public Robot(PositionModel position, CoordinatesModel upperRight)
    {
      _position = position;
      _upperRight = upperRight;
    }
    public PositionModel GetPosition()
    {
      return _position;
    }
    public void Move(IEnumerable<Instruction> instructions)
    {
      foreach (var instruction in instructions)
      {
        if (instruction == Instruction.R || instruction == Instruction.L)
          UpdateOrientation(instruction);
        if (instruction == Instruction.M)
          UpdateCoordinates();
      }
    }
    private void UpdateCoordinates()
    {
      if (_position.Orientation == Orientation.N)
        _position.Coordinates.Y = Math.Min(_position.Coordinates.Y + 1, _upperRight.Y);
      else if (_position.Orientation == Orientation.E)
        _position.Coordinates.X = Math.Min(_position.Coordinates.X + 1, _upperRight.X);
      else if (_position.Orientation == Orientation.S)
        _position.Coordinates.Y = Math.Max(_lowerLeft.Y, _position.Coordinates.Y - 1);
      else if (_position.Orientation == Orientation.W)
        _position.Coordinates.X = Math.Max(_lowerLeft.X, _position.Coordinates.X - 1);
    }
    private void UpdateOrientation(Instruction instruction)
    {
      if (_position.Orientation == Orientation.N && instruction == Instruction.R)
        _position.Orientation = Orientation.E;
      else if (_position.Orientation == Orientation.E && instruction == Instruction.R)
        _position.Orientation = Orientation.S;
      else if (_position.Orientation == Orientation.S && instruction == Instruction.R)
        _position.Orientation = Orientation.W;
      else if (_position.Orientation == Orientation.W && instruction == Instruction.R)
        _position.Orientation = Orientation.N;
      else if (_position.Orientation == Orientation.N && instruction == Instruction.L)
        _position.Orientation = Orientation.W;
      else if (_position.Orientation == Orientation.W && instruction == Instruction.L)
        _position.Orientation = Orientation.S;
      else if (_position.Orientation == Orientation.S && instruction == Instruction.L)
        _position.Orientation = Orientation.E;
      else if (_position.Orientation == Orientation.E && instruction == Instruction.L)
        _position.Orientation = Orientation.N;
    }
  }
}