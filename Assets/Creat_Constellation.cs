using UnityEngine;
using System;
using System.IO;

public class Creat_Constellation : MonoBehaviour {
    // Use this for initialization
    public long N = 7000;
    public long M = 10000;
    public float scale = 1f;
    public Boolean mat = true;
    void Start()
    {
        Material newMat = Resources.Load("Sun", typeof(Material)) as Material;

        GameObject[] sphere = new GameObject[N];
        long Count = 0;

        System.Random rdm = new System.Random();

        var readerX = new StreamReader(File.OpenRead(@"./Assets/Resources/X.txt"));
        var readerY = new StreamReader(File.OpenRead(@"./Assets/Resources/Y.txt"));
        var readerZ = new StreamReader(File.OpenRead(@"./Assets/Resources/Z.txt"));
        //int i = 0;
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

    void Update()
    {

    }

    float ReadLine(StreamReader reader)
    {
        var line = reader.ReadLine();
        var values = line.Split(';');
        return Convert.ToSingle(values[0]);
    }
}
