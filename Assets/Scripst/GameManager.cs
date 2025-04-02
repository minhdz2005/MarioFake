using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int goldAmount = 0;  // Biến để lưu điểm vàng
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI goldText;  // Text để hiển thị điểm vàng
    [SerializeField] private GameObject gameOverUi;
    [SerializeField] private GameObject gameWinUI;
    private bool isGameOver = false;
    private bool isGameWin = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Lấy số vàng đã lưu khi game bắt đầu
        goldAmount = PlayerPrefs.GetInt("PlayerGold", 0);
        UpdateScore();
        gameOverUi.SetActive(false);
        gameWinUI.SetActive(false);

    }


    public void AddScore(int points)
    {
        if (!isGameOver)
        {
            score += points;
            UpdateScore();
        }

    }
    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
    private void UpdateGold()
    {
        goldText.text = "Gold: " + goldAmount.ToString();
    }
    public void GameOver()
    {
        isGameOver = true;
        score = 0;
        goldAmount = 0;
        PlayerPrefs.SetInt("PlayerGold", goldAmount);
        PlayerPrefs.Save();

        // Tạm dừng game (Time.timeScale = 0)
        Time.timeScale = 0;

        // Hiển thị Game Over UI
        gameOverUi.SetActive(true);

        // Nếu gameOverUi có CanvasGroup, giữ nó hoạt động
        CanvasGroup canvasGroup = gameOverUi.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;  // Cho phép các nút bấm nhận sự kiện
        }
    }
    public void GameWin()
    {
        isGameWin = true;
        Time.timeScale = 0;
        gameWinUI.SetActive(true);
        
    }
    public void RestartGame()
    {
        isGameOver = false;
        score = 0;
        goldAmount = 0;  // Reset điểm vàng khi restart game
        UpdateScore();
        UpdateGold();

        PlayerPrefs.SetInt("PlayerGold", goldAmount);  // Reset lại điểm vàng trong PlayerPrefs
        PlayerPrefs.Save();  // Lưu lại số vàng

        Time.timeScale = 1;
        SceneManager.LoadScene("Level 1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    // Thêm điểm vàng khi người chơi thu thập coin
    public void AddGold(int amount)
    {
        goldAmount += amount;
        PlayerPrefs.SetInt("PlayerGold", goldAmount);  // Lưu lại điểm vàng vào PlayerPrefs
        PlayerPrefs.Save();
        UpdateGold();  // Cập nhật UI hiển thị điểm vàng
    }

    public int GetGoldAmount()
    {
        return goldAmount;
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
    public bool IsGameWin()
    {
        return isGameWin;
    }
}