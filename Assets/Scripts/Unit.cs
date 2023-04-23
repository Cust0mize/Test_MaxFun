using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class Unit : MonoBehaviour {
    private NavMeshAgent _agent;
    private Planet _endPlanet;
    private Vector3 _targetPosition;
    private float _distance;
    private bool _isInit;

    public void Init(Planet endPlanet, int layerIndex, int priority) {
        _agent = GetComponent<NavMeshAgent>();
        _agent.avoidancePriority = priority;
        _agent.areaMask = layerIndex;
        _endPlanet = endPlanet;
        _targetPosition = ChangeRandomTargetPointToPlanet(_endPlanet.transform);
        _isInit = true;
    }

    private Vector3 ChangeRandomTargetPointToPlanet(Transform zone) {
        Transform currentSpawnZone = zone;
        Vector3 localpoint = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), transform.position.z);
        Vector3 position = currentSpawnZone.TransformPoint(localpoint);
        return position;
    }

    private void Update() {
        if (_isInit) {
            _agent.destination = new Vector3(_targetPosition.x, _targetPosition.y, transform.position.z);

            _distance = Vector2.Distance(transform.position, _endPlanet.transform.position);

            if (_distance < _endPlanet.PlanetRadius + 0.3f) {
                _endPlanet.RemoveUnitCount();
                Destroy(gameObject);
            }
        }
    }
}