using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class Select_Right_2 : MonoBehaviour
{

    public Text[] texts;
    public int sel;
    public int len;
    public int last;
    public bool move;
    public Scrollbar SB;
    public bool On;
    public float scroll = (float)1 / 6;
    public bool active;
    public double up_bond;
    public double low_bond;

    public bool push;

    public WalkInConstellation Walk;
    public show_panel panel;


    public Select_Left L;

    // Use this for initialization
    void Start()
    {
        texts = GetComponentsInChildren<Text>();
        foreach (Text t in texts)
            t.color = Color.black;
        sel = 0;
        last = 1;
        len = texts.Length;
        move = true;
        On = false;
        active = false;

        var readerNAME = new StreamReader(File.OpenRead(@"./Assets/ConstellationData/ConstellationCSV/ConstName_Lines"));
        int tempi = 0;
        while (!readerNAME.EndOfStream)
        {
            texts[tempi++].text = readerNAME.ReadLine();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") == 0)
            push = true;

        up_bond = (double)-44f - (1.0f - SB.value) * 6f * 88f;
        low_bond = up_bond - 6f * 88f;
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

            if (texts[sel].transform.localPosition.y < low_bond)
                SB.value -= scroll;
            if (texts[sel].transform.localPosition.y > up_bond)
               SB.value += scroll;

            if (Input.GetAxis("Fire2") > 0)
            {
                texts[sel].color = Color.black;
                sel = 0;
                On = false;
                L.On = true;
                active = false;
            }

            if (push && Input.GetAxis("Fire1") > 0)
            {
                panel.menu.enabled = false;
                panel.active = false;
                Walk.startGame(texts[sel].text);
            }

        }
    }
}
