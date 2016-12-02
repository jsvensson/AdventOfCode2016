using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class Day01
    {
        public static Position Position;

        public static int Solve(string input)
        {
            Position = new Position();
            var facing = Facing.North;

            // Reformat input
            string[] format = {", "};
            string[] document = input.Split(format, StringSplitOptions.None);

            // Set up instructions
            IEnumerable<Instruction> instructions = document.Select(ParseDocument);

            // Stumble around
            foreach (Instruction instr in instructions)
            {
                facing = instr.Turn == Turn.Left ? facing.TurnLeft() : facing.TurnRight();
                Position = Position.Move(facing, instr.Distance);
            }

            // Calculate distance
            int distX = Math.Abs(Position.X);
            int distY = Math.Abs(Position.Y);

            return distX + distY;
        }

        #region Support methods

        private static Position Move(this Position position, Facing facing, int distance)
        {
            switch (facing)
            {
                case Facing.North:
                    position.Y += distance;
                    break;
                case Facing.East:
                    position.X += distance;
                    break;
                case Facing.South:
                    position.Y -= distance;
                    break;
                case Facing.West:
                    position.X -= distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(facing), facing, null);
            }

            return position;
        }

        private static Facing TurnLeft(this Facing facing)
        {
            int dir = (int) facing - 1;
            if (dir == -1) facing = Facing.West;
            else facing = (Facing) dir;

            return facing;
        }

        private static Facing TurnRight(this Facing facing)
        {
            int dir = (int) facing + 1;
            return (Facing) (dir%3);
        }

        private static Instruction ParseDocument(string input)
        {
            var instruction = new Instruction();
            char facing = input[0];

            switch (facing)
            {
                case 'L':
                    instruction.Turn = Turn.Left;
                    break;
                case 'R':
                    instruction.Turn = Turn.Right;
                    break;
            }

            instruction.Distance = int.Parse(input.Substring(1));

            return instruction;
        }
#endregion
    }
    #region Support structures
    internal struct Instruction
    {
        public Turn Turn;
        public int Distance;
    }

    public struct Position
    {
        public int X;
        public int Y;
    }

    internal enum Turn
    {
        Left,
        Right
    }

    internal enum Facing
    {
        North,
        East,
        South,
        West
    }
#endregion
}
