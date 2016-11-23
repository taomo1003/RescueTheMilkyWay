using UnityEngine;
using System.Collections;

public class MapDisplay : MonoBehaviour{

    public GameObject map; // Assign in inspector
    public GameObject Button;
    public GameObject mainCam;

    private bool flickFlag = false;
    public int flickRate = 10;

    private int count = 0;

    void Start()
    {
        map.SetActive(false);
    }


    void Update()
    {
        float[] position = getRA_Dec(mainCam.transform.position.x, mainCam.transform.position.y, -mainCam.transform.position.z);
        Button.transform.localPosition = new Vector3(position[0], position[1], 0.0f);

        if (Input.GetKeyDown(KeyCode.Tab)){
            map.SetActive(true);
            flickFlag = true;
        }
        
        if (flickFlag && count == 0)
        {
            Button.SetActive(!Button.activeSelf);
        }

        count++;
        if (count == flickRate)
        {
            count = 0;
        }

        if (Input.GetKeyUp(KeyCode.Tab)){
            map.SetActive(false);
            flickFlag = false;
        }
    }



    private float[] getRA_Dec(float tempx, float tempy, float tempz) {
        float[] reault = new float[2];

        float r = Mathf.Sqrt(tempx * tempx + tempy * tempy + tempz * tempz);
        float B = Mathf.Asin(tempz / r);
        float A = Mathf.Asin(tempy / r / Mathf.Cos(B));

        //change to degree
        B = B/Mathf.PI * 180f;
        A = A/Mathf.PI * 180f;

        float H = Mathf.Floor(A / 15);
        float Mi = Mathf.Floor((A - H*15) /0.25f);
        float Se = Mathf.Floor((A - H*15 - Mi*0.25f) / 0.004166f );

        H = H + Mi / 60.0f + Se / 3600.0f;

        reault[0] = 88.2f - 88.2f / 24f * H;
        reault[1] = -22.05f + 22.05f / 90f * B;
        Debug.Log("r:    " + r);
        Debug.Log("B:    " + B);
        Debug.Log("A:    " + A);
        return reault; 

    }
}
