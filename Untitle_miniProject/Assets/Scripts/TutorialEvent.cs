using UnityEngine;
using UnityEngine.UI;

public class TutorialEvent : MonoBehaviour
{
    public GameObject Robs;
    public GameObject portal;
    public GameObject[] Arrows;
    public DialogugTalkBubble TalkQeue;
    public GameObject NextTalkPanel;

    public ComponentScroll scroll; //컴포넌트스크롤
    public ComponentManager compoenetmanager; // 플레이어 컴포넌트창

    public PlayerInput playerinput;
    public Transform playerTrans;

    public int progress;

    // Update is called once per frame
    void Update()
    {
        if(progress==0 && TalkQeue.Thesentens == "0:아래에 Component창 있지?/그거 열어봐.")
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

        if(progress == 1 && TalkQeue.Thesentens == "0:좋아! 거기에 있는 컴포넌트를/나한테 드래그해서 부여해줘!")
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

        if (progress == 2 && TalkQeue.Thesentens == "0:잠깐... 아직 안되는데?/컴포넌트 창을 다시 닫아봐")
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
            Arrows[4].SetActive(true);
        }

        if (progress == 3 && playerTrans.transform.position.x != -11)
        {
            NextTalkPanel.GetComponent<Image>().raycastTarget = false;
            progress = 4;
            TalkQeue.GoNext();
            Arrows[4].SetActive(false);
            Arrows[3].SetActive(true);
        }

        if (progress == 4 && playerTrans.position.x>=4)
        {
            playerinput.canMove = false;
            playerinput.move = 0;
            NextTalkPanel.GetComponent<Image>().raycastTarget = true;
            TalkQeue.GoNext();
            Arrows[3].SetActive(false);
            Arrows[4].SetActive(false);
            progress += 1;
        }

        if (progress == 5 && TalkQeue.Thesentens == "0:거기서!!")
        {
            playerinput.canMove = true;
            portal.SetActive(true);
            NextTalkPanel.GetComponent<Image>().raycastTarget = true;
            Robs.GetComponent<Animator>().SetTrigger("isEnd");
            progress = 6;
        }


    }
}
