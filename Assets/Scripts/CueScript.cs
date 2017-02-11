using UnityEngine;
using System.Collections;

public class CueScript : MonoBehaviour {

    public static bool up;
    public static bool down;
    public static bool left;
    public static bool right;

    public float xaxis;
    public float yaxis;

    float lastDpadX;
    float lastDpadY;

    bool stickForward;
    float stickForwardDistance = 0;
    float stickStartDistance = 0;
    bool stickBack;

    // Use this for initialization
    void Start () {

        up = down = left = right = false;
        lastDpadX = Input.GetAxis("DPadX");
        lastDpadY = Input.GetAxis("DPadY");

        stickStartDistance = transform.position.z;

    }
	
	// Update is called once per frame
	void Update () {

        xaxis = Input.GetAxis("DPadX");
        yaxis = Input.GetAxis("DPadY");

        if (xaxis == 1 && lastDpadX != 1) { right = true; } else { right = false; }
        if (xaxis == -1 && lastDpadX != -1) { left = true; } else { left = false; }
        if (yaxis == 1 && lastDpadY != 1) { up = true; } else { up = false; }
        if (yaxis == -1 && lastDpadY != -1) { down = true; } else { down = false; }

        if (up)
        {
            var newPos = transform.position;

            newPos.y += 0.005f;

            transform.position = newPos;
        }

        if (down)
        {
            var newPos = transform.position;

            newPos.y -= 0.005f;

            transform.position = newPos;
        }

        if (left)
        {
            var newPos = transform.position;

            newPos.z -= 0.005f;

            transform.position = newPos;
        }

        if (right)
        {
            var newPos = transform.position;

            newPos.z += 0.005f;

            transform.position = newPos;
        }

        if (Input.GetButton("Fire2"))
        {
            stickForward = true;
            var newPos = transform.position;
            stickForwardDistance = newPos.z - 0.1f;
        }

        if (stickForward)
        {
            var newPos = transform.position;

            newPos.z -= 0.05f;
            
            if(newPos.z < stickForwardDistance)
            {
                stickForward = false;
                stickBack = true;
            }
            else
                transform.position = newPos;
        }

        if (stickBack)
        {
            var newPos = transform.position;

            newPos.z += 0.05f;

            if (newPos.z > stickStartDistance)
            {
                stickForward = false;
                stickBack = false;
            }
            else
            {
                newPos.z = stickStartDistance;
                transform.position = newPos;
            }
                
        }

    }
}
