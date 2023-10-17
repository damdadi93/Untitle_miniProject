using UnityEngine;
using UnityEngine.UI;

public class TutorialEvent : MonoBehaviour
{
    public GameObject Robs;
    public GameObject portal;
    public GameObject[] Arrows;
    public DialogugTalkBubble TalkQeue;
    public GameObject NextTalkPanel;

    public ComponentScroll scroll; //������Ʈ��ũ��
    public ComponentManager compoenetmanager; // �÷��̾� ������Ʈâ

    public PlayerInput playerinput;
    public Transform playerTrans;

    public int progress;

    // Update is called once per frame
    void Update()
    {
        if(progress==0 && TalkQeue.Thesentens == "0:�ű� Componentâ����? �װ� �����.")
        {
            NextTalkPanel.GetComponent<Image>().raycastTarget = false;
            Arrows[0].SetActive(true);
        }

        if (progress == 0 && !scroll.isdrag && scroll.targetPos == 0)
        {
            NextTalkPanel.GetComponent<Image>().raycastTarget = true;
            Arrows[0].SetActive(false);
            progress = 1;
            TalkQeue.GoNext();
        }

        if(progress == 1 && TalkQeue.Thesentens == "0:����! �ű⿡ �ִ� ������Ʈ�� ������ �巡���ؼ� �ο�����!")
        {
            NextTalkPanel.GetComponent<Image>().raycastTarget = false;
            Arrows[1].SetActive(true);
        }

        if (progress == 1 && compoenetmanager.MoveComponent == 1)
        {
            NextTalkPanel.GetComponent<Image>().raycastTarget = true;
            Arrows[1].SetActive(false);
            progress = 2;
            TalkQeue.GoNext();
        }

        if (progress == 2 && TalkQeue.Thesentens == "0:���... ������Ʈ â�� �ٽ� �ݾƺ�")
        {
            NextTalkPanel.GetComponent<Image>().raycastTarget = false;
            Arrows[2].SetActive(true);
        }

        if (progress == 2 && !scroll.isdrag && scroll.targetPos == 1)
        {
            NextTalkPanel.GetComponent<Image>().raycastTarget = false;
            Arrows[2].SetActive(false);
            progress = 3;
            TalkQeue.GoNext();
            Arrows[3].SetActive(true);
            Arrows[4].SetActive(true);
        }

        if (progress == 3 && playerTrans.position.x>=4)
        {
            playerinput.canMove = false;
            playerinput.move = 0;
            NextTalkPanel.GetComponent<Image>().raycastTarget = true;
            TalkQeue.GoNext();
            Arrows[3].SetActive(false);
            Arrows[4].SetActive(false);
            progress += 1;
        }

        if (progress == 4 && TalkQeue.Thesentens == "0:�ű⼭!!")
        {
            playerinput.canMove = true;
            portal.SetActive(true);
            NextTalkPanel.GetComponent<Image>().raycastTarget = true;
            Robs.GetComponent<Animator>().SetTrigger("isEnd");
            progress = 5;
        }


    }
}
