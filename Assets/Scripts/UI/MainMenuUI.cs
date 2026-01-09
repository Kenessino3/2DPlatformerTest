using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    
    public void StartGame()
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetScore();
        }
        
        SceneManager.LoadScene(1);
    }
    
    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }
    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
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
