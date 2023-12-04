// PEACHYBAND CONFIDENTIAL
// __________________
// All Rights Reserved
// [2020]-[2023].

using SibJam.Base;
using UnityEngine;

namespace SibJam.Features.Level.Views
{
    public class GrassView : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log("Touched!");
        }
    }
}