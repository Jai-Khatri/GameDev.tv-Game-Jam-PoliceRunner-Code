using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camfollow : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private Vector3 offset;
    [SerializeField] private float YOffset;

    private void Start()
    {
        offset = transform.position - Player.transform.position; //Calculates the offset which is needed between player and camera.
    }


    void Update()
    {
        Follow();
        Rotate();
    }

    void Follow()
    {
        Vector3 TargetPos = Player.transform.position + offset; // which takes the camera and offsets it's position from the player.
        TargetPos.y = Player.transform.position.y + YOffset; //we dont want the camera to move on the y axis with the player as it as jumping in my game is done by applying immediate force 
        transform.position = TargetPos; //Sets the position of the position of the camera to the Vector3 created before.
    }

    void Rotate()
    {
        transform.rotation = Player.transform.rotation; //Sets the Camera's rotation to the player's rotation as we want the camera to see what camera sees.
    }
}
