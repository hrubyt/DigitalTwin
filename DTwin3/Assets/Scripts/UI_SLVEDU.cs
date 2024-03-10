using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_SLVEDU : MonoBehaviour {

    // Buttons
    public Button btn_exit;

    // UI Gameobjects
    public GameObject ui_SLVEDU;
    public GameObject ui_Main;

    // Texts
    [SerializeField] private TextMeshProUGUI xaxisTMP;
    [SerializeField] private TextMeshProUGUI yaxisTMP;
    [SerializeField] private TextMeshProUGUI zaxisTMP;
    [SerializeField] private TextMeshProUGUI aaxisTMP;
    [SerializeField] private TextMeshProUGUI caxisTMP;

    [SerializeField] private TextMeshProUGUI whTMP;
    
    public CNC_allAxis CNCInstance;
    public CNC_Workholder WhInstance;


    void FixedUpdate() {
        // ziskani pozic kloubu pro zobrazeni
        xaxisTMP.text = CNCInstance.pos_Xaxis.ToString();
        yaxisTMP.text = CNCInstance.pos_Yaxis.ToString();
        zaxisTMP.text = CNCInstance.pos_Zaxis.ToString();
        aaxisTMP.text = CNCInstance.rot_Aaxis.ToString();
        caxisTMP.text = CNCInstance.rot_Caxis.ToString();

        whTMP.text = WhInstance.gapSize.ToString();

        btn_exit.onClick.AddListener(() => SwitchUI(ui_Main, ui_SLVEDU));

    }

    void SwitchUI(GameObject ui_open, GameObject ui_close) {

        ui_close.SetActive(false);
        ui_open.SetActive(true);
    }
}

