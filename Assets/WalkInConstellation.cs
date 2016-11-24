using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class WalkInConstellation : MonoBehaviour {
    private static Constellations cons;
    public GameObject cam;
	// Use this for initialization
    public int distanceToTrigger = 10;
    public Text countText;
    public Text winText;
    public Transform textParent;

    private bool notInGame = true;
    private int currentIndex = -1;
    private GameObject[] line;
    private int totalLines = 0;
    private GameObject Arrow;
    private GameObject star;


    public string constellation_Walk = "Lib";

    private Star[] stars;

    void Start () {
        //line = new GameObject[20];
        //Arrow = new GameObject();
        //stars = new Star[20];
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
            stars = new Star[20];
            Arrow = new GameObject();
            currentIndex = 0;
            totalLines = 0;
            Arrow = (GameObject)Instantiate(Resources.Load("Arrow", typeof(GameObject)));


            cons.getConstellations().TryGetValue(constellation_Walk, out current_constellation);

            
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
                    stars[totalLines] = tempStar;
                    totalLines++;
                }
                catch (Exception e)
                {
                    continue;
                }
            }


        }


        if (!notInGame && currentIndex<totalLines) {
            countText.text = "Game Mode\nRescuing: " + constellation_Walk + "\nTotal Lines: " + (totalLines + 1) + "\nNext Star: " + stars[currentIndex].Name + "\nInfo:\nPosition: X:" + Mathf.Round(stars[currentIndex].location.x*100)/100 + " Y:" + Mathf.Round(stars[currentIndex].location.y*100)/100
                 + " Z:" + Mathf.Round(stars[currentIndex].location.z*100)/100 + "\nDistance: " + Mathf.Round(distance(line[currentIndex].GetComponent<ConnectLine>().b, transform.position)*100)/200 +" Light Year(s)";

            var rot = Quaternion.LookRotation(line[currentIndex].GetComponent<ConnectLine>().b - transform.position);
            Arrow.transform.rotation = Quaternion.Slerp(Arrow.transform.rotation, rot, Time.deltaTime * 0.5f);
            Vector3 moveArrowTo = transform.position + cam.transform.forward * 15.0f + Vector3.up * 1.0f + Vector3.right * 3.0f;

            float smoothFac = 0.6f;

            Arrow.transform.position = smoothFac * Arrow.transform.position + moveArrowTo * (1 - smoothFac);

            //if (distance(line[currentIndex].GetComponent<ConnectLine>().b, transform.position) < distanceToTrigger) {
            //    line[currentIndex].SetActive(true);
            //    currentIndex++;
            //}

            if (Input.GetKeyDown(KeyCode.A)) {
                line[currentIndex].SetActive(true);
                currentIndex++;
            }


        }

        if (currentIndex >= totalLines) {
            //finished game
            countText.text = "";
            star = (GameObject)Instantiate(Resources.Load(constellation_Walk, typeof(GameObject)));
            star.transform.SetParent(textParent, false);
            star.transform.localPosition = new Vector3(35.0f,-7.0f,-33.5f);
            star.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

            winText.text = "You made it!!!\nYou saved " + constellation_Walk + ".\nGo around to see what it is like.\nPress Q to quit Game Mode";
            currentIndex = -1;
            totalLines = 0;
            Destroy(Arrow);
            notInGame = true;
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            Destroy(star);
            
            winText.text = "";
            
            transform.position = new Vector3(0f, 0f, 0f);
        }

    }


    private float distance(Vector3 p1, Vector3 p2) {
        float x1_x2 = p1.x - p2.x;
        float y1_y2 = p1.y - p2.y;
        float z1_z2 = p1.z - p2.z;
        return Mathf.Sqrt(x1_x2 * x1_x2 + y1_y2 * y1_y2 + z1_z2 * z1_z2);
    }

}
