using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class AppearRobs : MonoBehaviour
{
    public GameObject Robs;
    public GameObject Arrow;
    public DialogugTalkBubble TalkQeue;

    // Update is called once per frame
    void Update()
    {
        if(TalkQeue.Thesentens.message == "�Ȱǰ�?")
            Arrow.SetActive(false);
        if(TalkQeue.Thesentens.message == "�ű��ִ� ������Ʈ�� ������ �÷���!")
        {
            
            for(float i= 1 * Time.deltaTime; i< 1000; i+=1 * Time.deltaTime)
            {
                if (i % (30*Time.deltaTime) == 0) 
                {
                    Arrow.SetActive(!Arrow.activeSelf);
                    Debug.Log("Arrow active");
                }
                    
            }
            
        }
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
