using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using Unity.VisualScripting;


public class DialogugTalkBubble : MonoBehaviour
{
    public TextMeshProUGUI[] txtSentence;
    public PublicSequence forprologue;
    public DialogueLine Thesentens;

    public GameObject Programmer;
    public GameObject Friend;
    public GameObject Robs;
    public GameObject Canvas;

    public int i;

    public Queue<DialogueLine> sentences = new Queue<DialogueLine>();  //ť����

    private void Start()
    {
        Begin(forprologue);
    }
    //��ȭ ����

    public void Begin(PublicSequence info)
    {
        sentences.Clear();  //ť�� ����Ǿ��ִ� Ŭ���� �Լ�
        Debug.Log("beforeEnQ");
        foreach (var sentence in forprologue.defaultDialoge)
        {
            sentences.Enqueue(sentence);
        }

    }

    //ť���� ����� ȭ�� ������ Thesentens�� �����ϰ� ��ǳ�� ����.
    public void Next()
    {
        Thesentens = DeQ();
        Debug.Log("Start Next(): " + Thesentens.speaker + Thesentens.message);
        
        if(Thesentens.speaker == "Programmer")
        {
            Programmer.SetActive(true);
            Friend.SetActive(false);
            Robs.SetActive(false);
            i = 0;
            Typing(i);
        }
        else if (Thesentens.speaker == "Friend")
        {
            Friend.SetActive(true);
            Programmer.SetActive (false);
            Robs.SetActive (false);
            i = 1;
            Typing(i);
        }
        else if (Thesentens.speaker == "Robs")
        {
            Robs.SetActive(true);
            Programmer.SetActive(false);
            Friend.SetActive(false);
            i = 2;
            Typing(i);
        }
        if (sentences.Count == 0)
        {
            End();
            return;
        }

    }

    //Ÿ������ TMP���� �迭�� �޴� �޼ҵ�
    public void Typing(int i)
    {
        txtSentence[i].text = string.Empty;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(Thesentens));
    }
    //Ÿ���� ��� �Լ�
    IEnumerator TypeSentence(DialogueLine sentence)
    {
        foreach (var letter in sentence.message)
        {
            txtSentence[i].text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }
    //��ȭ ������ ��ȭâ ����.
    private void End()
    {
        if (Thesentens != null)
        {
            Canvas.SetActive(false);
        }
    }
        public DialogueLine DeQ()
    {
        var sentence = sentences.Dequeue();
        Debug.Log("DeQ!"+ sentence.speaker);
        return sentence;
    }
}
