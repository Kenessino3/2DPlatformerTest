using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Room previousRoom;
    [SerializeField] private Room nextRoom;
    [SerializeField] private CameraController cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            {
                cam.MoveToNewRoom(nextRoom.transform);
                nextRoom.ActivateRoom(true);
                previousRoom.ActivateRoom(false);
            }
            else
            {
                cam.MoveToNewRoom(previousRoom.transform);
                previousRoom.GetComponent<Room>().ActivateRoom(true);
                nextRoom.GetComponent<Room>().ActivateRoom(false);
            }
        }
    }
}
