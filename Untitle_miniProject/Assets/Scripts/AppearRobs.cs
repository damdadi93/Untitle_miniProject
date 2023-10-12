using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearRobs : MonoBehaviour
{
    public GameObject Robs;
    public DialogugTalkBubble TalkQeue;

    // Update is called once per frame
    void Update()
    {
        if (!Robs.activeSelf && TalkQeue.Thesentens.speaker == "Robs")
        {
            Robs.SetActive(true);
            return;
        }
        if (Robs.activeSelf && Robs.GetComponent<MoveScript>().enabled == false)
        {
            if (TalkQeue.Thesentens.speaker != "Robs")
            {
                Robs.GetComponent<MoveScript>().enabled = true;
            }
        }
    }
}
