using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueEvent : MonoBehaviour
{
    public void OnEnlargeAnimationComplete()
    {
        UIManager.Instance.fordialoguePanel();
        SceneManager.LoadScene("Tutorial");
    }
}
