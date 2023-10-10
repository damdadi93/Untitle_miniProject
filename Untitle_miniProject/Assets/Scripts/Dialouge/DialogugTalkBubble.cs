using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using Unity.VisualScripting;



[System.Serializable]    //스크립트 직렬화
public class Dialogue
{
    public List<string> sentences;
}

public class DialogugTalkBubble : MonoBehaviour
{
    public TextMeshProUGUI txtSentence;
    public Dialogue info;
    Queue<string> sentences = new Queue<string>();  //큐생성

    private void Start()
    {
        Begin(info);
    }
    //대화 시작
    public void Begin(Dialogue info)
    {
        sentences.Clear();  //큐에 내장되어있는 클리어 함수

        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Next();
    }
    //버튼 클릭 시 다음 대화로 넘어감
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
    //타이핑 모션 함수
    IEnumerator TypeSentence(string sentence)
    {
        foreach (var letter in sentence)
        {
            txtSentence.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }
    //대화 끝
    private void End()
    {
        if (sentences != null)
        {
            Debug.Log("end");
        }
    }
}
