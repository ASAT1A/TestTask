using System;
using System.Collections.Generic;

namespace TestTask
{

    // Вспомогательный класс для отрисовки 
    public class Print
    {
        public static void ClearAllSpace()
        {
            Console.Clear();
        }
        public static void ClearSpace(char symbol, int countLines, int countColumns, int X, int Y)
        {
            Console.SetCursorPosition(X, Y);
            for (int i = 0; i < countLines; i++)
            {
                for (int j = 0; j < countColumns; j++)
                {
                    Console.Write(symbol);
                }
                Y++;
                Console.SetCursorPosition(X, Y);
            }
        }
        public static void PrintText(string text, int positionX, int positionY, ConsoleColor colorText)
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.ForegroundColor = colorText;
            Console.Write(text);
        }
        public static void PrintDoubleText(string text1, string text2, int X, int Y, ConsoleColor color1, ConsoleColor color2)
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = color1;
            Console.Write(text1);
            Console.SetCursorPosition(X + text1.Length, Y);
            Console.ForegroundColor = color2;
            Console.Write(text2);
        }
        public static string PrintWall(char symbol, int count)
        {
            string wall = "";
            for (int i = 0; i < count; i++)
            {
                wall += symbol;
            }
            return wall;
        }

        public static void PrintInitializerInt(int number, ConsoleColor colorText, int positionX, int positionY)
        {
            string line = "|";
            string text = number.ToString();
            Print.PrintText(line, positionX, positionY, colorText);
            Print.PrintText(text, positionX + 2, positionY, ConsoleColor.White);
            Print.PrintText(line, positionX + 3 + text.Length, positionY, colorText);
        }

        public static void PrintInitializerChar(char symbol, ConsoleColor colorText, int positionX, int positionY)
        {
            string line = "|";
            string text = symbol.ToString();
            Print.PrintText(line, positionX, positionY, colorText);
            Print.PrintText(text, positionX + 2, positionY, ConsoleColor.White);
            Print.PrintText(line, positionX + 3 + text.Length, positionY, colorText);
        }

        public static void PrintLongText(string text, int X, int Y)
        {
            Console.SetCursorPosition(X, Y);
            var left = Console.CursorLeft;
            var top = Console.CursorTop;
            foreach (var item in text.Split('\n'))
            {
                Console.SetCursorPosition(left, top++);
                Console.Write(item);
            }
        }
    }
}
