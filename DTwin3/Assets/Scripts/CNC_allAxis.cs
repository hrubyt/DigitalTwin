using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNC_allAxis : MonoBehaviour {
    [SerializeField] private bool enable_movement = true;
    
    // Zadane pozice a rotace
    [SerializeField] public float pos_Xaxis = 0.0f;
    [SerializeField] public float pos_Yaxis = 0.0f;
    [SerializeField] public float pos_Zaxis = 0.0f;
    [SerializeField] public float rot_Aaxis = 0.0f;
    [SerializeField] public float rot_Caxis = 0.0f;

    // Rychlosti
    [SerializeField] public float speed_Xaxis = 0.5f;
    [SerializeField] public float speed_Yaxis = 0.5f;
    [SerializeField] public float speed_Zaxis = 0.5f;
    [SerializeField] public float speed_Aaxis = 0.5f;
    [SerializeField] public float speed_Caxis = 0.5f;

    // Objekty pro pohyb
    public GameObject objXaxis;
    public GameObject objYaxis;
    public GameObject objZaxis;
    public GameObject objAaxis;
    public GameObject objCaxis;

    // Omezeni max a min polohy
    private readonly float maxXpos = 0.17f;
    private readonly float minXpos = -0.17f;
    private readonly float maxYpos = 0.16f;
    private readonly float minYpos = -0.16f;
    private readonly float maxZpos = 0.12f;
    private readonly float minZpos = -0.2f;

    // Pomocna pormenna pro plynuly pohyb
    private float cur_Xaxis = 0.0f;
    private float cur_Yaxis = 0.0f;
    private float cur_Zaxis = 0.0f;
    private float cur_Aaxis = 0.0f;
    private float cur_Caxis = 0.0f;

    private readonly float smoothTime = 0.1f;

    void FixedUpdate() {
        if (enable_movement) {
            UpdateTranslation();
            UpdateRotation();
        }
    }

    void UpdateTranslation() {
        pos_Xaxis = Mathf.Clamp(pos_Xaxis, minXpos, maxXpos);
        pos_Yaxis = Mathf.Clamp(pos_Yaxis, minYpos, maxYpos);
        pos_Zaxis = Mathf.Clamp(pos_Zaxis, minZpos, maxZpos);

        cur_Xaxis = Mathf.SmoothDamp(cur_Xaxis, pos_Xaxis, ref speed_Xaxis, smoothTime);
        cur_Yaxis = Mathf.SmoothDamp(cur_Yaxis, pos_Yaxis, ref speed_Yaxis, smoothTime);
        cur_Zaxis = Mathf.SmoothDamp(cur_Zaxis, pos_Zaxis, ref speed_Zaxis, smoothTime);

        AxisTranslation(objXaxis, 'x', cur_Xaxis);
        AxisTranslation(objYaxis, 'y', cur_Yaxis);
        AxisTranslation(objZaxis, 'x', cur_Zaxis);
    }

    void UpdateRotation() {
        cur_Aaxis = Mathf.SmoothDampAngle(cur_Aaxis, rot_Aaxis, ref speed_Aaxis, smoothTime);
        cur_Caxis = Mathf.SmoothDampAngle(cur_Caxis, rot_Caxis, ref speed_Caxis, smoothTime);
        
        AxisRotation(objAaxis, 'x', cur_Aaxis);
        AxisRotation(objCaxis, 'z', cur_Caxis);
    }

    void AxisTranslation(GameObject objAxis, char axis, float pos) {
        Vector3 currentPosition = objAxis.transform.localPosition;

        if (axis == 'x') {
            currentPosition.x = pos;
        } else if (axis == 'y') {
            currentPosition.y = pos;
        } else if (axis == 'z') {
            currentPosition.z = pos;
        }

        objAxis.transform.localPosition = currentPosition;
    }
    void AxisRotation(GameObject objAxis, char axis, float rot) {
        float xrot = 0.0f;
        float yrot = 0.0f;
        float zrot = 0.0f;

        if (axis == 'x') {
            xrot = rot;
        } else if (axis == 'y') {
            yrot = rot;
        } else if (axis == 'z') {
            zrot = rot;
            xrot = -89.98f; // kvuli CAxis
        }

        objAxis.transform.localEulerAngles = new Vector3(xrot, yrot, zrot);
    }
}

/*
public class CNC_allAxis : MonoBehaviour {
    
    [SerializeField] private bool enable_movement = true;
    [SerializeField] public float pos_Xaxis = 0.0f;//0.09199989f;
    [SerializeField] public float pos_Yaxis = 0.0f;
    [SerializeField] public float pos_Zaxis = 0.0f;//-0.1386001f;
    [SerializeField] public float rot_Aaxis = 0.0f;
    [SerializeField] public float rot_Caxis = 0.0f;

    public GameObject objXaxis;
    public GameObject objYaxis;
    public GameObject objZaxis;
    public GameObject objAaxis;
    public GameObject objCaxis;

    private readonly float maxXpos = 0.17f;
    private readonly float minXpos = -0.17f;
    private readonly float maxYpos = 0.16f;
    private readonly float minYpos = -0.16f;
    private readonly float maxZpos = 0.12f;
    private readonly float minZpos = -0.2f;

    void FixedUpdate() {
        if (enable_movement) {
            AxisTranslation(objXaxis, 'x', pos_Xaxis, minXpos, maxXpos);
            AxisTranslation(objYaxis, 'y', pos_Yaxis, minYpos, maxYpos);
            AxisTranslation(objZaxis, 'x', pos_Zaxis, minZpos, maxZpos);

            AxisRotation(objAaxis, 'x', rot_Aaxis);
            AxisRotation(objCaxis, 'z', rot_Caxis);
        }
    }

    void AxisTranslation(GameObject objAxis, char axis, float pos, float minPos, float maxPos) {
        // Ohranicení krajních hodnot pro posunutí
        float movePos = Mathf.Clamp(pos, minPos, maxPos);
        // Získání aktuální lokální pozice
        Vector3 currentPosition = objAxis.transform.localPosition;

        // Nastavení nové hodnoty v závislosti na ose
        if (axis == 'x') {
            currentPosition.x = movePos;
        } else if (axis == 'y') {
            currentPosition.y = movePos;
        } else if (axis == 'z') {
            currentPosition.z = movePos;
        }

        // Nastavení nové lokální pozice objektu
        objAxis.transform.localPosition = currentPosition;
    }

    void AxisRotation(GameObject objAxis, char axis, float rot) {
        float xrot = 0.0f;
        float yrot = 0.0f;
        float zrot = 0.0f;

        if (axis == 'x') {
            xrot = rot;
        } else if (axis == 'y') {
            yrot = rot;
        } else if (axis == 'z') {
            zrot = rot;
            xrot = -89.98f; // kvuli CAxis
        }

        objAxis.transform.localEulerAngles = new Vector3(xrot, yrot, zrot);
    }
}
    */