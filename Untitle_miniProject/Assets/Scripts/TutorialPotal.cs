using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPotal : MonoBehaviour
{
    public GameObject Robs;
    public GameObject Potal;
    public GameObject Canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 플레이어가 트리거에 들어온 경우 VictoryGameObject을 활성화합니다.
            Debug.Log("victory");
            SceneManager.LoadScene("SceneSelect");
        }
    }
}
