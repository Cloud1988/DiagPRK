using DiagPRK.Spring;
using DiagPRK.Commands;
using NUnit.Framework;

namespace DiagPRK.Test
{
    [TestFixture]
    public class CommandFactoryTest
    {
        private CommandFactory _commandFactory;

        [SetUp]
        public void SetUp()
        {
            _commandFactory = SpringContext.GetObject<CommandFactory>();
        }

        [Test]
        public void GetCommandTest()
        {
            var command = _commandFactory.GetCommand(-1);

            Assert.IsNotNull(command);
            Assert.IsInstanceOf<FakeCommand>(command);
        }
    }
}
