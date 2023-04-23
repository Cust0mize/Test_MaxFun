using System;

[Serializable]
public class PlanetConfig : ICloneable {
    public int MaxPlanet;
    public float MinPlanetSize;
    public float MaxPlanetSize;

    public object Clone() {
        return new PlanetConfig {
            MaxPlanet = MaxPlanet,
            MinPlanetSize = MinPlanetSize,
            MaxPlanetSize = MaxPlanetSize
        };
    }
}
