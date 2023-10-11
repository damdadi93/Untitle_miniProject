using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IPointerClickHandler
{

    public static UIManager Instance { get; private set; }
    [Header("Start")]
    public GameObject startpanel;
    public GameObject OpeningCanvas;
    public GameObject dialoguePanel;
    public GameObject dialogue;
    public PublicSequence forprologue;
    public PublicSequence foropening;

    [Header("Flash")]
    public Image flashImage;
    public float flashDuration = 200f;
    public Color flashColor = Color.white;

    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        else
        {
            Instance = this;
        }
    }

    public void fornewGame()
    {
        SceneManager.LoadScene("Prologue");
        if (DialogueManager.Instance != null)
        {
            DialogueManager.Instance.StartDialogue(forprologue.defaultDialoge, "Prologue");
        }
    }
    public void forcontinueGame()
    {
        // 맵화면 보이게
        Debug.Log("forcontinue");
    }
    public void forExitGame()
    {
        Application.Quit();
    }
    public void fordialoguePanel()
    {
        dialoguePanel.SetActive(!dialoguePanel.activeSelf);
    }
    public void fordialogue()
    {
        dialogue.SetActive(!dialogue.activeSelf);
    }
    public void foropeningCanvas()
    {
        OpeningCanvas.SetActive(!OpeningCanvas.activeSelf);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (dialoguePanel.activeSelf)
        {
            DialogueManager.Instance.UpdateDialogue();
        }
        if (startpanel.activeSelf)
        {
            startpanel.SetActive(false);
            SceneManager.LoadScene("Opening");
            DialogueManager.Instance.StartDialogue(foropening.defaultDialoge, "Opening");
        }
    }
    public void FlashScreen()
    {
        flashImage.gameObject.SetActive(true);
        StartCoroutine(FlashCoroutine());
    }

    private IEnumerator FlashCoroutine()
    {

        flashImage.color = new Color(0f, 0f, 0f, 0f);

        float elapsedTime = 0f;
        while (elapsedTime < flashDuration)
        {
            float t = elapsedTime / flashDuration;
            flashImage.color = Color.Lerp(flashColor, flashImage.color, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        flashImage.gameObject.SetActive(false);
    }
}
