using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPotal : MonoBehaviour
{
    public GameObject Robs;
    public GameObject Potal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Robe")
        {
            Robs.SetActive(false);
            Potal.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
