using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInView : MonoBehaviour
{
    // Object to keep in view (Add more in future)
    public GameObject objectInView;

    Transform CameraPos;
    Camera    CameraObj;

    // Start is called before the first frame update
    void Start()
    {
        // Get current camera location
        CameraPos = GetComponent<Transform>();
        CameraObj = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the location of the player relative to the Viewport
        Vector3 pointOnScreen = CameraObj.WorldToViewportPoint(objectInView.transform.position);
        
        // Determine if the object is on the screen
        bool isInBoundsX = pointOnScreen.x > 0.1 && pointOnScreen.x < 0.9;
        bool isInBoundsY = pointOnScreen.y > 0.1 && pointOnScreen.y < 0.9;

        // Determine if camera is too far away      
        bool tooFarX = (pointOnScreen.x != 0.1) || (pointOnScreen.x != 0.9);
        bool tooFarY = (pointOnScreen.y != 0.1) || (pointOnScreen.y != 0.9);
  
        // If object is not on the screen zoom out
        if (!isInBoundsX || !isInBoundsY)
        {
            CameraPos.position += Vector3.back * 0.1f;
        }
        // If the object is too far, zoom in
        else if (tooFarX || tooFarY)
        {
            CameraPos.position -= Vector3.back * 0.1f;
        }
        
    }
}
