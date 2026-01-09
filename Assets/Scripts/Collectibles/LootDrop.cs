using UnityEngine;
using UnityEngine.Serialization;

public class LootDrop : MonoBehaviour
{
   [Header("Loot Settings")]
   [SerializeField] private GameObject[] lootPrefabs;
   
   [SerializeField] private float dropChance;

   //MATH CONTENT
   public void AttemptDrop() //Attempt to drop loot if it is the loot chance or lower
   {
      if (Random.value <= dropChance)
      {
         SpawnLoot();
      }
   }

   // Uniform Distribution Selection
   // pick a random int index between 0 and the length of the list
   // will return 0,1,2 or 3
   private void SpawnLoot()
   {
      int randomIndex = Random.Range(0, lootPrefabs.Length);
      GameObject selectedLoot = lootPrefabs[randomIndex];

      if (selectedLoot != null)
      {
         Instantiate(selectedLoot, transform.position, Quaternion.identity);
      }
   }
}
