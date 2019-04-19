using System;
using System.Collections.Generic;

namespace PadawansTask9
{
    public class CartesianCoordinates
    {
        public static List<Point> GetNeighbors(Point point, int range, params Point[] points)
        {
            // put your code here
            //throw new NotImplementedException();
            if (points == null)
            {
                throw new ArgumentNullException();
            }

            if(range <= 0)
            {
                throw new ArgumentException();
            }
            List<Point> resultList = new List<Point>();
            for (int i = 0; i < points.Length; i++)
            {
                if (Math.Abs(points[i].X - point.X) <= range && Math.Abs(points[i].Y - point.Y) <= range)
                {
                    resultList.Add(points[i]);
                }
            }
            return resultList;
        }
    }
}