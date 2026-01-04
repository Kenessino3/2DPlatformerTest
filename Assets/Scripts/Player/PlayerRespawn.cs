using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
   [SerializeField] private AudioClip checkpointSound; //Sound that plays when picking up a new checkpoint
   private Transform currentCheckpoint; //store last checkpoint
   private Health playerHealth;

   private void Awake()
   {
      playerHealth = GetComponent<Health>();
   }

   public void RespawnPlayer()
   {
      transform.position = currentCheckpoint.position; //Move player to checkpoint position
      playerHealth.Respawn();//Restore player health and reset animation
      
      //Move camera back to checkpoint room (checkpoint must be child of the room object)
      Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
   }
   
   //Activate checkpoints
   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.tag == "Checkpoint")
      {
         currentCheckpoint = collision.transform;//Store the checkpoint that was activated as the current one
         SoundManager.instance.PlaySound(checkpointSound);
         collision.GetComponent<Collider2D>().enabled = false; //Deactivate checkpoint collider
         collision.GetComponent<Animator>().SetTrigger("Appear"); //Trigger checkpoint animation
      }
      
   }
}
