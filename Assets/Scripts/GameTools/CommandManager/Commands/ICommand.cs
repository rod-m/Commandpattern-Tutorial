
    namespace GameTools.CommandManager.Commands
    {
        public interface ICommand
        {
            void Execute();
            void Undo();
        }
    }
