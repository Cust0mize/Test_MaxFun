using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class Planet : MonoBehaviour {
    [SerializeField] private TextMeshPro _textMeshPro;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private SpriteRenderer _selectedRenderer;
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private int _unitPerSecond = 5;

    public float PlanetSize { get; private set; }
    public float PlanetRadius { get; private set; }
    public bool IsActivePlanet { get; private set; }

    private Unit _unitPrefab;
    private List<Unit> _units = new List<Unit>();
    private int _planetUnitsCount;
    private const int _minPlanetUnits = 10, _maxPlanetUnits = 50;

    public void Init(float size, bool isActivePlanet, Unit unit) {
        PlanetSize = size;
        PlanetRadius = PlanetSize / 2;
        _unitPrefab = unit;
        _collider.radius = _collider.radius * PlanetSize;
        _spriteRenderer.transform.localScale = new Vector3(PlanetSize, PlanetSize, PlanetSize);

        if (isActivePlanet) {
            _planetUnitsCount = _maxPlanetUnits;
            CapturePlanet();
        }
        else {
            _planetUnitsCount = Random.Range(_minPlanetUnits, _maxPlanetUnits);
        }

        _textMeshPro.text = _planetUnitsCount.ToString();
        ShowSelected(false);
    }

    public void ShowSelected(bool state) {
        _selectedRenderer.gameObject.SetActive(state);
    }

    public void CapturePlanet() {
        _spriteRenderer.color = Color.blue;
        IsActivePlanet = true;
        StartCoroutine(AddUnit());
    }

    public void CreateUnit(Planet endPlanet) {
        _planetUnitsCount /= 2;
        Vector3 direction = endPlanet.transform.position - transform.position;
        direction.Normalize();
        Vector3 unitPosition = transform.position + direction;

        for (int i = 0; i < _planetUnitsCount; i++) {
            _units.Add(Instantiate(_unitPrefab, new Vector3(unitPosition.x, unitPosition.y, NavMeshManager.I._currentZPosition), Quaternion.identity, transform.parent));
        }

        foreach (var unit in _units) {
            unit.Init(endPlanet, Mathf.RoundToInt(Mathf.Pow(2, NavMeshManager.I._currentAreaIndex)));
        }
        NavMeshManager.I.AddAreaAndZPositionIndex();
        _units.Clear();
    }

    public void RemoveUnitCount() {
        if (_planetUnitsCount > 0 && !IsActivePlanet) {
            _planetUnitsCount--;
        }
        else if (_planetUnitsCount <= 0 && !IsActivePlanet) {
            _planetUnitsCount++;
            CapturePlanet();
        }
        else {
            _planetUnitsCount++;
        }
        _textMeshPro.text = _planetUnitsCount.ToString();
    }

    private IEnumerator AddUnit() {
        while (IsActivePlanet) {
            _planetUnitsCount++;
            _textMeshPro.text = _planetUnitsCount.ToString();
            yield return new WaitForSeconds(1f / _unitPerSecond);
        }
    }
}
