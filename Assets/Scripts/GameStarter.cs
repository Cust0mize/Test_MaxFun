using UnityEngine;

public class GameStarter : MonoBehaviour {
    private void Start() {
        ManagersInit();
    }

    private void ManagersInit() {
        PlanetSpawnerManager.I.Generate();
        NavMeshManager.I.Generate();
    }
}
