using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMasterclass90
{
    public class Board
    {
        const char topleft       = '\u250C'; // BOX DRAWINGS LIGHT DOWN AND RIGHT (U+250C)
        const char hline         = '\u2500'; // BOX DRAWINGS LIGHT HORIZONTAL (U+2500)
        const char topright      = '\u2510'; // BOX DRAWINGS LIGHT DOWN AND LEFT (U+2510)
        const char vline         = '\u2502'; // BOX DRAWINGS LIGHT VERTICAL (U+2502)
        const char bottomleft    = '\u2514'; // BOX DRAWINGS LIGHT UP AND RIGHT (U+2514)
        const char bottomright   = '\u2518'; // BOX DRAWINGS LIGHT UP AND LEFT (U+2518)
        const char cross         = '\u253C'; // BOX DRAWINGS LIGHT VERTICAL AND HORIZONTAL (U+253C)
        const char topT          = '\u252C'; // BOX DRAWINGS LIGHT DOWN AND HORIZONTAL (U+252C)
        const char bottomT       = '\u2534'; // BOX DRAWINGS LIGHT UP AND HORIZONTAL (U+2534)
        const char leftT         = '\u251C'; // BOX DRAWINGS LIGHT VERTICAL AND RIGHT (U+251C)
        const char rightT        = '\u2524'; // BOX DRAWINGS LIGHT VERTICAL AND LEFT (U+2524)

        private readonly int space;
        private readonly int ex_space;

        private char[,] table = new char[,]
        {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };

        public Board(int size = 5)
        {
            space = size;
            ex_space = (space - 1) / 2;
        }

        public void ResetGame()
        {
            table = new char[,]
            {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' }
            };
        }

        public bool GameOver()
        {
            // check rows
            for (int row = 0; row < table.GetLength(0); row++)
            {
                if (table[row, 0] == table[row, 1] && table[row, 1] == table[row, 2])
                    return true;
            }

            // check columns
            for (int column = 0; column < table.GetLength(1); column++)
            {
                if (table[0, column] == table[1, column] && table[1, column] == table[2, column])
                    return true;
            }

            // check diagonal /
            if (table[0, 2] == table[1, 1] && table[1, 1] == table[2, 0])
                return true;

            // check diagonal \
            if (table[0, 0] == table[1, 1] && table[1, 1] == table[2, 2])
                return true;

            return false;
        }

        public bool SetField(char player)
        {
            Console.Write("Player {0}: Choose your field > ", player);
            string? field = Console.ReadLine();

            switch (field)
            {
                case "1":
                    if (table[0, 0] == '1')
                        table[0, 0] = player;
                    else
                    {
                        FieldError(field);
                        return false;
                    }
                    break;
                case "2":
                    if (table[0, 1] == '2')
                        table[0, 1] = player;
                    else
                    {
                        FieldError(field);
                        return false;
                    }
                    break;
                case "3":
                    if (table[0, 2] == '3')
                        table[0, 2] = player;
                    else
                    {
                        FieldError(field);
                        return false;
                    }
                    break;
                case "4":
                    if (table[1, 0] == '4')
                        table[1, 0] = player;
                    else
                    {
                        FieldError(field);
                        return false;
                    }
                    break;
                case "5":
                    if (table[1, 1] == '5')
                        table[1, 1] = player;
                    else
                    {
                        FieldError(field);
                        return false;
                    }
                    break;
                case "6":
                    if (table[1, 2] == '6')
                        table[1, 2] = player;
                    else
                    {
                        FieldError(field);
                        return false;
                    }
                    break;
                case "7":
                    if (table[2, 0] == '7')
                        table[2, 0] = player;
                    else
                    {
                        FieldError(field);
                        return false;
                    }
                    break;
                case "8":
                    if (table[2, 1] == '8')
                        table[2, 1] = player;
                    else
                    {
                        FieldError(field);
                        return false;
                    }
                    break;
                case "9":
                    if (table[2, 2] == '9')
                        table[2, 2] = player;
                    else
                    {
                        FieldError(field);
                        return false;
                    }  
                    break;
                default:
                    Console.WriteLine("Invalid field input!");
                    return false;
            }

            return true;
        }

        static void FieldError(string field)
        {
            Console.WriteLine("Field {0} is already taken", field);
        }

        public void PrintBoard()
        {
            /*
                CodePage    identifier and name

                65001       UTF-8
            */

            Console.OutputEncoding = System.Text.Encoding.GetEncoding(65001);
            Console.Title = "Tic Tac Toe";
            DrawTop();
            DrawMidSpacer();
            DrawMidSpacer(0);
            DrawMidSpacer();
            DrawMiddle();
            DrawMidSpacer();
            DrawMidSpacer(1);
            DrawMidSpacer();
            DrawMiddle();
            DrawMidSpacer();
            DrawMidSpacer(2);
            DrawMidSpacer();
            DrawBottom();
        }

        private void DrawBottom()
        {
            #region bottom
            Write(bottomleft);
            for (int i = 0; i < space; i++)
                Write(hline);
            Write(bottomT);
            for (int i = 0; i < space; i++)
                Write(hline);
            Write(bottomT);
            for (int i = 0; i < space; i++)
                Write(hline);
            Write(bottomright);
            Console.WriteLine();
            #endregion
        }

        private void DrawMiddle()
        {
            #region middle
            Write(leftT);
            for (int i = 0; i < space; i++)
                Write(hline);
            Write(cross);
            for (int i = 0; i < space; i++)
                Write(hline);
            Write(cross);
            for (int i = 0; i < space; i++)
                Write(hline);
            Write(rightT);
            Console.WriteLine();
            #endregion
        }

        private void DrawMidSpacer(int row)
        {
            #region middlespacer
            Write(vline);
            for (int i = 0; i < ex_space; i++)
                Console.Write(" ");
            Console.Write(table[row, 0]);
            for (int i = 0; i < ex_space; i++)
                Console.Write(" ");
            Write(vline);
            for (int i = 0; i < ex_space; i++)
                Console.Write(" ");
            Console.Write(table[row, 1]);
            for (int i = 0; i < ex_space; i++)
                Console.Write(" ");
            Write(vline);
            for (int i = 0; i < ex_space; i++)
                Console.Write(" ");
            Console.Write(table[row, 2]);
            for (int i = 0; i < ex_space; i++)
                Console.Write(" ");
            Write(vline);  
            Console.WriteLine();
            #endregion
        }

        private void DrawMidSpacer()
        {
            #region middlespacer
            Write(vline);
            for (int i = 0; i < space; i++)
                Console.Write(" ");
            Write(vline);
            for (int i = 0; i < space; i++)
                Console.Write(" ");
            Write(vline);
            for (int i = 0; i < space; i++)
                Console.Write(" ");
            Write(vline);
            Console.WriteLine();
            #endregion
        }

        private void DrawTop()
        {
            #region top
            Write(topleft);
            for (int i = 0; i < space; i++)
                Write(hline);
            Write(topT);
            for (int i = 0; i < space; i++)
                Write(hline);
            Write(topT);
            for (int i = 0; i < space; i++)
                Write(hline);
            Write(topright);
            Console.WriteLine();
            #endregion
        }

        static void Write(int charcode)
        {
            Console.Write((char)charcode);
        }
    }
}
