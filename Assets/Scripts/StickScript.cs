using UnityEngine;
using System.Collections;

public class StickScript : MonoBehaviour
{

    //values that will be set in the Inspector
    public Transform Target;
    public OVRInput.Controller Controller;

    public bool allowHit = false;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        /*
        RaycastHit hitInfo;
        Ray landingRay = new Ray(transform.position, transform.forward * 0.85f);

        if (Physics.Raycast(landingRay, out hitInfo, 1f))
        {
            if (hitInfo.collider.tag == "ball")
            {
                Debug.Log("hit");
                Vector3 vel = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
                hitInfo.collider.GetComponent<Rigidbody>().AddForce(vel);
            }
        }

        Debug.DrawRay(transform.position, transform.forward * 0.85f, Color.green);
        */
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            allowHit = true;
        }
        else
        {
            allowHit = false;
        }

        transform.localPosition = OVRInput.GetLocalControllerPosition(Controller);

        transform.LookAt(Target);
    }

    void OnCollisionEnter(Collision col)
    {
        if (allowHit)
        {
            Vector3 vel = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);

            col.transform.GetComponent<Rigidbody>().velocity = vel;
        }
    }

}

