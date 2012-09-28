
using System.Collections.Generic;

namespace DiagPRK.Commands
{
    public abstract class SimpleCommand : BaseCommand
    {
        public override IEnumerable<string> GetPack(int commandId, int getfromValue, int sendtoValue)
        {
            int sum = commandId + getfromValue + sendtoValue;
            return new List<string>
                       {
                           sendtoValue.ToString(),
                           getfromValue.ToString(),
                           commandId.ToString(),
                           "0",
                           sum.ToString()
                       };
        }
    }
}
