using System.IO;
using UnityEngine;

namespace GameSystems
{
    [CreateAssetMenu(menuName = "ScriptableObjects/GameManagerSettings", fileName = "GameManagerSettings")]
    public class GameManagerSettings : ScriptableObject
    {
        public TextAsset DialogueCsvFile;
    }
}