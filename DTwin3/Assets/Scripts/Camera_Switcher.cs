using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Switcher : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    // Buttons for cameras
    public Button btn_C1;
    public Button btn_C2;
    public Button btn_C3;
    public Button btn_C4;
    public Button btn_C5;


    // Pozice a rotace vsech kamer

    // Camera 1 // z leva
    private static readonly Vector3 pos_C1 = new Vector3(2.0999999f, 1.21700001f, 0.196999997f);
    private static readonly Vector3 rot_C1 = new Vector3(0f, -112.614f, 0f);
    // Camera 2 // shora na stul
    private static readonly Vector3 pos_C2 = new Vector3(0.822000027f,1.20500004f,-0.0579999983f);
    private static readonly Vector3 rot_C2 = new Vector3(90f,270f,0f);
    // Camera 3 // blizko cnc
    private static readonly Vector3 pos_C3 = new Vector3(-0.158999994f, 1.23399997f, -0.314999998f);
    private static readonly Vector3 rot_C3 = new Vector3(0f, 144.391296f, 0f);
    // Camera 4 zvrchu na cele
    private static readonly Vector3 pos_C4 = new Vector3(0.200000003f, 2.25999999f, 0.389999986f);
    private static readonly Vector3 rot_C4 = new Vector3(55.1222076f, 180f, 0f);
    // Camera 5 general pro ur10
    private static readonly Vector3 pos_C5 = new Vector3(-0.5f, 1.89999998f, 1.39999998f); // podobne
    private static readonly Vector3 rot_C5 = new Vector3(22.1700058f, 160.139984f, 0f);


    void Start()
    {
        btn_C1.onClick.AddListener(() => MoveCameraToPosition(pos_C1, rot_C1));
        btn_C2.onClick.AddListener(() => MoveCameraToPosition(pos_C2, rot_C2));   
        btn_C3.onClick.AddListener(() => MoveCameraToPosition(pos_C3, rot_C3));   
        btn_C4.onClick.AddListener(() => MoveCameraToPosition(pos_C4, rot_C4));   
        btn_C5.onClick.AddListener(() => MoveCameraToPosition(pos_C5, rot_C5));   
    }

    // Funkce pro premisteni kamery po tlacitko
    private void MoveCameraToPosition(Vector3 position, Vector3 rotation) {
        if (mainCamera != null) {
            mainCamera.transform.position = position;
            mainCamera.transform.eulerAngles = rotation;
        } else {
            Debug.LogWarning("Hlavní kamera není nastavena.");
        }
    }
}
