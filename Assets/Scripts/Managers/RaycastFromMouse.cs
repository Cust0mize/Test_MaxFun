using UnityEngine;

public class RaycastFromMouse : GlobalSingletonBehaviour<RaycastFromMouse> {
    void Update() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider == null) return;
        if (hit.collider.TryGetComponent(out Planet planet)) {
            if (Input.GetMouseButtonDown(0)) {
                if (PlanetService.I.SelectedPlanet == null) {
                    PlanetService.I.SaveSelected(planet);
                }
                else {
                    if (!planet.IsActivePlanet) {
                        LineManager.I.HideLine();
                        PlanetService.I.StartUnit();
                    }
                }
            }
            else {
                PlanetService.I.Unselected();
                PlanetService.I.Selected(planet);

                    if (PlanetService.I.SelectedPlanet != null) {
                        LineManager.I.ShowLine(PlanetService.I.SelectedPlanet, PlanetService.I.HiddenPlanet);
                    }
            }
        }
        else {
            PlanetService.I.Unselected();
        }
    }
}
