using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public AudioClip clip;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {

        //Rigidbody rb = transform.GetComponent<Rigidbody>();
        //rb.maxAngularVelocity = 100;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButton(0))
         //   rb.AddForce(transform.forward * thrust);

    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "ball")
        {            
            audioSource.Play();
        }

    }
}
