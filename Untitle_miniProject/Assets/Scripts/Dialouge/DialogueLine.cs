using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueLine
{
    public string speaker;
    [TextArea(2, 8)]
    public string message;
    public Sprite sprite;
    public DialogueLine(string speaker, string message, Sprite image)
    {
        this.speaker = speaker;
        this.message = message;
        this.sprite = image;
    }
    
    public string GetSpeaker()
    {
        return speaker;
    }
}
