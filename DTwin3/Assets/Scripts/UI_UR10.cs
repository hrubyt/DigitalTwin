using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_UR10 : MonoBehaviour {
    
    // Buttons
    public Button btn_exit;

    // UI Gameobjects
    public GameObject ui_UR10;
    public GameObject ui_Main;
    
    
    //[SerializeField] private InputField inputField;
    //[SerializeField] private TMP_InputField inputField;

    [SerializeField] private UR10_Joints UR10_Joints;

    [SerializeField] private TextMeshProUGUI j1TMP;
    [SerializeField] private TextMeshProUGUI j2TMP;
    [SerializeField] private TextMeshProUGUI j3TMP;
    [SerializeField] private TextMeshProUGUI j4TMP;
    [SerializeField] private TextMeshProUGUI j5TMP;
    [SerializeField] private TextMeshProUGUI j6TMP;

    [SerializeField] private TextMeshProUGUI strokeTMP;

    public UR10_Joints ur10Instance;
    public Ctrl_Robotiq_2F_85 robotiqInstance;

    private void Start() {
        btn_exit.onClick.AddListener(() => SwitchUI(ui_Main, ui_UR10));
    }
    void FixedUpdate() {
        // ziskani pozic kloubu pro zobrazeni
        j1TMP.text = ur10Instance.rot_j1.ToString();
        j2TMP.text = ur10Instance.rot_j2.ToString();
        j3TMP.text = ur10Instance.rot_j3.ToString();
        j4TMP.text = ur10Instance.rot_j4.ToString();
        j5TMP.text = ur10Instance.rot_j5.ToString();
        j6TMP.text = ur10Instance.rot_j6.ToString();

        strokeTMP.text = robotiqInstance.gripper_stroke.ToString();
    }

    void SwitchUI(GameObject ui_open, GameObject ui_close) {

        ui_close.SetActive(false);
        ui_open.SetActive(true);
    }
}

