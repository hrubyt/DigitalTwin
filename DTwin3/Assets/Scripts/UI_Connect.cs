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

    //Debug.Log("Text byl ulo�en: " + savedText); // v�pis ulozen�ho textu pro kontrolu
    
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
            Debug.Log("Connecting to adress: " + connection_adress); // v�pis ulozen�ho textu pro kontrolu
            GlobalVariables_Main_Control.connect = true;
            GlobalVariables_Main_Control.disconnect = false;
        } else {
            Debug.Log("The text entered is not a valid IP address: " + connection_adress); // vzpis chybov� zpr�vy
        }

    }
    
    void Disconnect(string connection_adress) {
        Debug.Log("Disconnecting from adress: " + connection_adress);
        GlobalVariables_Main_Control.connect = false;
        GlobalVariables_Main_Control.disconnect = true;
    }

    private bool IsIPAddress(string text) {
        // Regul�rn� v�raz pro kontrolu form�tu IP adresy
        string ipAddressPattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

        // Overen� pomoc� regul�rn�ho v�razu
        return Regex.IsMatch(text, ipAddressPattern);
    }
}
