using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public void LoadNextLevel()
    {
        //get current level index and calculate the next one
        int currentLevelIndex= SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;
        
        SceneManager.LoadScene(nextLevelIndex);
    }
}
