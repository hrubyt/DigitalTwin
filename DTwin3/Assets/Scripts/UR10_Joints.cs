using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;
/*
public class UR10_Joints : MonoBehaviour {
    [SerializeField] public float rot_j1 = 90f;
    [SerializeField] public float rot_j2 = 180f;
    [SerializeField] public float rot_j3 = 180f;
    [SerializeField] public float rot_j4 = 180f;
    [SerializeField] public float rot_j5 = 180f;
    [SerializeField] public float rot_j6 = 180f;

    public GameObject j1;
    public GameObject j2;
    public GameObject j3;
    public GameObject j4;
    public GameObject j5;
    public GameObject j6;
    //z,y,y,y,z,y

    void FixedUpdate() {           
        JointRotation(j1, 'z', rot_j1);
        JointRotation(j2, 'y', rot_j2);
        JointRotation(j3, 'y', rot_j3);
        JointRotation(j4, 'y', rot_j4);
        JointRotation(j5, 'z', rot_j5);
        JointRotation(j6, 'y', rot_j6);
        
    }
    
    void JointRotation(GameObject joint, char axis, float rot) {

        float xrot = 0.0f;
        float yrot = 0.0f;
        float zrot = 0.0f;

        if (axis == 'y') {
            yrot = rot;   
        }
        else if (axis == 'z'){ 
            zrot = rot;
        }

        joint.transform.localEulerAngles = new Vector3(xrot, yrot, zrot);
    }
}
*/

//using UnityEngine;

public class UR10_Joints : MonoBehaviour {
    // Rotations in joints
    [SerializeField] public float rot_j1 = 90f;
    [SerializeField] public float rot_j2 = 180f;
    [SerializeField] public float rot_j3 = 180f;
    [SerializeField] public float rot_j4 = 180f;
    [SerializeField] public float rot_j5 = 180f;
    [SerializeField] public float rot_j6 = 180f;

    // Speed of joints
    [SerializeField] private float speed_j1 = 0.5f;
    [SerializeField] private float speed_j2 = 0.5f;
    [SerializeField] private float speed_j3 = 0.5f;
    [SerializeField] private float speed_j4 = 0.5f;
    [SerializeField] private float speed_j5 = 0.5f;
    [SerializeField] private float speed_j6 = 0.5f;

    public GameObject j1;
    public GameObject j2;
    public GameObject j3;
    public GameObject j4;
    public GameObject j5;
    public GameObject j6;

    private float currentRotJ1;
    private float currentRotJ2;
    private float currentRotJ3;
    private float currentRotJ4;
    private float currentRotJ5;
    private float currentRotJ6;

    private float smoothTime = 0.1f;
    //private float velocity = 0.0f;

    void FixedUpdate() {                     
        currentRotJ1 = Mathf.SmoothDampAngle(currentRotJ1, rot_j1, ref speed_j1, smoothTime);
        currentRotJ2 = Mathf.SmoothDampAngle(currentRotJ2, rot_j2, ref speed_j2, smoothTime);
        currentRotJ3 = Mathf.SmoothDampAngle(currentRotJ3, rot_j3, ref speed_j3, smoothTime);
        currentRotJ4 = Mathf.SmoothDampAngle(currentRotJ4, rot_j4, ref speed_j4, smoothTime);
        currentRotJ5 = Mathf.SmoothDampAngle(currentRotJ5, rot_j5, ref speed_j5, smoothTime);
        currentRotJ6 = Mathf.SmoothDampAngle(currentRotJ6, rot_j6, ref speed_j6, smoothTime);

        JointRotation(j1, 'z', currentRotJ1);
        JointRotation(j2, 'y', currentRotJ2);
        JointRotation(j3, 'y', currentRotJ3);
        JointRotation(j4, 'y', currentRotJ4);
        JointRotation(j5, 'z', currentRotJ5);
        JointRotation(j6, 'y', currentRotJ6);
    }

    void JointRotation(GameObject joint, char axis, float rot) {
        float xrot = 0.0f;
        float yrot = 0.0f;
        float zrot = 0.0f;

        if (axis == 'y') {
            yrot = rot;
        } else if (axis == 'z') {
            zrot = rot;
        }

        joint.transform.localEulerAngles = new Vector3(xrot, yrot, zrot);
    }
}
