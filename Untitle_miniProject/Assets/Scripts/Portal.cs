using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾ Ʈ���ſ� ���� ��� VictoryGameObject�� Ȱ��ȭ�մϴ�.
            if (UIManager.Instance != null)
            {
                UIManager.Instance.forvictoryPanel();

            }
            Debug.Log("victory");
        }
    }
}
