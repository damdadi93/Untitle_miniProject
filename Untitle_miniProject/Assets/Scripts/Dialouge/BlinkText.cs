using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlinkText : MonoBehaviour
{
    public TMP_Text textComponent;
    public float blinkInterval = 0.5f; // ±ôºýÀÓ °£°Ý ¼³Á¤

    private bool isBlinking = false;

    private void Start()
    {
        StartBlinking();
    }

    public void StartBlinking()
    {
        if (!isBlinking)
        {
            StartCoroutine(BlinkCoroutine());
        }
    }

    public void StopBlinking()
    {
        if (isBlinking)
        {
            StopCoroutine(BlinkCoroutine());
            isBlinking = false;
        }
    }

    private IEnumerator BlinkCoroutine()
    {
        isBlinking = true;

        while (true)
        {
            textComponent.color = (textComponent.color == Color.white) ? Color.clear : Color.white;

            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
