using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Walker : MonoBehaviour {
    public float speed = 15.0F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (CrossPlatformInputManager.GetAxis("Vertical") < 0)
            transform.Translate(Vector3.forward * -1 * speed * Time.deltaTime);


        if (CrossPlatformInputManager.GetAxis("Horizontal") < 0)
            transform.Translate(Vector3.right * -1 * speed * Time.deltaTime);



        if (CrossPlatformInputManager.GetAxis("Horizontal") > 0)
            transform.Translate(Vector3.right * speed * Time.deltaTime);



        if (CrossPlatformInputManager.GetAxis("Vertical") > 0)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

   



        if (CrossPlatformInputManager.GetButtonDown ("X")) {
           
        }
		if (CrossPlatformInputManager.GetButtonDown ("Y")) {
           
        }
		if (CrossPlatformInputManager.GetButtonDown ("A")) {
           
		}
		if (CrossPlatformInputManager.GetButtonDown ("B")) {
            
		}


	}
}
