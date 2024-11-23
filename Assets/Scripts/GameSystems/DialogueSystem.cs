using System;
using UnityEngine;

namespace GameSystems
{
    public class DialogueSystem : MonoBehaviour
    {
        public static DialogueSystem Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
        
        
    }
}