using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using Unity.VisualScripting;



[System.Serializable]    //��ũ��Ʈ ����ȭ
public class Dialogue
{
    public List<string> sentences;
}

public class DialogugTalkBubble : MonoBehaviour
{
    public TextMeshProUGUI txtSentence;
    public Dialogue info;
    Queue<string> sentences = new Queue<string>();  //ť����

    private void Start()
    {
        Begin(info);
    }
    //��ȭ ����
    public void Begin(Dialogue info)
    {
        sentences.Clear();  //ť�� ����Ǿ��ִ� Ŭ���� �Լ�

        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Next();
    }
    //��ư Ŭ�� �� ���� ��ȭ�� �Ѿ
    public void Next()
    {
        if (sentences.Count == 0)
        {
            End();
            return;
        }
        txtSentence.text = string.Empty;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentences.Dequeue()));
    }
    //Ÿ���� ��� �Լ�
    IEnumerator TypeSentence(string sentence)
    {
        foreach (var letter in sentence)
        {
            txtSentence.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }
    //��ȭ ��
    private void End()
    {
        if (sentences != null)
        {
            Debug.Log("end");
        }
    }
}
