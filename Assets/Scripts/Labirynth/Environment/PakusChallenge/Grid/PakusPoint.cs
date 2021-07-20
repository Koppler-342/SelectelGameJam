using UnityEngine;

namespace Labirynth.Environment.PakusChallenge.Grid
{
    public struct PakusPoint
    { 
        private PakusPoint[] closestPoints; 
        private Transform pointTransform;
        private int indexInTotalList;

        public PakusPoint[] ClosestPoints => closestPoints;
        public Transform PointTransform => pointTransform;
        public int Index => indexInTotalList;

        public void SetTransform(Transform _transform)
        {
            pointTransform = _transform;
        }

        public void SetClosestPoints(PakusPoint[] _closestPoints)
        {
            closestPoints = _closestPoints;
        }

        public void SetIndex(int _index)
        {
            indexInTotalList = _index;
        }
    }
}