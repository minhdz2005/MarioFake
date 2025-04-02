using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level 4"); // Chuyển sang Level2
            Destroy(gameObject); // Xóa chìa khóa sau khi thu thập
        }
    }
}
