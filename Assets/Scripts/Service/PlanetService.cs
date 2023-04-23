using System.Collections.Generic;
using UnityEngine;

public class PlanetService : GlobalSingleton<PlanetService> {
    public List<Planet> AllPlanets = new List<Planet>();
    public List<Vector2> PlanetsPosition { get; private set; } = new List<Vector2>();
    public Planet SelectedPlanet { get; private set; }
    public Planet HiddenPlanet { get; private set; }
    public int MaxPlanet { get; private set; }
    public float MinPlanetSize { get; private set; }
    public float MaxPlanetSize { get; private set; }

    private int _levelIndex = 0;

    public PlanetService() {
        MaxPlanet = ConfigService.I.PlanetConfigs[_levelIndex].MaxPlanet;
        MinPlanetSize = ConfigService.I.PlanetConfigs[_levelIndex].MinPlanetSize;
        MaxPlanetSize = ConfigService.I.PlanetConfigs[_levelIndex].MaxPlanetSize;
    }

    public void SaveSelected(Planet planet) {
        if (planet.IsActivePlanet) {
            SelectedPlanet = planet;
            Unselected();
            planet.ShowSelected(true);
        }
    }

    public void Unselected() {
        if (HiddenPlanet == SelectedPlanet || HiddenPlanet == null) {
            return;
        }
        else {
            HiddenPlanet.ShowSelected(false);
        }
    }

    public void Selected(Planet planet) {
        HiddenPlanet = planet;
        HiddenPlanet.ShowSelected(true);
    }

    public void StartUnit() {
        SelectedPlanet.CreateUnit(HiddenPlanet);
        SelectedPlanet.ShowSelected(false);
        HiddenPlanet.ShowSelected(false);
        SelectedPlanet = null;
        HiddenPlanet = null;
    }

    public void CalculateScreenPosition() {
        for (int i = 0; i < AllPlanets.Count; i++) {
            PlanetsPosition.Add(Camera.main.WorldToScreenPoint(AllPlanets[i].transform.position));
        }
    }
}
