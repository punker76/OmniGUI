namespace OmniGui.Space
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Defines a vector.
    /// </summary>
    public struct Vector
    {
        /// <summary>
        /// The X vector.
        /// </summary>
        private readonly double x;

        /// <summary>
        /// The Y vector.
        /// </summary>
        private readonly double y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> structure.
        /// </summary>
        /// <param name="x">The X vector.</param>
        /// <param name="y">The Y vector.</param>
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Gets the X vector.
        /// </summary>
        public double X => x;

        /// <summary>
        /// Gets the Y vector.
        /// </summary>
        public double Y => y;

        /// <summary>
        /// Converts the <see cref="Vector"/> to a <see cref="Point"/>.
        /// </summary>
        /// <param name="a">The vector.</param>
        public static explicit operator Point(Vector a)
        {
            return new Point(a.x, a.y);
        }

        

        /// <summary>
        /// Calculates the dot product of two vectors
        /// </summary>
        /// <param name="a">First vector</param>
        /// <param name="b">Second vector</param>
        /// <returns>The dot product</returns>
        public static double operator *(Vector a, Vector b)
        {
            return a.X*b.X + a.Y*b.Y;
        }

        /// <summary>
        /// Length of the vector
        /// </summary>
        public double Length => Math.Sqrt(X*X + Y*Y);

        /// <summary>
        /// Negates a vector.
        /// </summary>
        /// <param name="a">The vector.</param>
        /// <returns>The negated vector.</returns>
        public static Vector operator -(Vector a)
        {
            return new Vector(-a.x, -a.y);
        }

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>A vector that is the result of the addition.</returns>
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y);
        }

        /// <summary>
        /// Subtracts two vectors.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>A vector that is the result of the subtraction.</returns>
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y);
        }

        /// <summary>
        /// Returns the string representation of the point.
        /// </summary>
        /// <returns>The string representation of the point.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}, {1}", x, y);
        }

        /// <summary>
        /// Returns a new vector with the specified X coordinate.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <returns>The new vector.</returns>
        public Vector WithX(double x)
        {
            return new Vector(x, y);
        }

        /// <summary>
        /// Returns a new vector with the specified Y coordinate.
        /// </summary>
        /// <param name="y">The Y coordinate.</param>
        /// <returns>The new vector.</returns>
        public Vector WithY(double y)
        {
            return new Vector(x, y);
        }
    }
}