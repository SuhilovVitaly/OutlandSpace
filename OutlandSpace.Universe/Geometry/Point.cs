﻿using System;

namespace OutlandSpace.Universe.Geometry
{
    [Serializable]
    public class Point
    {
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get; set; }
        public float Y { get; set; }
    }
}