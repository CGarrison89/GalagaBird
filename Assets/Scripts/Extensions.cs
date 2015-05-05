using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class RendererExtensions
{
    public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }

    /// <summary>
    ///   Generates values from a triangular distribution.
    /// </summary>
    /// <remarks>
    /// See http://en.wikipedia.org/wiki/Triangular_distribution for a description of the triangular probability distribution and the algorithm for generating one.
    /// </remarks>
    /// <param name="r"></param>
    /// <param name = "a">Minimum</param>
    /// <param name = "b">Maximum</param>
    /// <param name = "c">Mode (most frequent value)</param>
    /// <returns></returns>
    public static double NextTriangular(this System.Random r, double a, double b, double c)
    {
        var u = r.NextDouble();

        return u < (c - a) / (b - a)
                   ? a + Math.Sqrt(u * (b - a) * (c - a))
                   : b - Math.Sqrt((1 - u) * (b - a) * (b - c));
    }
}