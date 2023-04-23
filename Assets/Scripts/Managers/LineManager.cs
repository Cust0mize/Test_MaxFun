using UnityEngine;

public class LineManager : GlobalSingletonBehaviour<LineManager> {
    [SerializeField] private LineRenderer _lineRenderer;

    public void ShowLine(params Planet[] planets) {
        for (int i = 0; i < _lineRenderer.positionCount; i++) {
            _lineRenderer.SetPosition(i, planets[i].transform.position);
        }
    }

    public void HideLine() {
        for (int i = 0; i < _lineRenderer.positionCount; i++) {
            _lineRenderer.SetPosition(i, Vector3.zero);
        }
    }
}