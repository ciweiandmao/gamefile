using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public GameObject player;
    public float distanceBehindPlayer = 8f;
    public float heightAbovePlayer = 7f;
    public float tiltAngle = 20f; // ∏© ”Ω«∂»

    void LateUpdate()
    {
        if (Controller.IsStart)
        {
            // Calculate the desired position for the camera
            Vector3 desiredPosition = player.transform.position - player.transform.forward * distanceBehindPlayer;
            desiredPosition.y = player.transform.position.y + heightAbovePlayer;

            // Smoothly move the camera towards the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);

            // Calculate the rotation to look at the player's forward direction with tilt
            Quaternion lookRotation = Quaternion.LookRotation(player.transform.forward, Vector3.up) * Quaternion.Euler(tiltAngle, 0f, 0f);

            // Smoothly rotate the camera towards the lookRotation
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}
