using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [Header("Dialogue Components")]
    public TMP_Text speakerText;
    public TMP_Text dialougeText;
    public Image Gameimage;
    Queue<DialogueLine> dialogueQueue;
    bool istyping = false;
    public Animator dialougeAnimator;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StartDialogue(List<DialogueLine> dialogueLinesToQueue)
    {
        dialogueQueue = new Queue<DialogueLine>(dialogueLinesToQueue);
        Debug.Log($"dialogueQueue.Count {dialogueQueue.Count}");
        UpdateDialogue();
    }
    public void UpdateDialogue()
    {
        if (istyping)
        {
            istyping = false;
            return;
        }
        dialougeText.text = string.Empty;
        if (dialogueQueue.Count == 1)
        {
            dialougeAnimator.SetBool("Shake", true);
            
        }
        if(dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine line = dialogueQueue.Dequeue();
       
        Talk(line.speaker, line.message, line.sprite);
    }

    public void EndDialogue()
    {
        dialougeAnimator.SetBool("Shake", false);
        UIManager.Instance.fordialoguePanel();
        UIManager.Instance.FlashScreen();
    }
    public void Talk(string speaker, string message, Sprite image)
    {
        speakerText.text = speaker;

        speakerText.transform.parent.gameObject.SetActive(speaker != "");
        if (Gameimage != null)
        {
            Gameimage.sprite = image;
        }
        StartCoroutine(TypeText(message));
    }
    IEnumerator TypeText(string textToType)
    {
        istyping = true;
        char[] charsToType = textToType.ToCharArray();
        for (int i = 0; i < charsToType.Length; i++)
        {
            dialougeText.text += charsToType[i];
            yield return new WaitForSeconds(0.05f);
            if (!istyping)
            {
                dialougeText.text = textToType;
                break;
            }

        }
        istyping = false;
    }
}
