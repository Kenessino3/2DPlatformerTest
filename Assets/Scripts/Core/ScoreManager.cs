using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    [Header("TextUI")]
    public Text scoreText;
    
    public int currentScore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateTextBox(Text newText)
    {
        scoreText = newText;
        UpdateScoreText();
    }

    public void AddScorce(int amount)
    {
        currentScore += amount;
        Debug.Log(currentScore);
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = currentScore.ToString();
        }
    }
}
