using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Main : MonoBehaviour
{
    // Buttons
    public Button btn_UR10;
    public Button btn_SLVEDU;
    public Button btn_Connect;
    //public Button btn_test;

    // UI Gameobjects
    public GameObject ui_UR10;
    public GameObject ui_SLVEDU;
    public GameObject ui_connect;
    public GameObject ui_Main;


    
    void Start() {
        btn_UR10.onClick.AddListener(() => SwitchUI(ui_UR10, ui_Main));
        btn_SLVEDU.onClick.AddListener(() => SwitchUI(ui_SLVEDU, ui_Main));
        btn_Connect.onClick.AddListener(() => OpenUI(ui_connect));
        //btn_test.onClick.AddListener(() => test());

    }
    
    void SwitchUI(GameObject ui_open, GameObject ui_close) {

        ui_close.SetActive(false);
        ui_open.SetActive(true);
    }
    void OpenUI(GameObject ui_open) {
        // Invertuje aktuální stav aktivace objektu
        ui_open.SetActive(!ui_open.activeSelf);

        /*if (ui_open.activeSelf){
            ui_open.SetActive(false);
        }
        ui_open.SetActive(true);*/
    }
    
}

