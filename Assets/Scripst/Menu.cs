using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText; // Thêm biến hiển thị điểm cao

   
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
