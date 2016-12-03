using System.Collections;
using System.Collections.Generic;

public class Constellation {
    public Dictionary<string,Star> stars;
    public HashSet<StarLine> topoMap;

    public string Name;
    public string Loc;

    public Constellation(string name) {
        stars = new Dictionary<string, Star>();
        topoMap = new HashSet<StarLine>();
        this.Name = name;
    }

    public class StarLine {
        public string starA;
        public string starB;

        public StarLine(string starA, string starB) {
            this.starA = starA;
            this.starB = starB;
        }
    }

}
