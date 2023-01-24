using UnityEngine;

namespace GameTools.CommandManager.Commands
{
    public class CaptureCommand : ICommand
    {
        private Vector3Int m_From;
        private Vector3Int m_To;
        private Unit capturedPiece;
        
        public CaptureCommand(Vector3Int start, Vector3Int end, Unit _capturedPiece) 
        {
            m_From = start;
            m_To = end;
            capturedPiece = _capturedPiece;
        }
        public void Execute()
        {
            var unit = Gameboard.Instance.GetUnit(m_From);
            if (unit != null)
            {
                Gameboard.Instance.MoveUnit(unit, m_To);
                Gameboard.Instance.TakeOutUnit(unit);
                Gameboard.Instance.SwitchTeam();
            }
        }

        public void Undo()
        {
            var unit = Gameboard.Instance.GetUnit(m_To);
            if (unit != null)
            {
                Gameboard.Instance.MoveUnit(unit, m_From);
                if (capturedPiece != null)
                {
                    Gameboard.Instance.MoveUnit(capturedPiece, m_To);
                }
                // switch back to other team
                Gameboard.Instance.SwitchTeam();
            }
           
        }
    }
}