using UnityEngine;
using System.Collections;

public class Walker : MonoBehaviour {

    public float speed = 6.0F;
    public Camera MainCam;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        transform.Translate(MainCam.transform.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(MainCam.transform.right *-1* speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(MainCam.transform.right * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(MainCam.transform.forward * -1 * speed * Time.deltaTime);
    }
}
