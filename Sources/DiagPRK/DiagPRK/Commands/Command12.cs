using System.Collections.Generic;

namespace DiagPRK.Commands
{
    public class Command12 : ParameterizedCommand
    {
        public override int CommandId
        {
            get { return CommandsRegister.Command30; }
        }
        
        public override IEnumerable<object[]> GetParams()
        {
            var quantityParams = new List<object[]>(ParamNumber)
                                     {
                                         GetQuantity(0, 7)
                                     };
            return quantityParams;
        }
    }
}
