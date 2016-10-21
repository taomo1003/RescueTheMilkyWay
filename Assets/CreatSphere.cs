using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class CreatSphere : MonoBehaviour {
	// Use this for initialization
	public int N = 10;
	public int M = 100;
	void Start () {
		GameObject[] sphere = new GameObject[N];
		int Count = 0;

		var readerX = new StreamReader(File.OpenRead(@"./Assets/Resources/X.txt"));
		var readerY = new StreamReader(File.OpenRead(@"./Assets/Resources/Y.txt"));
		var readerZ = new StreamReader(File.OpenRead(@"./Assets/Resources/Z.txt"));


		while (!readerX.EndOfStream && Count<N)
		{
			float tx = ReadLine (readerX);
			float ty = ReadLine (readerY);
			float tz = ReadLine (readerZ);
			sphere[Count] = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			sphere[Count].transform.position = new Vector3 (tx*M, ty*M ,tz*M);
			//listA.Add(temp);
			Count++;
		}

	}

	float ReadLine(StreamReader reader){
		var line = reader.ReadLine();
		var values = line.Split(';');
		return Convert.ToSingle(values [0]);
	}
}
