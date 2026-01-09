using Unity.VisualScripting;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}
    
    [Header("Effects")]
    [SerializeField] private GameObject brokenPrefab;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip breakSound;

    private void Awake()
    {
        currentHealth = startingHealth;
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0f, startingHealth);

        if (currentHealth > 0)
        {
            SoundManager.instance.PlaySound(hitSound);
        }
        else
        {
            Break();
        }
    }

    private void Break()
    {
        AudioSource.PlayClipAtPoint(breakSound,transform.position);
        
        LootDrop loot = GetComponent<LootDrop>();
        if (loot != null)
        {
            loot.AttemptDrop();
        }
        
        if (brokenPrefab != null) //Bait and switch to broken prefab
        {
            Instantiate(brokenPrefab,transform.position,transform.rotation);
        }
        Destroy(gameObject);
    }
}
