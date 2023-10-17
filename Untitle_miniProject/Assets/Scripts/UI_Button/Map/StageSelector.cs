using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelector : MonoBehaviour
{
    public static int selectedStage;
    public int stage;
    public string word;
    public TextMeshProUGUI stageText;
    public Button stageButton;


    public Color buttonColor;
    public ColorBlock buttonColorBlock;
   
    public int buttonStack;
    //버튼이 비활성화 되어야한다. 
    //stage2부터 5까지



    private void Start()
    {
        stageButton = GetComponent<Button>();
    }
    

    void Awake()
    {
        
   
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

    public void Update()
    {
        if (stage == UIManager.Instance.currentSceneIndex - 8)
        {
            stageButton.interactable = true;
            Debug.Log(UIManager.Instance.currentSceneIndex);
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
