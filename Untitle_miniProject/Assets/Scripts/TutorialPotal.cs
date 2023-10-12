using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPotal : MonoBehaviour
{
    public GameObject Robs;
    public GameObject Potal;
    public GameObject Canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Robe")
        {
            Robs.SetActive(false);
            Potal.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (collision.CompareTag("Player") && !Canvas.activeSelf)
        {
            // �÷��̾ Ʈ���ſ� ���� ��� VictoryGameObject�� Ȱ��ȭ�մϴ�.
            Debug.Log("victory");
            SceneManager.LoadScene("SceneSelect");
        }
    }
}
