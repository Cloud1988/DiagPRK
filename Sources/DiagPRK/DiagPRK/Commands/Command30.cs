using System.Collections.Generic;

namespace DiagPRK.Commands
{
    public class Command30 : ParameterizedCommand
    {
        public override int CommandId
        {
            get { return CommandsRegister.Command30; }
        }

        protected override int ParamNumber
        {
            get { return 12; }
        }

        public override IEnumerable<object[]> GetParams()
        {
            var quantityParams = new List<object[]>(ParamNumber);
            for (int i = 0; i < 9; i++)
            {
                quantityParams.Add(GetQuantity(0, 255));
            }
            quantityParams.Add(GetQuantity(0, 1));
            quantityParams.Add(GetQuantity(0, 255));
            quantityParams.Add(GetQuantity(0, 255));
            return quantityParams;
        }
    }
}
