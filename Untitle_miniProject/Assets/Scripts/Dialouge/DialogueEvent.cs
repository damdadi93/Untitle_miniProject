using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueEvent : MonoBehaviour
{
    public void OnEnlargeAnimationComplete()
    {
        UIManager.Instance.OpeningCanvas.SetActive(false);
        Debug.Log("opening");
        SceneManager.LoadScene("Tutorial");
        DialogueManager.Instance.dialougeAnimator.SetBool("Enlarge", false);
    }
}
