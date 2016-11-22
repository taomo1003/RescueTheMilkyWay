using UnityEngine;
using System.Collections;

public class ConnectLine : MonoBehaviour {
    private LineRenderer line;
    private float counter = -0f;
    private float dist;


    public float lineWidth = 0.45f;
    public Vector3 a = new Vector3(0, 0, 0);
    public Vector3 b = new Vector3(1,1,1);

    public float lineSpeed = 6f;
	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
        line.SetPosition(0, a);
        line.SetWidth(lineWidth,lineWidth);
        dist = Vector3.Distance(a,b);
	}
	
	// Update is called once per frame
	void Update () {
	    if (counter < dist)
        {
            counter += 0.1f / lineSpeed;
            float x = Mathf.Lerp(0, dist, counter);

            Vector3 plot = x * Vector3.Normalize(b - a) + a;

            line.SetPosition(1, plot);
        }
	}
}
