namespace Algorithms
{
    public class Point
    {

        public int X { get; set; }
        public int Y { get; set; }

        private bool DoOverlap(Point l1, Point r1, Point l2, Point r2)
        {
            // If one rectangle is on left side of other
            if (l1.X > r2.X || l2.X > r1.X)
                return false;

            // If one rectangle is above other
            if (l1.Y < r2.Y || l2.Y < r1.Y)
                return false;

            return true;
        }

    }

}
