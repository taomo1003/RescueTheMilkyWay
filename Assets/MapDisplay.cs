using UnityEngine;
using System.Collections;

public class MapDisplay : MonoBehaviour{

    public GameObject map; // Assign in inspector
    public GameObject Dot;
    public GameObject mainCam;

    private bool flickFlag = false;
    public int flickRate = 10;

    private int count = 0;

    void Start()
    {
        map.SetActive(false);
        Dot.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    }


    void Update()
    {
        float[] position = getRA_Dec(mainCam.transform.position.x, mainCam.transform.position.y, -mainCam.transform.position.z);
        Dot.transform.localPosition = new Vector3(position[0], position[1], 0.0f);

        if (Input.GetKeyDown(KeyCode.Tab)){
            map.SetActive(true);
            flickFlag = true;
        }
        
        if (flickFlag && count == 0)
        {
            Dot.SetActive(!Dot.activeSelf);
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
        float[] result = new float[2];

        float r = Mathf.Sqrt(tempx * tempx + tempy * tempy + tempz * tempz);
        float B = Mathf.Asin(tempz / r);
        float A = Mathf.Asin(tempy / r / Mathf.Cos(B));

        if (A < 0) { A += 2 * Mathf.PI; }
        //change to degree
        B = B/Mathf.PI * 180f;
        A = A/Mathf.PI * 180f;

        float H = Mathf.Floor(A / 15);
        float Mi = Mathf.Floor((A - H*15) /0.25f);
        float Se = Mathf.Floor((A - H*15 - Mi*0.25f) / 0.004166f );
        Debug.Log("H:    " + H);
        Debug.Log("Mi:    " + Mi);
        Debug.Log("Se:    " + Se);

        H = H + Mi / 60.0f + Se / 3600.0f;

        result[0] = 88.2f - 88.2f / 24f * H;
        result[1] = -22.05f + 22.05f / 90f * B;
        Debug.Log("r:    " + r);
        Debug.Log("B:    " + B);
        Debug.Log("A:    " + A);
        return result; 

    }
}
