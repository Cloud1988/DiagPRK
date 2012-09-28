using System.Collections.Generic;

namespace DiagPRK.Commands
{
    public class FakeCommand : BaseCommand
    {
        public override int CommandId
        {
            get { return CommandsRegister.FakeCommand; }
        }

        public override IEnumerable<object[]> GetParams()
        {
            throw new System.NotImplementedException();
        }
    }
}
