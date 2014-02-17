using NUnit.Framework;
using RobWar.Core.Services;
using RobWar.Infra.Services;

namespace RobWar.Infra.Test.Services
{
  [TestFixture]
  public class TxtInputService_Test
  {
    private IInputService _service;

    [SetUp]
    public void Given_An_InputService()
    {
      _service = new TxtInputService();
    }
  }
}
