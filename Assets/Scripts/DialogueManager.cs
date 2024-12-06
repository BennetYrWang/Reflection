using System;
using System.Collections.Generic;
using System.Dynamic;

public class DialogueManager
{
    public bool duringDialogue { get; private set; }
    private Dictionary<int, DialogueSentence> dialogues;

    public DialogueSentence CurrentDialogueSentence { get; private set; }
    public DialogueChoice CurrentChoice { get; private set; }

    public void GotoNextSentence()
    {
            
    }

    public void CreateChoiceBranch()
    {
        dynamic expandoObject = new ExpandoObject();
    }

    public void StartDialogue(int sentenceId)
    {
        if (duringDialogue)
            throw new InvalidOperationException("Cannot Start a new Dialogue while there exist one");

        throw new NotImplementedException();
    }
}