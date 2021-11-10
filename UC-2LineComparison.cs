using System;
using System.Collections.Generic;
using System.Text;

namespace LinceComparison1
{
    class UC_2LineComparison
    {
        public class Point
        {
            public double x, y;

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            // Method used to display X and Y coordinates 
            // of a point 
            public static void displayPoint(Point p)
            {
                Console.WriteLine("(" + p.x + ", " + p.y + ")");
            }
        }

        public class Test
        {
            public static Point lineLineIntersection(Point A, Point B, Point C, Point D)
            {
                // Line AB represented as a1x + b1y = c1 
                double a1 = B.y - A.y;
                double b1 = A.x - B.x;
                double c1 = a1 * (A.x) + b1 * (A.y);

                // Line CD represented as a2x + b2y = c2 
                double a2 = D.y - C.y;
                double b2 = C.x - D.x;
                double c2 = a2 * (C.x) + b2 * (C.y);

                double determinant = a1 * b2 - a2 * b1;

                if (determinant == 0)
                {
                    // The lines are parallel. This is simplified 
                    // by returning a pair of FLT_MAX 
                    return new Point(double.MaxValue, double.MaxValue);
                }
                else
                {
                    double x = (b2 * c1 - b1 * c2) / determinant;
                    double y = (a1 * c2 - a2 * c1) / determinant;
                    return new Point(x, y);
                }
            }

            // Driver method 
            public static void Main(string[] args)
            {
                Point A = new Point(1, 1);
                Point B = new Point(4, 4);
                Point C = new Point(1, 8);
                Point D = new Point(2, 4);

                Point intersection = lineLineIntersection(A, B, C, D);

                if (intersection.x == double.MaxValue && intersection.y == double.MaxValue)
                {
                    Console.WriteLine("The given lines AB and CD are parallel.");
                }

                else
                {
                    // NOTE: Further check can be applied in case 
                    // of line segments. Here, we have considered AB 
                    // and CD as lines 
                    Console.Write("The intersection of the given lines AB " + "and CD is: ");
                    Point.displayPoint(intersection);
                }
            }
        }
    }
}
