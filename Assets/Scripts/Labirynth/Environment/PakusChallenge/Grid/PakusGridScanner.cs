using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

namespace Labirynth.Environment.PakusChallenge.Grid
{
    public class PakusGridScanner : MonoBehaviour
    {
        [SerializeField] private int closestPointsCount = 16;
        [SerializeField] private float closestPointMaxDistance = 3f;
        
        private Transform[] transforms;
        private PakusPoint[] points;

        public PakusPoint[] Scan()
        {
            ScanTransforms();
            
            InitializePoints();

            return points;
        }

        private void ScanTransforms()
        {
            List<Transform> _transforms = GetComponentsInChildren<Transform>().ToList();
            _transforms.Remove(transform);
            transforms = _transforms.ToArray();
        }

        private void InitializePoints()
        {
            PakusPoint[] _points = new PakusPoint[transforms.Length];

            for (int i = 0; i < _points.Length; i++)
                _points[i].SetTransform(transforms[i]);

            points = _points;
            ShuffleArray.Shuffle(points);
            
            for (int i = 0; i < points.Length; i++)
                points[i].SetIndex(i);
            
            for (int i = 0; i < points.Length; i++)
                points[i].SetClosestPoints(FindClosestPoints(points[i].PointTransform.position));
        }

        private PakusPoint[] FindClosestPoints(Vector2 _position)
        {
            int _pointsFound = 0;

            List<PakusPoint> _validPoints = new List<PakusPoint>();

            for (int i = 0; i < points.Length; i++)
            {
                if (CheckDistance(_position, points[i].PointTransform.position) == true)
                {
                    _validPoints.Add(points[i]);
                    _pointsFound++;
                }

                if (_pointsFound == closestPointsCount)
                    break;
            }

            return _validPoints.ToArray();
        }

        private bool CheckDistance(Vector2 _a, Vector2 _b)
        {
            float _distance = Vector2.Distance(_a, _b);

            if (_distance <= closestPointMaxDistance)
                return true;
            
            return false;
        }
    }
}