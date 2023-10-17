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

    [Header("Victory&Retry")]
    public GameObject victoryPanel;
    public GameObject RetryPanel;

    private void Awake()
    {
        SetResolution();//해상도
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        else
        {
            Instance = this;
        }
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        victoryPanel.SetActive(false);
    }

    public void RetryScene()
    {
        victoryPanel.SetActive(false);
        RetryPanel.SetActive(false);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void forMapButton()
    {
        victoryPanel.SetActive(false);
        RetryPanel.SetActive(false);
        SceneManager.LoadScene("SceneSelect");
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
    public void forvictoryPanel()
    {
        victoryPanel.SetActive(true);
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

    public void SetResolution()//해상도
    {
        int setWidth = 800; // 사용자 설정 너비
        int setHeight = 600; // 사용자 설정 높이

        int deviceWidth = Screen.width; // 기기 너비 저장
        int deviceHeight = Screen.height; // 기기 높이 저장

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution 함수 제대로 사용하기

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // 새로운 너비
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // 새로운 높이
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
        }
    }
}
