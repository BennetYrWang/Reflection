using System;

public struct DialogueSentence
{
    public int id;
    public int next;
    public readonly string text;
    public Action action;
        
    //Command:
    // playSfx(name)
    // changeMusic(name)
    // postSprite(name, screenPosX, screenPosY) : post a sprite on the screen. screen position is 0-1 float value. 0,0 is the top-left corner
    // createBranch(choice1NextSentenceId, choice1Text, choice2NextSentenceId, choice2Text ,.....)
    // set
}