public struct DialogueChoice
{
    public readonly DialogueChoiceBranch[] Choices;

    public DialogueChoice(DialogueChoiceBranch[] choices)
    {
        Choices = choices;
    }
}