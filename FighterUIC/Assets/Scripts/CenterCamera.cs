using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCamera : MonoBehaviour
{
    // TODO: Extend script to center camera among more than 2 players
    public GameObject playerOne;
    public GameObject playerTwo;

    Transform newTransform;

    // Start is called before the first frame update
    void Start()
    {
        // Find all players on map
        playerOne = GameObject.FindWithTag("Player1");
        playerTwo = GameObject.FindWithTag("Player2");

        // TODO: Initialize the camera at the center between all players' starting points
       
    }


    // Update at a fixed interval
    //
    // Calculate the distance between players to find a center, and then transform to it
    void FixedUpdate()
    {

        newTransform = new Transform();

    }
}
