using System.Collections;
using System.Collections.Generic;
using Interaction;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public DialogueBox box;
    public void Message()
    {
        box.TextMeshProUGUI.text = "";
    }
}
