using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerTwoCameras : MonoBehaviour
{
    public GameObject player;

    private List<CameraSettings> offsets = new List<CameraSettings>()
        {
            new CameraSettings(new Vector3(0, 3.42f, -6), new Vector3(14.48f, 0, 0), false), //Tras el coche
            new CameraSettings(new Vector3(0, 1.92f, 0.64f), new Vector3(0, 0, 0), true), //Conductor
        };
    protected int offsetsIndex = 0;

    protected void LateUpdate()
    {
        detectCameraChange();
        //Moves the camera following the player
        var cameraSettings = offsets[offsetsIndex];
        transform.position = player.transform.position + cameraSettings.getPosition();
        transform.rotation = Quaternion.Euler(cameraSettings.getRotation());
        if (cameraSettings.getFollowPlayerRotation())
        {
            transform.rotation = transform.rotation * player.transform.rotation;
        }
    }

    private void detectCameraChange()
    {
        //Si el botón de cambio de cámara se ha pulsado, cambiamos el offset
        if (Input.GetKeyDown("left alt"))
        {
            offsetsIndex++;
            if (offsetsIndex >= offsets.Count)
            {
                offsetsIndex = 0;
            }
        }
    }
}

class CameraSettings
{
    private Vector3 position;
    private Vector3 rotation;
    private bool followPlayerRotation;

    public CameraSettings(Vector3 position, Vector3 rotation, bool followPlayerRotation = false)
    {
        this.position = position;
        this.rotation = rotation;
        this.followPlayerRotation = followPlayerRotation;
    }

    public Vector3 getPosition()
    {
        return this.position;
    }

    public Vector3 getRotation()
    {
        return this.rotation;
    }

    public bool getFollowPlayerRotation()
    {
        return this.followPlayerRotation;
    }

    public void setPosition(Vector3 position)
    {
        this.position = position;
    }

    public void setRotation(Vector3 rotation)
    {
        this.rotation = rotation;
    }

    public void setFollowPlayerRotation(bool followPlayerRotation)
    {
        this.followPlayerRotation = followPlayerRotation;
    }
}
