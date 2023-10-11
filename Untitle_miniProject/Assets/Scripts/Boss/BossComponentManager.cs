using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossComponentManager : MonoBehaviour
{
    public GameObject MoveComponentPrefab;
    public GameObject SwordCompoenntPrefab;
    public GameObject BowCompoenntPrefab;

    public int Move;//°Ë
    public int Sword;//°Ë
    public int Bow;//È°


    // Start is called before the first frame update

    // Update is called once per frame
    private void Awake()
    {
        Rebulid();
    }
    void Rebulid()
    {
        if (Move > 0)
        {
            MoveComponentPrefab.SetActive(true);
            MoveComponentPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "x" + Move;
        }
        else
        {
            MoveComponentPrefab.SetActive(false);
        }
        if (Sword > 0)
        {
            SwordCompoenntPrefab.SetActive(true);
        }
        else
        {
            SwordCompoenntPrefab.SetActive(false);
        }
        if (Bow > 0)
        {
            BowCompoenntPrefab.SetActive(true);
        }
        else
        {
            BowCompoenntPrefab.SetActive(false);
        }
    }
}
