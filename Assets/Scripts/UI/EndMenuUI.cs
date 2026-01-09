using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuUI : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Quit()
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetScore();
        }
        
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
