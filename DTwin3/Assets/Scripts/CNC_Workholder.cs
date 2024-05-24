using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNC_Workholder : MonoBehaviour
{
    [SerializeField] private bool enable_movemet = true;

    [SerializeField] public float gapSize = 0.0f;

    public GameObject wLeft;
    public GameObject wRight;

    private const float wRight_close = -0.09291029f; //-
    private const float wLeft_close = -0.04955078f; //+

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
