using Bennet.Util.IO;
using UnityEngine;

namespace GameSystems
{
    public class GameManager : MonoBehaviour
    {
        public GameManagerSettings Settings;
        private void Awake()
        {
        
        }

        void LoadDialogues()
        {
            CsvLoader loader = new();
            var parsedData = loader.ParseFileContent(Settings.DialogueCsvFile);
        }
    }
}
