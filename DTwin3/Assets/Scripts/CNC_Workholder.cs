using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNC_Workholder : MonoBehaviour {
    [SerializeField] private bool enable_movement = true;

    [SerializeField] private bool moveA = false;
    [SerializeField] private bool moveB = false;
    public Cube_Spawner cubeSpawner;

    [SerializeField] public float gapSize = 0.0f;

    public GameObject wLeft;
    public GameObject wRight;

    private const float wRight_close = -0.09291029f; //-
    private const float wLeft_close = -0.04955078f; //+

    private Vector3 targetLeftPosition;
    private Vector3 targetRightPosition;

    private Vector3 velocityLeft;
    private Vector3 velocityRight;

    private readonly float smoothTime = 0.1f;

    private float gapSizeA;
    private float gapSizeB;

    void Start() {
        cubeSpawner.btn_cubeSpawn.onClick.AddListener(UpdateGapSizeB);
    }

    void UpdateGapSizeB() {
        (_, _, gapSizeB) = cubeSpawner.CubeInfo();
        gapSizeA = gapSizeB + 0.01f;
        moveA = true;
    }

    void FixedUpdate() {

        //kdy, odkud signal moveA a moveB?

        if (enable_movement && moveA) {

            gapSize = gapSizeA;

            float moveZ = Mathf.Clamp(gapSize / 2, 0f, 0.06f); // nastaveni posunu pro obe casti + omezeni rozpeti

            // Nastavíme cílové pozice pro pohyb
            targetLeftPosition = wLeft.transform.localPosition;
            targetLeftPosition.z = wLeft_close + moveZ;

            targetRightPosition = wRight.transform.localPosition;
            targetRightPosition.z = wRight_close - moveZ;

            // Plynulý pohyb k cílovým pozicím
            wLeft.transform.localPosition = Vector3.SmoothDamp(wLeft.transform.localPosition, targetLeftPosition, ref velocityLeft, smoothTime);
            wRight.transform.localPosition = Vector3.SmoothDamp(wRight.transform.localPosition, targetRightPosition, ref velocityRight, smoothTime);
        } else if (enable_movement && moveB) {
            gapSize = gapSizeB;

            float moveZ = Mathf.Clamp(gapSize / 2, 0f, 0.06f); // nastaveni posunu pro obe casti + omezeni rozpeti

            // Nastavíme cílové pozice pro pohyb
            targetLeftPosition = wLeft.transform.localPosition;
            targetLeftPosition.z = wLeft_close + moveZ;

            targetRightPosition = wRight.transform.localPosition;
            targetRightPosition.z = wRight_close - moveZ;

            // Plynulý pohyb k cílovým pozicím
            wLeft.transform.localPosition = Vector3.SmoothDamp(wLeft.transform.localPosition, targetLeftPosition, ref velocityLeft, smoothTime);
            wRight.transform.localPosition = Vector3.SmoothDamp(wRight.transform.localPosition, targetRightPosition, ref velocityRight, smoothTime);
        }
    }
}

/*
public class CNC_Workholder : MonoBehaviour
{
    [SerializeField] private bool enable_movemet = false;

    [SerializeField] public float gapSize = 1.0f;

    public GameObject wLeft;
    public GameObject wRight;

    private const float wRight_close = -0.09291029f; //-
    private const float wLeft_close = -0.04955078f; //+

    //private const float wRight_max = -0.09291029f; //-
    //private const float wLeft_max = -0.04955078f; //+

    void FixedUpdate() {


        float moveZ = Mathf.Clamp(gapSize / 2, 0f, 0.06f); //nastaveni posunu pro obe casti + omezeni rozpeti

        if (enable_movemet) {
            
            // Vytvorení nových vektoru pro nastavení lokální pozice
            Vector3 newLeftPosition = wLeft.transform.localPosition;
            newLeftPosition.z = wLeft_close + moveZ;
            wLeft.transform.localPosition = newLeftPosition;

            Vector3 newRightPosition = wRight.transform.localPosition;
            newRightPosition.z = wRight_close - moveZ;
            wRight.transform.localPosition = newRightPosition;
        }

    }
}
*/