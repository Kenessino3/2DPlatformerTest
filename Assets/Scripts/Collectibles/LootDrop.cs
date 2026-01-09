using UnityEngine;

public class LootDrop : MonoBehaviour
{
   [Header("Loot Settings")]
   [SerializeField] private GameObject lootPrefab;
   
   [SerializeField] private float dropChance;

   //MATH CONTENT
   public void AttemptDrop() //Attempt to drop look if it is the loot chance or lower
   {
      if (Random.value <= dropChance)
      {
         SpawnLoot();
      }
   }

   private void SpawnLoot()
   {
      if (lootPrefab != null)
      {
         Instantiate(lootPrefab, transform.position, Quaternion.identity);
      }
   }
}
