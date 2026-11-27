using System;

namespace Task2_Figures
{
    public abstract class Figure
    {
        protected string Color { get; set; }
        protected bool IsVisible { get; set; }
        protected int X { get; set; }
        protected int Y { get; set; }

        public Figure(string color, bool isVisible, int x, int y)
        {
            Color = color;
            IsVisible = isVisible;
            X = x;
            Y = y;
        }
        public void MoveHorizontal(int delta)
        {
            X += delta;
        }

        public void MoveVertical(int delta)
        {
            Y += delta;
        }
        public void ChangeColor(string newColor)
        {
            Color = newColor;
        }

        public void ChangeVisibility(bool visible)
        {
            IsVisible = visible;
        }
        public virtual void PrintState()
        {
            Console.WriteLine($"Тип: {GetType().Name} | Цвет: {Color} | Видимость: {(IsVisible ? "Да" : "Нет")} | Координаты: ({X}, {Y})");
        }
    }
    public class Point : Figure
    {
        public Point(string color, bool isVisible, int x, int y) : base(color, isVisible, x, y) { }
    }
    public class Circle : Point
    {
        public double Radius { get; set; }

        public Circle(string color, bool isVisible, int x, int y, double radius) 
            : base(color, isVisible, x, y)
        {
            Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override void PrintState()
        {
            base.PrintState();
            Console.WriteLine($"   -> Радиус: {Radius} | Площадь: {GetArea():F2}");
        }
    }
    public class Rectangle : Point
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(string color, bool isVisible, int x, int y, double width, double height) 
            : base(color, isVisible, x, y)
        {
            Width = width;
            Height = height;
        }

        public double GetArea()
        {
            return Width * Height;
        }

        public override void PrintState()
        {
            base.PrintState();
            Console.WriteLine($"   -> Ширина: {Width} | Высота: {Height} | Площадь: {GetArea():F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Домашнее задание 10.1: Геометрические фигуры ===\n");
            Point point = new Point("Красный", true, 10, 20);
            Circle circle = new Circle("Синий", true, 0, 0, 5.5);
            Rectangle rect = new Rectangle("Зеленый", false, -5, 10, 4, 6);

            Console.WriteLine("--- Исходное состояние ---");
            point.PrintState();
            circle.PrintState();
            rect.PrintState();

            Console.WriteLine("\n--- Выполняем действия (перемещение, смена цвета) ---");
            point.MoveHorizontal(15);
            point.ChangeColor("Желтый");

            circle.MoveVertical(-10);
            circle.ChangeVisibility(false);

            rect.ChangeVisibility(true);
            rect.MoveHorizontal(2);
            rect.MoveVertical(2);

            Console.WriteLine("\n--- Новое состояние ---");
            point.PrintState();
            circle.PrintState();
            rect.PrintState();

            Console.ReadLine();
        }
    }
}