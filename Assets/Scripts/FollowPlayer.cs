using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    protected Vector3 offset;

    // Start is called before the first frame update
    protected void Start()
    {
        //Get init camera position
        offset = transform.position;
    }

    // Update is called once per frame
    protected void LateUpdate()
    {
        //Moves the camera following the player
        transform.position = player.transform.position + offset;
    }
}
