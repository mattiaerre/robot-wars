using NUnit.Framework;
using RobWar.Core.Services;

namespace RobWar.Core.Test.Services
{
  [TestFixture]
  public class RobotsService_Test
  {
    private IRobotsService _service;

    [SetUp]
    public void Given_A_RobotsService()
    {
      _service = new RobotsService();
    }

    [Test]
    public void It_Should_Be_Able_To_Manage_Robots()
    {
      _service.Manage();

      var robots = _service.Robots;


    }
  }
}
