using System.Collections;
using System.Collections.Generic;

public class Constellation {
    public HashSet<Star> stars;
    public Dictionary<Star, Star> topoMap;

    private string Name;
    private string Loc;

    public Constellation(string name) {
        this.Name = name;
    } 

    public string getName() {
        return Name;
    }

    public string getLoc() {
        return Loc;
    }

}
