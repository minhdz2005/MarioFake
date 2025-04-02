using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText; // Thêm biến hiển thị điểm cao

    void Start()
    {
        // Lấy HighScore từ PlayerPrefs và cập nhật text
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Điểm Cao Nhất: " + highScore;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
