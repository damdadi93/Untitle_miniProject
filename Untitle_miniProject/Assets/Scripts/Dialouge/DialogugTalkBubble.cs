using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine.UI;


public class DialogugTalkBubble : MonoBehaviour
{
    public TextMeshProUGUI txtSentence;
    public DialogString forprologue;

    public GameObject TalkBubble;
    public Transform[] TalkTrans;
    public GameObject Canvas;

    public Image friend;
    Color color = new Color(0, 0, 0, 0);

    public Queue<string> sentences = new Queue<string>();  //큐생성

    public string Thesentens;

    public bool isCorutine = false;


    private void Start()
    {
        Begin(forprologue);
        Next();
    }
    //대화 시작

    public void Begin(DialogString dias)
    {
        sentences.Clear();  //큐에 내장되어있는 클리어 함수
        foreach (string sentence in dias.dialog)
        {
            sentences.Enqueue(sentence);
        }

    }

    void Update()
    {
        TalkBubble.transform.position = TalkTrans[int.Parse(Thesentens.Split(":")[0])].position;

        friend.color = Color.Lerp(friend.color, color,0.1f);
    }

    //큐에서 문장과 화자 꺼내서 Thesentens네 저장하고 말풍선 생성.

    public void GoNext()//무조건 다음으로
    {
        StopAllCoroutines();
        isCorutine = false;
        Next();
    }
    public void Next()
    {
        if (sentences.Count == 0 && !isCorutine)
        {
            End();
        }
        else
        {
            if (isCorutine)
            {
                StopAllCoroutines();

                txtSentence.text = "";
                foreach (char letter in Thesentens.Split(":")[1])
                {
                    if (letter.Equals('/')) { 
                        txtSentence.text += "<br>";
                        continue;
                    }
                    else txtSentence.text += letter;
                }

                isCorutine = false;
            }
            else
            {
                Thesentens = sentences.Dequeue();


                TalkBubble.SetActive(true);

                if (Thesentens.Split(":")[0] == "1")//일러스트
                    color = new Color(1, 1, 1, 1);
                else
                    color = new Color(1, 1, 1, 0);

                Typing(Thesentens.Split(":")[1]);
            }
        }

    }

    //타이핑할 TMP파일 배열을 받는 메소드
    public void Typing(string str)
    {
        txtSentence.text = string.Empty;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(str));
    }
    //타이핑 모션 함수
    IEnumerator TypeSentence(string sentence)
    {
        isCorutine = true;
        foreach (char letter in sentence)
        {
            if(letter.Equals('/')) txtSentence.text += "<br>";
            else txtSentence.text += letter;

            yield return new WaitForSeconds(0.1f);
        }
        isCorutine = false;
    }
    //대화 끝나면 대화창 끄기.
    private void End()
    {

        Canvas.SetActive(false);

    }
        public string DeQ()
    {
        var sentence = sentences.Dequeue();
        return sentence;
    }
}
