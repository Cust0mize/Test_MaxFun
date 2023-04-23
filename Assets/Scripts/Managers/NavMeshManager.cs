using NavMeshPlus.Components;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshManager : GlobalSingletonBehaviour<NavMeshManager> {
    [SerializeField] private NavMeshSurface[] _meshSurfaces;
    public int _currentAreaIndex { get; private set; }
    public int _currentZPosition { get; private set; }
    private int _minAreaIndex;
    private int _startZPosition = 0;

    public void Generate() {
        _currentAreaIndex = NavMesh.GetAreaFromName("Layer_1");
        _minAreaIndex = _currentAreaIndex;

        for (int i = 0; i < _meshSurfaces.Length; i++) {
            _meshSurfaces[i].BuildNavMesh();
            _meshSurfaces[i].transform.position = new Vector3(_meshSurfaces[i].transform.position.x, _meshSurfaces[i].transform.position.y, i);
        }
    }

    public NavMeshSurface[] GetMeshSurfaces() {
        return _meshSurfaces;
    }

    public void AddAreaAndZPositionIndex() {
        _currentAreaIndex++;
        _currentZPosition++;

        if (_currentZPosition == _meshSurfaces.Length) {
            _currentAreaIndex = _minAreaIndex;
            _currentZPosition = _startZPosition;
        }
    }
}