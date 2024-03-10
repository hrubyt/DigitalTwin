using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Attacher : MonoBehaviour {

    // Reference to cube
    private GameObject cube; 
    public GameObject cncDisc; 
    public GameObject robotGripper;

    public Cube_Spawner cubeSpawner;

    // Attachment variables
    [SerializeField] private bool attach_Gripper = false;
    [SerializeField] private bool attach_CNC = false;
    [SerializeField] private bool dettach = false;


    /*
    void Start() {
        // Get reference to cube
        cube = cubeSpawner.spawnedCube;
    }
    */

    void Update() {
        if (cubeSpawner.isSpawned) {
            // Get reference to cube
            if (cube != cubeSpawner.spawnedCube) {
            cube = cubeSpawner.spawnedCube;
            }           
            if (dettach) {
                        DetachCube();
                    }
                    if (attach_Gripper) {
                        DetachCube();
                        AttachCube(robotGripper);
                    } 
                    if (attach_CNC) {
                        DetachCube();
                        AttachCube(cncDisc);
                    }  
        }
               
    }

    // Method to attach the cube to the parent object
    void AttachCube(GameObject parentObject) {
        if (cube != null) {
            // Attach the cube as a child of the parent object
            cube.transform.parent = parentObject.transform;
        }
    }

    // Method to detach the cube from the parent object
    void DetachCube() {
        if (cube != null) {
            cube.transform.parent = null; // Detach the cube from the parent object
        }
    }
}

