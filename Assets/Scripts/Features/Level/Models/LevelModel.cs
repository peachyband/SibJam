// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using UnityEngine;

namespace SibJam.Features.Level.Models
{
    public class LevelModel
    {
        public Vector2 TopRight { get; private set; }
        public Vector2 TopLeft { get; private set; }
        public Vector2 BottomRight { get; private set; }
        public Vector2 BottomLeft { get; private set; }

        public void FillBounds(Vector2 top, Vector2 right, 
            Vector2 bottom, Vector2 left)
        {
            TopRight = top;
            TopLeft = right;
            BottomRight = bottom;
            BottomLeft = left;
        }

        public Vector2 GetRandomPositionInside()
        {
            return new Vector2(Random.Range(BottomLeft.x, BottomRight.x), 
                Random.Range(BottomRight.y, TopRight.y));
        }

        public Vector2 GetCentre() => new (Mathf.Lerp(BottomLeft.x, BottomRight.x, 0.5f), 
            Mathf.Lerp(BottomLeft.y, TopRight.y, 0.5f));
    }
}