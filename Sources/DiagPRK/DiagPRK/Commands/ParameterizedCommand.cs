using System.Collections.Generic;

namespace DiagPRK.Commands
{
    public abstract class ParameterizedCommand : BaseCommand
    {
        protected virtual int ParamNumber
        {
            get { return 1; }
        }

        public override IEnumerable<string> GetPack(int commandId, int getfromValue, int sendtoValue)
        {
            return new List<string>
                       {
                           sendtoValue.ToString(),
                           getfromValue.ToString(),
                           commandId.ToString(),
                           ParamNumber.ToString(),
                           Res.Par_error
                       };
        }
    }
}
