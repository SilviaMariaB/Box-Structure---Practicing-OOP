using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming
{
    internal class Program
    {
        /*struct Box
        {
            public double Lenght;
            public double Height;
            public double Depth;

            public Box(double lenght, double height, double depth)
            {
                Lenght = lenght;
                Height = height;
                Depth = depth;
            }
        }*/
        class Box
        {
            private double length, height, depth;
            //public double Lenght, Height, Depth;

           // public double Lenght { get { return length; } set { length = value; } }
            public double Lenght { get => length; set { length = value > 0 ? value : 1; } } 
            public double Height { get => height; set { height = value > 0 ? value : 1; } }
            public double Depth { get =>  depth; set { depth = value > 0 ? value : 1; } }


            public Box(double lenght, double height, double depth)
            {
                Lenght = lenght;
                Height = height;
                Depth = depth;
            }

            public Box(double size)
            {
                Lenght = size;
                Height = size;
                Depth = size;
            }

            //public void SetLength(double length)
            //{
            //    Lenght = length > 0 ? length : -1;
            //}
            //public void SetHeight(double height)
            //{
            //    Height = height > 0 ? height : -1;
            //}
            //public void SetDepth(double depth)
            //{
            //    Depth = depth > 0 ? depth : -1;
            //}

            ////public double GetLength() => Lenght;
            //public double GetLength() {  return Lenght; }
            //public double GetHeight() {  return Height; }
            //public double GetDepth() {  return Depth; }

            public string ReturnDetails()
            {
                return $"Length: {Lenght} \tHeight: {Height} \tDepth: {Depth}";
            }

            public static Box operator +(Box a, Box b)
            {
                return new Box(a.Lenght + b.Lenght, a.Height + b.Height, a.Depth + b.Depth);
            }
            public static Box operator -(Box a, Box b)
            {
                return new Box(a.Lenght - b.Lenght, a.Height - b.Height, a.Depth - b.Depth);
            }
            public static Box operator ++(Box a)
            {
                a.Lenght++;
                a.Height++;
                a.Depth++;
                return a;
            }
            public static Box operator --(Box a)
            {
                a.Lenght--;
                a.Height--;
                a.Depth--;
                return a;
            }
            public static bool operator ==(Box a, Box b)
            {
                 return a.Lenght==b.Lenght && a.Height==b.Height && a.Depth==b.Depth;
            }
            public static bool operator !=(Box a, Box b)
            {
                return a.Lenght != b.Lenght || a.Height != b.Height || a.Depth != b.Depth;
            }

            public override string ToString()
            {
                return $"Length: {Lenght} \tHeight: {Height} \tDepth: {Depth}";
            }

            public override bool Equals(object obj)
            {
                //we cast the obj as a box
                if (obj is Box)
                {
                    Box box = obj as Box;
                    return length == box.length && height == box.height && depth == box.depth;
                }
                return false;
            }

        }

        class Square : Box
        {
            public Square(double size) : base (size)
            {
            }
            public override string ToString()
            {
                return base.ToString();
            }
        }

        class Rectangle : Box
        {
            public Rectangle(double lenght, double height, double depth) : base( lenght,  height,  depth)
            {
            }
            public override string ToString()
            {
                return base.ToString();
            }

        }
        static void Main(string[] args)
        {
            //Box box = ReturnBox();
            Box box1 = new Box(10, 15, 25);
            Box box2 = new Box(5, 5, 5);

            Console.WriteLine("Box1\n" + box1.ReturnDetails());
            Console.WriteLine("Box2\n" + box2.ReturnDetails());

            box1 = box1 + box2;
            Console.WriteLine("Box1=Box1+box2\n" + box1.ReturnDetails());

            box2++;
            Console.WriteLine("Box2++\n" + box2.ReturnDetails());

            box1 = box1 - box2;
            Console.WriteLine("Box1=Box1-box2\n" + box1.ReturnDetails());

            box1--;
            Console.WriteLine("Box1--\n" + box1.ReturnDetails());

            if (box1 == box2)
            {
                Console.WriteLine("Equal sizes.");
            }
            else if (box1 != box2) {
                Console.WriteLine("Not equal..");
            }

            if (box1.Equals(box2)) { Console.WriteLine("Equals"); } else { Console.WriteLine("Not equal"); }

            //overriding ToString operator->
            Console.WriteLine(box1);

            //box.Height = 0;
            //Console.WriteLine();
            //Console.WriteLine("New height is: " + box.Height);

            //box.SetLength(25);
            //box.SetDepth(25);
            //box.SetHeight(25);

            //Console.WriteLine();

            // Console.WriteLine(box.ReturnDetails());
            Box box3 = new Box(10, 10, 10);
            Square square1 = new Square(10);
            Console.WriteLine(square1);

            Console.WriteLine(box3==square1);

            Rectangle rectangle = new Rectangle(10, 10, 10);

            Console.WriteLine(rectangle == square1);

            Console.WriteLine(box3 == rectangle);

            Console.ReadLine();
        }

        //static string ReturnDetails(Box box)
        //{
        //    return $"Length: {box.Lenght} \nHeight: {box.Height} \nDepth: {box.Depth}";
        //}

        static Box ReturnBox()
        {
            Console.WriteLine("Insert length: ");
            double length = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Insert height: ");
            double height = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Insert depth: ");
            double depth = Convert.ToDouble(Console.ReadLine());

            return new Box(length, height, depth);
        }
    }
}
