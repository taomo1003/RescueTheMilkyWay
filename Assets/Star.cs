using System.Collections;
using System;
using UnityEngine;
using System.Text.RegularExpressions;

public class Star {
    /* • Name = Proper name.
    • B = Bayer designation.
    • F or/and G. = Flamsteed designation or Gould designation.
    • Var = Variable star designation
    • HD = Henry Draper Catalogue designation number.
    • HIP = Hipparcos Catalogue designation number.
    • RA = Right ascension for the Epoch/Equinox J2000.0.
    • Dec = Declination for the Epoch/Equinox J2000.0.
    • vis. mag. = visual magnitude (m or mv), also known as apparent magnitude.
    • abs. mag. = absolute magnitude (Mv).
    • Dist. (ly) = Distance in light years from Earth.
    • Sp. class = Spectral class of the star in the stellar classification system.
    • Notes = Common name(s) or alternate name(s); comments; notable properties [for example: multiple star status, range of variability if it is a variable star, exoplanets, etc.].*/

    public string Name;
    public string B;
    public string var;
    public string HD;
    public string HIP;
    public string RA;
    public string Dec;
    public string vis_mag;
    public string abs_mag;
    public string Dist;
    public string Sp_class;
    public string Notes;

    public vector3 location;

    public Star(string Name, string B, string var, string HD, string HIP, string RA, string Dec, string vis_mag, string abs_mag, string Dist, string Sp_class, string Notes) {
        this.Name = Name;
        this.B = B;
        this.var = var;
        this.HD = HD;
        this.HIP = HIP;
        this.RA = RA;
        this.Dec = Dec;
        this.vis_mag = vis_mag;
        this.abs_mag = abs_mag;
        this.Dist = Dist;
        this.Sp_class = Sp_class;
        this.Notes = Notes;

        location = getXYZ(RA, Dec, Dist);
    }

    public class vector3{
        public float x;
        public float y;
        public float z;

        public vector3(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    

    public vector3 getXYZ(string RA, string Dec, string Dist) {
        string[] RAs = RA.Split(' ');
        float h = float.Parse(RAs[0].Substring(0, 2));
        float m = float.Parse(RAs[1].Substring(0, 2));
        float s = float.Parse(RAs[2].Substring(0, RAs[2].Length-1));
        string[] Decs = Regex.Split(Dec,@"\s+");

        float decD;
            if (Decs[0].ToCharArray()[0] ==  '−' || Decs[0].ToCharArray()[0] == '-')
            decD =  -float.Parse(Decs[0].Substring(1, Decs[0].Length - 2));
            else
            decD = float.Parse(Decs[0].Substring(0, Decs[0].Length - 1));
        float decM = float.Parse(Decs[1].Substring(0, Decs[1].Length - 1));
        float decS = 0.0f;
        if (Decs.Length>2)
            decS = float.Parse(Decs[2].Substring(0, Decs[2].Length - 1));
        float dis = float.Parse(Dist);


        float A = (h * 15.0f) + (m * 0.25f) + (s * 0.004166f);
        float B = (Mathf.Abs(decD) + decM / 60.0f + decS / 3600.0f) * Mathf.Sign(decD);
        float C = dis;

        float X = (C * Mathf.Cos(B *  Mathf.PI / 180.0f)) * Mathf.Cos(A * Mathf.PI / 180.0f);
        float Y = (C * Mathf.Cos(B *  Mathf.PI / 180.0f)) * Mathf.Sin(A * Mathf.PI / 180.0f);
        float Z = (C * Mathf.Sin(B *  Mathf.PI / 180.0f));

        return new vector3(X,Y,Z);
    }
}
