using UnityEngine;

public class PlanetSpawnerManager : GlobalSingletonBehaviour<PlanetSpawnerManager> {
    [SerializeField] private Planet _planetPrefab;
    [SerializeField] private Transform _spawnZone;
    [SerializeField] private Transform _layout;
    [SerializeField] private Unit _unitPrefab;
    [SerializeField] private float _displacementBetweenPlanets = 0.5f;

    private bool _isFirsPlanet;
    private bool _isInit;

    public void Generate() {
        for (int i = 0; i < PlanetService.I.MaxPlanet; i++) {
            _isFirsPlanet = i == 0;
            float planetSize = _isFirsPlanet ? PlanetService.I.MaxPlanetSize : Random.Range(PlanetService.I.MinPlanetSize, PlanetService.I.MaxPlanetSize);
            Planet newPlanet = Instantiate(_planetPrefab, SpawnTo(), Quaternion.identity, _layout);

            foreach (Planet planet in PlanetService.I.AllPlanets) {
                if ((planet.PlanetSize + planetSize) / 2 > Vector2.Distance(planet.transform.position, newPlanet.transform.position) - _displacementBetweenPlanets) {
                    Destroy(newPlanet.gameObject);
                    i--;
                    _isInit = false;
                    break;
                }
                else {
                    _isInit = true;
                }
            }

            if (_isInit || _isFirsPlanet) {
                newPlanet.Init(planetSize, _isFirsPlanet, _unitPrefab);
                PlanetService.I.AllPlanets.Add(newPlanet);
                _isInit = false;
                _isFirsPlanet = false;
            }
        }
        PlanetService.I.CalculateScreenPosition();
    }

    private Vector3 SpawnTo() {
        Transform currentSpawnZone = _spawnZone;
        Vector3 localpoint = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), -1);
        Vector3 position = currentSpawnZone.TransformPoint(localpoint);
        return position;
    }
}
