using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{


    public Transform player; // Reference to the player's transform
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Offset from the player

    void Update()
    {
        if (player != null)
        {
            // Set the camera's position to follow the player with an offset
            transform.position = player.position + offset;
        }
    }
}


