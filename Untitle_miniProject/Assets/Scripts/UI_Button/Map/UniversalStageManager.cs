using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UniversalStageManager : MonoBehaviour
{

    //게임 배경화면 씬별로 불러오기
    public Sprite[] backgrounds;
    public Image background;
    public TextMeshProUGUI textMeshProUGUI;


    // Start is called before the first frame update
    void Start()
    {
        int stage = StageSelector.selectedStage;
        Debug.Log(stage);
        textMeshProUGUI.text = "Stage" + stage.ToString();
        
        background.sprite = backgrounds[stage - 1];
    }

   
    public void GoBackToStageSelection()
    {
        SceneManager.LoadScene("SceneSelect");
    }
}
