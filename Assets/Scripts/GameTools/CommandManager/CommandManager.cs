using System.Collections.Generic;
using GameTools.CommandManager.Commands;
using Singletons;
using UnityEngine;

namespace GameTools.CommandManager
{

    public sealed class CommandManager : GenericSingleton<CommandManager>
    {
        

        private Stack<ICommand> m_CommandsBuffer = new Stack<ICommand>();

        private void Awake()
        {
            base.Awake();
        }

        public void AddCommand(ICommand command)
        {
            command.Execute();
            m_CommandsBuffer.Push(command);
        }
    
        public void Undo()
        {
            if(m_CommandsBuffer.Count == 0)
                return;
  
            var cmd = m_CommandsBuffer.Pop();
            cmd.Undo();
        }
    }
}
