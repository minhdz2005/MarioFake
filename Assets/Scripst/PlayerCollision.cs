using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            audioManager.PlayCoinSound();
            gameManager.AddScore(1);
        }
        else if (collision.CompareTag("Trap"))
        {
            gameManager.GameOver();
        }
        else if (collision.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }
        else if (collision.CompareTag("Key"))
        {
            Destroy(collision.gameObject);

            // Nếu đang ở màn 1, chuyển sang màn 2
            if (SceneManager.GetActiveScene().name == "Level 1") // Màn 1
            {
                SceneManager.LoadScene("Level 2"); // Chuyển sang màn 2
            }
            //Nếu đang ở màn 2, win game
            else if (SceneManager.GetActiveScene().name == "Level 2") // Màn 2
            {
                SceneManager.LoadScene("Level 3");
            }
            else if (SceneManager.GetActiveScene().name == "Level 3") // Màn 3
            {
                SceneManager.LoadScene("Level 4");
            }
            else if (SceneManager.GetActiveScene().name == "Level 4") // Màn 4
            {
                gameManager.GameWin(); // Win game và không chuyển scene nữa
            }
        }
    }
}