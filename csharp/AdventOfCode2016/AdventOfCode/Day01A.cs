using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day01A
    {
        public Position Position;
        public Facing Facing;

        public int Solve(string input)
        {
            Position = new Position();
            Facing = Facing.North;

            // Reformat input
            string[] format = {", "};
            string[] document = input.Split(format, StringSplitOptions.None);

            // Set up instructions
            IEnumerable<Instruction> instructions = document.Select(ParseDocument);

            // Stumble around
            foreach (Instruction instr in instructions)
            {
                Position = Position.Move(instr);
            }

            // Calculate distance
            int distX = Math.Abs(Position.X);
            int distY = Math.Abs(Position.Y);

            return distX + distY;
        }

        #region Support methods

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

    #region Extension methods
    public static class Day01Extensions
    {
        public static Position Move(this Position position, Instruction instruction)
        {
            position = instruction.Turn == Turn.Left ? TurnLeft(position) : TurnRight(position);
            switch (position.Facing)
            {
                case Facing.North:
                    position.Y += instruction.Distance;
                    break;
                case Facing.East:
                    position.X += instruction.Distance;
                    break;
                case Facing.South:
                    position.Y -= instruction.Distance;
                    break;
                case Facing.West:
                    position.X -= instruction.Distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(position.Facing), position.Facing, null);
            }

            return position;
        }

        public static Position TurnLeft(this Position position)
        {
            int dir = (int)position.Facing - 1;
            if (dir == -1) position.Facing = Facing.West;
            else position.Facing = (Facing)dir;

            return position;
        }

        public static Position TurnRight(this Position position)
        {
            int dir = (int)position.Facing + 1;
            position.Facing = (Facing)(dir % 4);

            return position;
        }
    }
#endregion

    #region Support structures
    public struct Instruction
    {
        public Turn Turn;
        public int Distance;
    }

    public struct Position
    {
        public int X;
        public int Y;
        public Facing Facing;
    }

    public enum Turn
    {
        Left,
        Right
    }

    public enum Facing
    {
        North,
        East,
        South,
        West
    }
#endregion
}
