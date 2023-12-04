// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using UnityEngine;

namespace SibJam.Features.UI
{
    public class CanvasPresenter : MonoBehaviour
    {
        [SerializeField] private Transform _infoHolder;

        public Transform InfoHolder => _infoHolder;
    }
}