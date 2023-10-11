using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어가 트리거에 들어온 경우 VictoryGameObject을 활성화합니다.
            if (UIManager.Instance != null)
            {
                UIManager.Instance.forvictoryPanel();
            }
            Debug.Log("victory");
        }
    }
}
