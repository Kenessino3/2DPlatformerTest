using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    
    public void StartGame()
    {
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
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
