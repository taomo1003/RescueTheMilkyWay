using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class Select_Right_1 : MonoBehaviour {

    public Text[] texts;
    public int sel;
    public int len;
    public int last;
    public bool move;
    public Scrollbar SB;
    public bool On;
    public float scroll = (float)1 / 81;
    public bool active;
    public double up_bond;
    public double low_bond;

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
        var readerNAME = new StreamReader(File.OpenRead(@"./Assets/ConstellationData/ConstellationCSV/_names"));
        int tempi = 0;
        while (!readerNAME.EndOfStream)
        {
            texts[tempi++].text = readerNAME.ReadLine();
        }
    }
    // Update is called once per frame
    void Update()
    {
        up_bond = (double)-44f - (1.0f - SB.value) * 81f * 88f;
        low_bond = up_bond - 6.5f * 88f;
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

            Debug.Log(texts[sel].transform.localPosition);
            if (texts[sel].transform.localPosition.y < low_bond)
                SB.value -= scroll;
            if (texts[sel].transform.localPosition.y > up_bond)
                SB.value += scroll;

            if (Input.GetAxis("Fire2") > 0)
            {
                last = sel;
                sel = 0;
                On = false;
                L.On = true;
                active = false;
            }
        }
    }
}
