using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelector : MonoBehaviour
{
    public static int selectedStage;
    public int stage;
    public string word;
    public TextMeshProUGUI stageText;

    private Button button;
    void Awake()
    {
        button = GetComponent<Button>();
        stageText = GetComponentInChildren<TextMeshProUGUI>();
        word = "T";
        //stageText.text = stage.ToString();
        if (stage == 0)
        {
            
            stageText.text = word.ToString();

        }
        if (stageText)
        {
            stageText.text = stage.ToString();
            if(stage ==0)
            {
                stageText.text = word;
            }
        }
        else
        {
            //Debug.LogError("StageText not found!");
        }
    }

    public void OpenScene()    
    {
        selectedStage = stage;
        
        if (stage == 0)
        {
            SceneManager.LoadScene("Tutorial");
            //SceneManager.LoadScene("UniversalStage(Background)");
        }
        else
        {
           // SceneManager.LoadScene("UniversalStage(Background)");
            SceneManager.LoadScene("Stage" + stage.ToString());
        }
    }

  

}
