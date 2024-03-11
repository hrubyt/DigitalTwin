using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube_Spawner : MonoBehaviour {
    // Cube for spawn
    public GameObject cubePrefab;

    // Button for spawn
    public Button btn_cubeSpawn;

    // Reference to the currently spawned cube
    [HideInInspector] public GameObject spawnedCube;
    [HideInInspector] public bool isSpawned = false;

    // Boundaries for spawn
    private float pos_y = 0.7244f;
    private float pos_xmax = 0.93f;
    private float pos_xmin = 0.75f;
    private float pos_zmax = 0.28f;
    private float pos_zmin = -0.38f;

    // Variables describing last cube
    private Vector3 lastSpawnPosition;
    private Vector3 lastSpawnRotation;
    private float lastSpawnScale;

    private void Start() {
        btn_cubeSpawn.onClick.AddListener(() => CubeSpawn());
    }

    private void CubeSpawn() {

        // Destroy previous cube if exists
        if (spawnedCube != null) {
            Destroy(spawnedCube);
        }

        // Generate random position and rotation
        Vector3 randomSpawnPosition = new Vector3(Random.Range(pos_xmin, pos_xmax), pos_y, Random.Range(pos_zmin, pos_zmax));
        Vector3 randomSpawnRotation = new Vector3(0, Random.Range(0, 360), 0);

        // Randomize size
        float randomScale = Random.Range(0.02f, 0.06f);

        // Spawn new cube
        spawnedCube = Instantiate(cubePrefab, randomSpawnPosition, Quaternion.Euler(randomSpawnRotation));
        spawnedCube.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

        isSpawned = true;

        // Variables for CubeInfo
        lastSpawnPosition = randomSpawnPosition;
        lastSpawnRotation = randomSpawnRotation;
        lastSpawnScale = randomScale;
    }

    // Cube inforamtion
    // (Vector3 position, Vector3 rotation, float scale) = cubeSpawner.CubeInfo();
    public (Vector3 position, Vector3 rotation, float scale) CubeInfo() {
        return (lastSpawnPosition, lastSpawnRotation, lastSpawnScale);
    }
}

