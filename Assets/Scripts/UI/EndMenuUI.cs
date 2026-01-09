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
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
