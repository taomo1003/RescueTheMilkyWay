using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Select_Left : MonoBehaviour {

    public Text[] texts;
    public int sel;
    public int len;
    public int last;
    public bool move;
    public Scrollbar SB;

    public bool On;
    public Select_Right_1 R_1;
    public Select_Right_2 R_2;

    // Use this for initialization
    void Start () {
        texts = GetComponentsInChildren<Text>();
        foreach (Text t in texts)
            t.color = Color.black;
        sel = 0;
        last = 1;
        len = texts.Length;
        move = true;
        On = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (On)
        {
            if (!move)
                if (Input.GetAxis("Vertical") == 0)
                    move = true;
            if (move)
            {
                if (Input.GetAxis("Vertical") < 0)
                {
                    move = false;
                    if (sel > 0)
                    {
                        last = sel;
                        sel--;
                    }
                }
                if (Input.GetAxis("Vertical") > 0)
                {
                    move = false;
                    if (sel < len - 1)
                    {
                        last = sel;
                        sel++;
                    }
                }
            }
            texts[last].color = Color.black;
            texts[sel].color = Color.red;

            if (Input.GetAxis("Fire1") > 0)
            {
                On = false;
                if (sel == 0)
                {
                    R_1.last = R_1.sel;
                    R_1.sel = 0;
                    R_1.On = true;
                    R_1.active = true;
                    R_1.push = false;
                }
                if (sel == 1)
                {
                    R_2.last = R_2.sel;
                    R_2.sel = 0;
                    R_2.On = true;
                    R_2.active = true;
                    R_2.push = false;
                }
            }

        }
    }
}
