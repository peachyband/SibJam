// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Features.Level.Models;
using UnityEngine;
using Zenject;

namespace SibJam.Features.Level.Views
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private Vector2 _boundsMin;
        [SerializeField] private Vector2 _boundsMax;
        
        private LevelModel _levelModel;

        [Inject]
        public void Construct(LevelModel levelModel)
        {
            _levelModel = levelModel;
        }

        private void Start()
        {
            var topLeft = transform.TransformPoint(_boundsMin.x * Vector2.right + _boundsMax.y * Vector2.up);
            var topRight = transform.TransformPoint(_boundsMax.x * Vector2.right + _boundsMax.y * Vector2.up);
            var bottomLeft = transform.TransformPoint(_boundsMin.x * Vector2.right + _boundsMin.y * Vector2.up);
            var bottomRight = transform.TransformPoint(_boundsMax.x * Vector2.right + _boundsMin.y * Vector2.up);
            
            _levelModel.FillBounds(topRight, topLeft, 
                bottomRight, bottomLeft);
        }

        private void OnDrawGizmos()
        {
            if (_levelModel == null) return;
            
            Gizmos.color = Color.green;
            Gizmos.DrawLine(_levelModel.TopLeft, _levelModel.TopRight);
            Gizmos.DrawLine(_levelModel.TopRight, _levelModel.BottomRight);
            Gizmos.DrawLine(_levelModel.BottomRight, _levelModel.BottomLeft);
            Gizmos.DrawLine(_levelModel.BottomLeft, _levelModel.TopLeft);
            
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_levelModel.GetCentre(), 0.4f);
        }
    }
}