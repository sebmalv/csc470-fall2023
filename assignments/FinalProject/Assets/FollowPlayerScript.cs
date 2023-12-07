using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject player;
    public Vector3 offset = new Vector3(100f, 100f, -100f);
    public float smoothSpeed = 0.5f;


    
    void LateUpdate()
    {
        playerTransform = player.GetComponent<Transform>();
        if (playerTransform != null)
        {
            // Calculate the desired position of the camera
            Vector3 desiredPosition = playerTransform.position + offset;

            // Use SmoothDamp to smoothly interpolate between the current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Set the position of the camera
            transform.position = smoothedPosition;

            // Make the camera look at the player
            transform.LookAt(playerTransform);
        }
    }
}
