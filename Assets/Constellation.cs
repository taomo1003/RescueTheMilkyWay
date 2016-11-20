using System.Collections;
using System.Collections.Generic;

public class Constellation {
    public Dictionary<string,Star> stars;
    public Dictionary<Star, Star> topoMap;

    public string Name;
    public string Loc;

    public Constellation(string name) {
        stars = new Dictionary<string, Star>();
        topoMap = new Dictionary<Star, Star>();
        this.Name = name;
    } 

}
