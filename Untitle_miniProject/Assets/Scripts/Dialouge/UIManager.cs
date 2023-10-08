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
    public GameObject startButton;
    public GameObject dialoguePanel;
    public PublicSequence publicSequence;

    [Header("Flash")]
    public Image flashImage;
    public float flashDuration = 100f;
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
    public void forStartButton()
    {
        SceneManager.LoadSceneAsync("Zombie");
        startButton.SetActive(false);

        dialoguePanel.SetActive(true);
        DialogueManager.Instance.StartDialogue(publicSequence.defaultDialoge);
    }
    public void fordialoguePanel()
    {
        dialoguePanel.SetActive(!dialoguePanel.activeSelf);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (dialoguePanel.activeSelf)
        {
            DialogueManager.Instance.UpdateDialogue();
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
