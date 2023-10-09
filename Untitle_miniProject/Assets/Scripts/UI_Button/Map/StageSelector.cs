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
    //public string word;
    public TextMeshProUGUI stageText;
    

   
    void Awake()
    {
        stageText = GetComponentInChildren<TextMeshProUGUI>();

        //stageText.text = stage.ToString();
        //if(stage == 0)
        //{
        //    word = "T";
        //    stageText.text = word;

        //}
        if(stageText)
        {
            stageText.text = stage.ToString();
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
        }
        else
        {
            SceneManager.LoadScene("Stage" + stage.ToString());
        }
    }

  

}
