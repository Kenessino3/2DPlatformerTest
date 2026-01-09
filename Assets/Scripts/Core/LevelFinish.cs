using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private AudioClip winSound;
    [SerializeField] private float delayBeforeLoading = 1f;
    
    private bool levelComplete = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if player contacts object and hasn't already won
        if (collision.CompareTag("Player") && !levelComplete)
        {
            levelComplete = true;
            SoundManager.instance.PlaySound(winSound);
            
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScorce(10);
            }
            
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            
            Invoke("LoadNextLevel", delayBeforeLoading);
        }
    }

    private void LoadNextLevel()
    {
        //get current level index and calculate the next one
        int currentLevelIndex= SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;
        
        SceneManager.LoadScene(nextLevelIndex);
    }
}
