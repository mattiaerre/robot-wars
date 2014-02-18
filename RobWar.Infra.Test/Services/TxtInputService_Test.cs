using NUnit.Framework;
using RobWar.Infra.Services;
using System;
using System.IO;
using System.Linq;

namespace RobWar.Infra.Test.Services
{
  [TestFixture]
  public class TxtInputService_Test
  {
    [SetUp]
    public void Given_An_InputService()
    {
    }

    [Test]
    public void It_Should_Be_Able_To_Return_A_Global_Input()
    {
      const string path = @"C:\Users\mattia.richetto\Dropbox\dotNet\prj\RobWar\RobWar.Infra.Test\Services\GoodInput.txt";
      var service = new TxtInputService(path);

      var input = service.GetGlobalInput();

      Assert.AreEqual(5, input.UpperRight.X);

      Assert.AreEqual(5, input.UpperRight.Y);

      Assert.AreEqual(2, input.RobotInputs.Count());
    }

    [Test]
    public void It_Should_Raise_A_FileNotFoundException_If_The_Input_File_Does_Not_Exist()
    {
      const string path = @"C:\Users\mattia.richetto\Dropbox\dotNet\prj\RobWar\RobWar.Infra.Test\Services\NotExistingInput.txt";
      var service = new TxtInputService(path);

      Assert.Throws(typeof(FileNotFoundException), () => service.GetGlobalInput());
    }

    [Test]
    public void It_Should_Raise_A_FormatException_If_The_Input_File_Is_KO()
    {
      const string path = @"C:\Users\mattia.richetto\Dropbox\dotNet\prj\RobWar\RobWar.Infra.Test\Services\BadInput.txt";
      var service = new TxtInputService(path);

      Assert.Throws(typeof(FormatException), () => service.GetGlobalInput());
    }
  }
}
