using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class CreatSphere_Constell : MonoBehaviour {
    // Use this for initialization
    public long N = 50000;
    public long M = 100;
    public float scale = 0.1f;
    public Boolean mat = true;
    void Start() {
        Material newMat = Resources.Load("Sun", typeof(Material)) as Material;

        GameObject[] sphere = new GameObject[N];
        long Count = 0;

        System.Random rdm = new System.Random();

        var readerX = new StreamReader(File.OpenRead(@"./Assets/Resources/X.txt"));
        var readerY = new StreamReader(File.OpenRead(@"./Assets/Resources/Y.txt"));
        var readerZ = new StreamReader(File.OpenRead(@"./Assets/Resources/Z.txt"));
        while (!readerX.EndOfStream && Count < N)
        {
            float tx = ReadLine(readerX);
            float ty = ReadLine(readerY);
            float tz = ReadLine(readerZ);

            if (mat)
            {
                String name = "Sunpre" + rdm.Next(0, 3).ToString();
                sphere[Count] = (GameObject)Instantiate(Resources.Load(name, typeof(GameObject)));
            }
            else
            {
                sphere[Count] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            }
            sphere[Count].transform.position = new Vector3(tx * M, ty * M, tz * M);
            sphere[Count].transform.localScale = new Vector3(scale, scale, scale);
            Count++;

        }

    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            //Material newMat = Resources.Load("Sun", typeof(Material)) as Material;
            GameObject[] sphere = new GameObject[N];
            long Count = 0;

            var readerX = new StreamReader(File.OpenRead(@"./Assets/Resources/X.csv"));
            var readerY = new StreamReader(File.OpenRead(@"./Assets/Resources/Y.csv"));
            var readerZ = new StreamReader(File.OpenRead(@"./Assets/Resources/Z.csv"));
            int i = 0;
            while (!readerX.EndOfStream && Count < N)
            {
                float tx = ReadLine(readerX);
                float ty = ReadLine(readerY);
                float tz = ReadLine(readerZ);
                if (i == 0)
                {
                sphere[Count] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere[Count].transform.position = new Vector3(tx * M, ty * M, tz * M);
                //if (mat) sphere[Count].GetComponent<Renderer>().material = newMat;
                sphere[Count].transform.localScale = new Vector3(scale, scale, scale);
                Count++;
                }
                i++;
                if (i == 2000000/N)
                {
                    i = 0;
                }
            }
        }
    }

	float ReadLine(StreamReader reader){
		var line = reader.ReadLine();
		var values = line.Split(';');
		return Convert.ToSingle(values [0]);
	}
}
