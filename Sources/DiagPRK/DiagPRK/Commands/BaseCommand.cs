using System.Collections.Generic;
namespace DiagPRK.Commands
{
    public abstract class BaseCommand
    {
        public abstract int CommandId { get; }

        public virtual IEnumerable<object[]> GetParams()
        {
            return new List<object[]>();
        }

        public virtual IEnumerable<string> GetPack(int commandId, int getfromValue, int sendtoValue)
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

        protected object[] GetQuantity(int min, int max)
        {
            var quantity = new object[max - min + 1];
            for (int i = 0; i < quantity.Length; i++)
            {
                quantity[i] = min + i;
            }
            return quantity;
        }
    }
}
