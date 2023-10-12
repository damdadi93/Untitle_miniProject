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

    public Queue<DialogueLine> sentences = new Queue<DialogueLine>();  //큐생성

    private void Start()
    {
        Begin(forprologue);
    }
    //대화 시작

    public void Begin(PublicSequence info)
    {
        sentences.Clear();  //큐에 내장되어있는 클리어 함수
        Debug.Log("beforeEnQ");
        foreach (var sentence in forprologue.defaultDialoge)
        {
            sentences.Enqueue(sentence);
        }

    }

    //큐에서 문장과 화자 꺼내서 Thesentens네 저장하고 말풍선 생성.
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

    //타이핑할 TMP파일 배열을 받는 메소드
    public void Typing(int i)
    {
        txtSentence[i].text = string.Empty;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(Thesentens));
    }
    //타이핑 모션 함수
    IEnumerator TypeSentence(DialogueLine sentence)
    {
        foreach (var letter in sentence.message)
        {
            txtSentence[i].text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }
    //대화 끝나면 대화창 끄기.
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
