using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueManager", menuName = "ScriptableObjects/DialogueManager")]
public class DialogueManager : ScriptableObject
{
    public List<DialogueContent> DialogueContents;
    [System.Serializable]
    public struct DialogueContent
    {
        public Sprite speakerAvatar;
        public ushort id;
        public string text;
    }
}
