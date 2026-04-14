using System;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{ 
   private Transform currentCheckpoint; //store last checkpoint
   private Health playerHealth;
   private UIManager uiManager;

   private void Awake()
   {
      playerHealth = GetComponent<Health>();
      uiManager = FindObjectOfType<UIManager>();
   }

   //subscriptions
   private void OnEnable()
   {
      PlayerCollisions.OnCheckpointReached += UpdateCheckpoint;
   }

   private void OnDisable()
   {
      PlayerCollisions.OnCheckpointReached -= UpdateCheckpoint;
   }

   //Activate checkpoints
   private void UpdateCheckpoint(Transform newCheckpoint)
   {
      currentCheckpoint = newCheckpoint;
   }
   
   public void CheckRespawn()
   {
      //Check if checkpoint is available
      if (currentCheckpoint == null)
      {
         //Show game over screen
         uiManager.GameOver();
         return;
      }
      
      playerHealth.Respawn();//Restore player health and reset animation
      transform.position = currentCheckpoint.position; //Move player to checkpoint position
      
      //Move camera back to checkpoint room (checkpoint must be child of the room object)
      Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
   }
}
