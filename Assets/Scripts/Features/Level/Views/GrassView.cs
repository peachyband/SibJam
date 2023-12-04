// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Base;
using UnityEngine;
using Zenject;

namespace SibJam.Features.Level.Views
{
    public class GrassView : MonoBehaviour, IInteractable
    {
        [Inject]
        public void Construct(Vector2 position)
        {
            transform.position = position;
        }
        public void Interact()
        {
            Debug.Log("Touched!");
        }
    }
}