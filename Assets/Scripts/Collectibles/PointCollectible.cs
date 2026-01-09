using UnityEngine;

public class PointCollectible : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] public int pointsToAdd = 1;
    [SerializeField] public AudioClip pickUpSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(pickUpSound);

            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScorce(pointsToAdd);
            }
            
            gameObject.SetActive(false);
        }
    }
}
