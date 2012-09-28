using System.Collections.Generic;
using Spring.Context;

namespace DiagPRK.Commands
{
    public class CommandFactory : IApplicationContextAware
    {
        /// <summary>
        /// Map between Command id and it's spring id
        /// Configure this dictionary in spring config
        /// </summary>
        public Dictionary<int, string> Commands { get; set; }

        /// <summary>
        /// Init factory
        /// </summary>
        public void InitFactory()
        {
            Commands = new Dictionary<int, string>();
            string[] commandsNames = ApplicationContext.GetObjectNamesForType(typeof(IBaseCommand));
            foreach (string commandName in commandsNames)
            {
                var command = (BaseCommand)ApplicationContext.GetObject(commandName);
                Commands.Add(command.CommandId, commandName);
            }
        }
        
        #region Implementation of ICommandFactory

        /// <summary>
        /// Get command by id
        /// </summary>
        /// <param name="commandId">Command id</param>
        /// <returns>Created command, if command id is not configured, then null is returned</returns>
        public BaseCommand GetCommand(int commandId)
        {
            if (Commands.ContainsKey(commandId))
            {
                var command = (BaseCommand)ApplicationContext.GetObject(Commands[commandId]);
                return command;
            }

            return null;
        }

        #endregion

        #region Implementation of IApplicationContextAware

        public IApplicationContext ApplicationContext
        {
            private get;
            set;
        }

        #endregion
    }
}
