using System;

namespace Shape
{
    // Базовый класс Shape
    class Shape
    {
        // Виртуальный метод для расчета площади, который будет переопределяться в производных классах
        public virtual double CalculateArea()
        {
            return 0; // По умолчанию площадь равна 0
        }
    }

    // Класс Circle, представляющий круг, наследует от Shape
    class Circle : Shape
    {
        public double Radius { get; set; }

        // Конструктор для установки радиуса
        public Circle(double radius)
        {
            Radius = radius;
        }

        // Переопределенный метод для расчета площади круга
        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    // Класс Rectangle, представляющий прямоугольник, наследует от Shape
    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        // Конструктор для установки ширины и высоты прямоугольника
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        // Переопределенный метод для расчета площади прямоугольника
        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    // Класс Triangle, представляющий треугольник, наследует от Shape
    class Triangle : Shape
    {
        public double BaseLength { get; set; }
        public double Height { get; set; }

        // Конструктор для установки длины основания и высоты треугольника
        public Triangle(double baseLength, double height)
        {
            BaseLength = baseLength;
            Height = height;
        }

        // Переопределенный метод для расчета площади треугольника
        public override double CalculateArea()
        {
            return 0.5 * BaseLength * Height;
        }
    }

    // Класс ShapeChoice для взаимодействия с пользователем
    class ShapeChoice
    {
        delegate double CalculateAreaDelegate();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Выберите фигуру для вычисления площади: ");
                Console.WriteLine("1. Круг");
                Console.WriteLine("2. Прямоугольник");
                Console.WriteLine("3. Треугольник");
                Console.WriteLine("4. Выйти из программы");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 4)
                {
                    break; // Пользователь выбрал выход из программы
                }

                Shape shape = null;
                switch (choice)
                {
                    case 1:
                        Console.Write("Введите радиус круга: ");
                        double radius = double.Parse(Console.ReadLine());
                        shape = new Circle(radius);
                        break;
                    case 2:
                        Console.Write("Введите ширину прямоугольника: ");
                        double width = double.Parse(Console.ReadLine());
                        Console.Write("Введите высоту прямоугольника: ");
                        double height = double.Parse(Console.ReadLine());
                        shape = new Rectangle(width, height);
                        break;
                    case 3:
                        Console.Write("Введите длину основания треугольника: ");
                        double baseLength = double.Parse(Console.ReadLine());
                        Console.Write("Введите высоту треугольника: ");
                        double triangleHeight = double.Parse(Console.ReadLine());
                        shape = new Triangle(baseLength, triangleHeight);
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор.");
                        continue;
                }

                CalculateAreaDelegate shapeDelegate = shape.CalculateArea;
                Console.WriteLine($"Площадь выбранной фигуры: {shapeDelegate()}");
                Console.ReadLine();
            }
        }
    }
}
