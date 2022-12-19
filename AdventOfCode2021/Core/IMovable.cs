using AdventOfCode2021.Core.Types;
using AdventOfCode2021.Utils;

namespace AdventOfCode2021.Core
{
    public interface IMovable
    {
        int HorizontalPosition { get; }
        int Depth { get; set; }
        int AbsolutePosition { get; }

        int Aim { get; set; }
        void ChangePosition(Move move);
        public void ChangePositionWithCorrection(Move move);
    }
}