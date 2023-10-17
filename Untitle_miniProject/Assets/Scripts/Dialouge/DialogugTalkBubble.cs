using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using Unity.VisualScripting;


public class DialogugTalkBubble : MonoBehaviour
{
    public TextMeshProUGUI txtSentence;
    public DialogString forprologue;

    public GameObject TalkBubble;
    public Transform[] TalkTrans;
    public GameObject Canvas;

    public GameObject friend;

    public Queue<string> sentences = new Queue<string>();  //ť����

    public string Thesentens;

    public bool isCorutine = false;


    private void Start()
    {
        Begin(forprologue);
        Next();
    }
    //��ȭ ����

    public void Begin(DialogString dias)
    {
        sentences.Clear();  //ť�� ����Ǿ��ִ� Ŭ���� �Լ�
        foreach (string sentence in dias.dialog)
        {
            sentences.Enqueue(sentence);
        }

    }

    void Update()
    {
        TalkBubble.transform.position = TalkTrans[int.Parse(Thesentens.Split(":")[0])].position;
    }

    //ť���� ����� ȭ�� ������ Thesentens�� �����ϰ� ��ǳ�� ����.

    public void GoNext()//������ ��������
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
                txtSentence.text = Thesentens.Split(":")[1];
                isCorutine = false;
            }
            else
            {
                Thesentens = sentences.Dequeue();


                TalkBubble.SetActive(true);

                if (Thesentens.Split(":")[0] == "1")//�Ϸ���Ʈ
                    friend.SetActive(true);
                else
                    friend.SetActive(false);

                Typing(Thesentens.Split(":")[1]);
            }
        }

    }

    //Ÿ������ TMP���� �迭�� �޴� �޼ҵ�
    public void Typing(string str)
    {
        txtSentence.text = string.Empty;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(str));
    }
    //Ÿ���� ��� �Լ�
    IEnumerator TypeSentence(string sentence)
    {
        isCorutine = true;
        foreach (var letter in sentence)
        {
            txtSentence.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
        isCorutine = false;
    }
    //��ȭ ������ ��ȭâ ����.
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
