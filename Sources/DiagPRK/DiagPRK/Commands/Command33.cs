using System.Collections.Generic;
using System.Linq;

namespace DiagPRK.Commands
{
    public class Command33 : ParameterizedCommand
    {
        public override int CommandId
        {
            get { return CommandsRegister.Command30; }
        }
        
        public override IEnumerable<object[]> GetParams()
        {
            object[] quantityParams = GetQuantity(0, 22)
                .Except(new object[] { 11, 19 })
                .ToArray();
            return new List<object[]> {quantityParams};
        }

        public override IEnumerable<string> GetPack(int commandId, int getfromValue, int sendtoValue)
        {
            return new List<string>
                       {
                           sendtoValue.ToString(),
                           getfromValue.ToString(),
                           commandId.ToString(),
                           Res.Par_error
                       };
        }
    }
}
