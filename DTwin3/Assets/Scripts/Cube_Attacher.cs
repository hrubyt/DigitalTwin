/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Attacher : MonoBehaviour {

    // Reference to cube
    public GameObject cube; 
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
/*
void Update() {

    // pokud kolize gripper kostka

    // kolize cnc kostka



        if (cubeSpawner.isSpawned) {
            // Get reference to cube
            if (cube != cubeSpawner.spawnedCube) {
            cube = cubeSpawner.spawnedCube;
            }           
            if (dettach) {
                DetachCube();
            }
            if (attach_CNC) {
                DetachCube();
                AttachCube(cncDisc);
            } 
            else if (attach_Gripper) {
                DetachCube();
                AttachCube(robotGripper);
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

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Attacher : MonoBehaviour {

    public GameObject cube;

    public GameObject workholder;
    public GameObject gripperFinger;


    public GameObject robotGripper;
    public GameObject cncDisc;

    public Cube_Spawner cubeSpawner;

    // Attachment variables
    [SerializeField] private bool attach_Gripper = false;
    [SerializeField] private bool attach_CNC = false;
    [SerializeField] private bool dettach = false;

    void Update() {

        if (cubeSpawner.isSpawned) {
            // Získání odkazu na kostku
            if (cube != cubeSpawner.spawnedCube) {
                cube = cubeSpawner.spawnedCube;
            }
            if (dettach) {
                DetachCube();
            }
            if (attach_CNC) {
                DetachCube();
                AttachCube(cncDisc);
                attach_CNC = false; // Reset the flag after attaching
            } else if (attach_Gripper) {
                DetachCube();
                AttachCube(robotGripper);
                attach_Gripper = false; // Reset the flag after attaching
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

    // Collision detection
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject == gripperFinger) {
            attach_Gripper = true;
        } else if (collision.gameObject == workholder) {
            attach_CNC = true;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject == gripperFinger) {
            attach_Gripper = false;
            dettach = true;
        } else if (collision.gameObject == workholder) {
            attach_CNC = false;
            dettach = true;
        }
    }

    
}

