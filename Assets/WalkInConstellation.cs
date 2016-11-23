using UnityEngine;
using System.Collections;
using System;

public class WalkInConstellation : MonoBehaviour {
    private static Constellations cons;
    public GameObject cam;
	// Use this for initialization
    public int distanceToTrigger = 10;

    private bool notInGame = true;
    private int currentIndex = 0;
    private GameObject[] line;
    private int totalLines = 0;
    private GameObject Arrow;

    void Start () {
        line = new GameObject[20];
        Arrow = new GameObject();
        
    }
	
	// Update is called once per frame
	void Update () {
        cons = Creat_Constellation.getConstellations();
        
        if (Input.GetKeyDown(KeyCode.U) && notInGame)
        {
            //new game
            notInGame = false;
            line = new GameObject[20];
            Constellation current_constellation;

           

            totalLines = 0;
            Arrow = (GameObject)Instantiate(Resources.Load("Arrow", typeof(GameObject)));


            cons.getConstellations().TryGetValue("Aqr", out current_constellation);

            
            foreach (Constellation.StarLine starLine in current_constellation.topoMap)
            {
                try
                {
                    line[totalLines] = (GameObject)Instantiate(Resources.Load("Line", typeof(GameObject)));
                    Star tempStar;
                    current_constellation.stars.TryGetValue(starLine.starA, out tempStar);
                    line[totalLines].GetComponent<ConnectLine>().a = tempStar.starObject.transform.position;
                    current_constellation.stars.TryGetValue(starLine.starB, out tempStar);
                    line[totalLines].GetComponent<ConnectLine>().b = tempStar.starObject.transform.position;

                    totalLines++;
                }
                catch (Exception e)
                {
                    continue;
                }
            }
        }


        if (!notInGame && currentIndex<=totalLines) {

            var rot = Quaternion.LookRotation(line[currentIndex].GetComponent<ConnectLine>().b - transform.position);
            Arrow.transform.rotation = Quaternion.Slerp(Arrow.transform.rotation, rot, Time.deltaTime * 0.5f);

            Vector3 moveArrowTo = transform.position + cam.transform.forward * 15.0f + Vector3.up * 1.0f + Vector3.right * 3.0f;
            Debug.Log(cam.transform.localPosition.x);

            float smoothFac = 0.6f;

            Arrow.transform.position = smoothFac * Arrow.transform.position + moveArrowTo * (1 - smoothFac);

            if (distance(line[currentIndex].GetComponent<ConnectLine>().b, transform.position) < distanceToTrigger) {
                line[currentIndex].SetActive(true);
                currentIndex++;
            }


        }

        if (currentIndex > totalLines) {
            //finished game
            Debug.Log("Congradulation!" + "You Finished:" + "Aqr");
            notInGame = true;
        }
        
    }


    private float distance(Vector3 p1, Vector3 p2) {
        float x1_x2 = p1.x - p2.x;
        float y1_y2 = p1.y - p2.y;
        float z1_z2 = p1.z - p2.z;
        return Mathf.Sqrt(x1_x2 * x1_x2 + y1_y2 * y1_y2 + z1_z2 * z1_z2);
    }

}
