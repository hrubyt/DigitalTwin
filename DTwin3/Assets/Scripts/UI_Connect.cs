using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.UI;

public class UI_Connect : MonoBehaviour
{
    // Buttons for cameras
    public Button btn_connect;
    public Button btn_disconnect;
    public Button btn_deleteUI;

    public GameObject ui_connect;

    public TMP_InputField inputField_IPadress;

    //Debug.Log("Text byl uložen: " + savedText); // výpis ulozeného textu pro kontrolu
    
    private void Start() {
        
    }
    private void Update() {
        string ip_adress = inputField_IPadress.text;
        GlobalVariables_Main_Control.opcua_config[0] = ip_adress; // propojeni s OPC UA serverem IP adresy
        // dosazeni inputu do promenne
        btn_connect.onClick.AddListener(() => Connect(ip_adress));

        btn_disconnect.onClick.AddListener(() => Disconnect(ip_adress));

        btn_deleteUI.onClick.AddListener(() => CloseUI(ui_connect));
        

    }
    //Functions for buttons
    void CloseUI(GameObject ui_close) {
        ui_close.SetActive(false);
    }
    
    void Connect(string connection_adress) {
        if (IsIPAddress(connection_adress)) {
            Debug.Log("Connecting to adress: " + connection_adress); // výpis ulozeného textu pro kontrolu
            GlobalVariables_Main_Control.connect = true;
            GlobalVariables_Main_Control.disconnect = false;
        } else {
            Debug.Log("The text entered is not a valid IP address: " + connection_adress); // vzpis chybové zprávy
        }

    }
    
    void Disconnect(string connection_adress) {
        Debug.Log("Disconnecting from adress: " + connection_adress);
        GlobalVariables_Main_Control.connect = false;
        GlobalVariables_Main_Control.disconnect = true;
    }

    private bool IsIPAddress(string text) {
        // Regulární výraz pro kontrolu formátu IP adresy
        string ipAddressPattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

        // Overení pomocí regulárního výrazu
        return Regex.IsMatch(text, ipAddressPattern);
    }
}
