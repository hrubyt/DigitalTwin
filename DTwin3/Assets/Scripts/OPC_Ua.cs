
// -------------------- Libraries ----------------- //
// -------------------- System -------------------- //

using System;
using System.Threading;
// -------------------- Unity -------------------- //
using UnityEngine;
// -------------------- OPCUA -------------------- //
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;

// -------------------- Class {Global Variable} -> Main Control -------------------- //
public static class GlobalVariables_Main_Control {
    // String //
    public static string[] opcua_config = new string[2];
    // Bool // 
    public static bool enable_r, enable_w;
    public static bool connect, disconnect;
}

public static class GlobalVariables_OPC_UA_client {

    // Test
    public static float rot_j1;// = 90f;
    public static NodeId rot_j1_node = "ns=3;s=::AsGlobalPV:dT_Main.rot_j1"; //prepsat podle struktury na serveru

    //
    /*
    // gripper
    public static float gripper_speed;
    public static float gripper_stroke;

    // bool signal sverak
    public static bool gapSize;

    // dvere zavrit otevrit //1signal
    public static bool door_signal;

    // Node Ids
    public static NodeId gripper_speed_node = "ns=3;s=::AsGlobalPV:dT_Main.gripper.gripper_speed";
    public static NodeId gripper_stroke_node = "ns=3;s=::AsGlobalPV:dT_Main.gripper.gripper_stroke";
    public static NodeId gapSize_node = "ns=3;s=::AsGlobalPV:dT_Main.gripper.signal";
    public static string door_signal_node = "ns=3;s=::AsGlobalPV:dT_Main.door.signal";

    // cube position, scale, rotation
    public static float cube_position;
    public static float cube_scale;
    public static float cube_rotation;

    // Node cube position, scale, rotation
    public static string cube_position_node = "ns=3;s=::AsGlobalPV:dT_Main.cube.position";
    public static string cube_scale_node = "ns=3;s=::AsGlobalPV:dT_Main.cube.scale";
    public static string cube_rotation_node = "ns=3;s=::AsGlobalPV:dT_Main.cube.rotation";

    // additional variables
    public static float pos_Xaxis;// = 0.0f;
    public static float pos_Yaxis;// = 0.0f;
    public static float pos_Zaxis;// = 0.0f;
    public static float rot_Aaxis;// = 0.0f;
    public static float rot_Caxis;// = 0.0f;

    // Nodes for additional variables
    public static NodeId pos_Xaxis_node = "ns=3;s=::AsGlobalPV:dT_Main.pos_Xaxis";
    public static NodeId pos_Yaxis_node = "ns=3;s=::AsGlobalPV:dT_Main.pos_Yaxis";
    public static NodeId pos_Zaxis_node = "ns=3;s=::AsGlobalPV:dT_Main.pos_Zaxis";
    public static NodeId rot_Aaxis_node = "ns=3;s=::AsGlobalPV:dT_Main.rot_Aaxis";
    public static NodeId rot_Caxis_node = "ns=3;s=::AsGlobalPV:dT_Main.rot_Caxis";

    // Rychlosti
    public static float speed_Xaxis;// = 0.5f;
    public static float speed_Yaxis;// = 0.5f;
    public static float speed_Zaxis;// = 0.5f;
    public static float speed_Aaxis;// = 0.5f;
    public static float speed_Caxis;// = 0.5f;

    // Nodes for speed variables
    public static NodeId speed_Xaxis_node = "ns=3;s=::AsGlobalPV:dT_Main.speed_Xaxis";
    public static NodeId speed_Yaxis_node = "ns=3;s=::AsGlobalPV:dT_Main.speed_Yaxis";
    public static NodeId speed_Zaxis_node = "ns=3;s=::AsGlobalPV:dT_Main.speed_Zaxis";
    public static NodeId speed_Aaxis_node = "ns=3;s=::AsGlobalPV:dT_Main.speed_Aaxis";
    public static NodeId speed_Caxis_node = "ns=3;s=::AsGlobalPV:dT_Main.speed_Caxis";



    // ------------------------------ UR10 ----------------------------- //
    // Rotation variables
    public static float rot_j1;// = 90f;
    public static float rot_j2;// = 180f;
    public static float rot_j3;// = 180f;
    public static float rot_j4;// = 180f;
    public static float rot_j5;// = 180f;
    public static float rot_j6;// = 180f;

    // Nodes for rotation variables
    public static NodeId rot_j1_node = "ns=3;s=::AsGlobalPV:dT_Main.rot_j1";
    public static NodeId rot_j2_node = "ns=3;s=::AsGlobalPV:dT_Main.rot_j2";
    public static NodeId rot_j3_node = "ns=3;s=::AsGlobalPV:dT_Main.rot_j3";
    public static NodeId rot_j4_node = "ns=3;s=::AsGlobalPV:dT_Main.rot_j4";
    public static NodeId rot_j5_node = "ns=3;s=::AsGlobalPV:dT_Main.rot_j5";
    public static NodeId rot_j6_node = "ns=3;s=::AsGlobalPV:dT_Main.rot_j6";

    // Speed of joints
    public static float speed_j1;// = 0.5f;
    public static float speed_j2;// = 0.5f;
    public static float speed_j3;// = 0.5f;
    public static float speed_j4;// = 0.5f;
    public static float speed_j5;// = 0.5f;
    public static float speed_j6;// = 0.5f;

    // Nodes for speed of joints variables
    public static NodeId speed_j1_node = "ns=3;s=::AsGlobalPV:dT_Main.speed_j1";
    public static NodeId speed_j2_node = "ns=3;s=::AsGlobalPV:dT_Main.speed_j2";
    public static NodeId speed_j3_node = "ns=3;s=::AsGlobalPV:dT_Main.speed_j3";
    public static NodeId speed_j4_node = "ns=3;s=::AsGlobalPV:dT_Main.speed_j4";
    public static NodeId speed_j5_node = "ns=3;s=::AsGlobalPV:dT_Main.speed_j5";
    public static NodeId speed_j6_node = "ns=3;s=::AsGlobalPV:dT_Main.speed_j6";
    

    */

}


public class data_processing : MonoBehaviour {
    // -------------------- ApplicationConfiguration -------------------- //
    private ApplicationConfiguration client_configuration_r = new ApplicationConfiguration();
    private ApplicationConfiguration client_configuration_w = new ApplicationConfiguration();
    // -------------------- EndpointDescription -------------------- //
    private EndpointDescription client_end_point_r, client_end_point_w;
    // -------------------- Session -------------------- //
    private Session client_session_r, client_session_w;
    // -------------------- Thread -------------------- //
    private Thread opcua_client_r_Thread, opcua_client_w_Thread;
    // -------------------- Int -------------------- //
    private int main_state = 0;

    // ------------------------------------------------------------------------------------------------------------------------//
    // ------------------------------------------------ INITIALIZATION {START} ------------------------------------------------//
    // ------------------------------------------------------------------------------------------------------------------------//
    void Start() {
        // PLC IP Address
        GlobalVariables_Main_Control.opcua_config[0] = "192.168.0.10"; //opc.tcp://192.168.0.10:4840
        // OPC UA Port Number
        GlobalVariables_Main_Control.opcua_config[1] = "4840";

        // Initiation
        // Control -> Start {Read OPCUA data}
        GlobalVariables_Main_Control.enable_r = true;
        // Control -> Start {Read OPCUA data}
        GlobalVariables_Main_Control.enable_w = true;

    }

    // ------------------------------------------------------------------------------------------------------------------------ //
    // ------------------------------------------------ MAIN FUNCTION {Cyclic} ------------------------------------------------ //
    // ------------------------------------------------------------------------------------------------------------------------ //
    private void Update() {
        switch (main_state) {
            case 0: {
                    // ------------------------ Wait State {Disconnect State} ------------------------//
                    if (GlobalVariables_Main_Control.connect == true) {
                        // Control -> Start {Read OPCUA data}
                        GlobalVariables_Main_Control.enable_r = true;
                        // Control -> Start {Write OPCUA data}
                        GlobalVariables_Main_Control.enable_w = true;

                        // Initialization threading block
                        opcua_client_r_Thread = new Thread(() => OPCUa_r_thread_function(GlobalVariables_Main_Control.opcua_config[0], GlobalVariables_Main_Control.opcua_config[1]));
                        opcua_client_r_Thread.IsBackground = true;
                        // Start threading block
                        opcua_client_r_Thread.Start();

                        // Initialization threading block
                        opcua_client_w_Thread = new Thread(() => OPCUa_w_thread_function(GlobalVariables_Main_Control.opcua_config[0], GlobalVariables_Main_Control.opcua_config[1]));
                        opcua_client_w_Thread.IsBackground = true;
                        // Start threading block
                        opcua_client_w_Thread.Start();

                        // go to connect state
                        main_state = 1;
                    }
                }
                break;
            case 1: {
                    // ------------------------ Data Processing State {Connect State} ------------------------//
                    if (GlobalVariables_Main_Control.disconnect == true) {
                        // Control -> Start {Read OPCUA data}
                        GlobalVariables_Main_Control.enable_r = false;
                        // Control -> Start {Write OPCUA data}
                        GlobalVariables_Main_Control.enable_w = false;

                        // Abort threading block {OPCUA -> read data}
                        if (opcua_client_r_Thread.IsAlive == true) {
                            opcua_client_r_Thread.Abort();
                        }
                        // Abort threading block {OPCUA -> write data}
                        if (opcua_client_w_Thread.IsAlive == true) {
                            opcua_client_w_Thread.Abort();
                        }
                        if (opcua_client_r_Thread.IsAlive == false && opcua_client_w_Thread.IsAlive == false) {
                            // go to initialization state {wait state -> disconnect state}
                            main_state = 0;
                        }
                    }
                }
                break;
        }
    }

    // ------------------------------------------------------------------------------------------------------------------------//
    // -------------------------------------------------------- FUNCTIONS -----------------------------------------------------//
    // ------------------------------------------------------------------------------------------------------------------------//

    // -------------------- Abort Threading Blocks -------------------- //
    void OnApplicationQuit() {
        try {
            // Stop - threading while
            GlobalVariables_Main_Control.enable_r = false;
            GlobalVariables_Main_Control.enable_w = false;

            // Abort threading block
            if (opcua_client_r_Thread.IsAlive == true) {
                opcua_client_r_Thread.Abort();
            }
            if (opcua_client_w_Thread.IsAlive == true) {
                opcua_client_w_Thread.Abort();
            }
        } catch (Exception e) {
            // Destroy all
            Destroy(this);
        } finally {
            // Destroy all
            Destroy(this);
        }
    }

    void OPCUa_r_thread_function(string ip_adr, string port_adr) {
        if (GlobalVariables_Main_Control.enable_r == true) {
            // OPCUa client configuration
            client_configuration_r = opcua_client_configuration();
            // Establishing communication
            client_end_point_r = CoreClientUtils.SelectEndpoint("opc.tcp://" + ip_adr + ":" + port_adr, useSecurity: false); // , operationTimeout: 5000);
            // Create session
            client_session_r = opcua_create_session(client_configuration_r, client_end_point_r);
        }

        // Threading while {read data}
        while (GlobalVariables_Main_Control.enable_r) {

            GlobalVariables_OPC_UA_client.rot_j1 = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.rot_j1_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);

            /*
            // Gripper
            GlobalVariables_OPC_UA_client.gripper_speed = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.gripper_speed_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.gripper_stroke = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.gripper_stroke_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
           
            // Workholder
            GlobalVariables_OPC_UA_client.gapSize = bool.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.gapSize_node).ToString());
            
            // CNC SLV EDU
            // GlobalVariables_OPC_UA_client.door_signal = bool.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.door_signal_node).ToString());

            GlobalVariables_OPC_UA_client.pos_Xaxis = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.pos_Xaxis_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.pos_Yaxis = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.pos_Yaxis_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.pos_Zaxis = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.pos_Zaxis_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.rot_Aaxis = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.rot_Aaxis_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.rot_Caxis = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.rot_Caxis_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            
            GlobalVariables_OPC_UA_client.speed_Xaxis = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.speed_Xaxis_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.speed_Yaxis = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.speed_Yaxis_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.speed_Zaxis = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.speed_Zaxis_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.speed_Aaxis = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.speed_Aaxis_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.speed_Caxis = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.speed_Caxis_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            
            // UR 10 ROBOT
            GlobalVariables_OPC_UA_client.rot_j1 = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.rot_j1_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.rot_j2 = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.rot_j2_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.rot_j3 = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.rot_j3_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.rot_j4 = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.rot_j4_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.rot_j5 = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.rot_j5_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.rot_j6 = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.rot_j6_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            
            GlobalVariables_OPC_UA_client.speed_j1 = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.speed_j1_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.speed_j2 = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.speed_j2_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.speed_j3 = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.speed_j3_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.speed_j4 = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.speed_j4_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.speed_j5 = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.speed_j5_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            GlobalVariables_OPC_UA_client.speed_j6 = float.Parse(client_session_r.ReadValue(GlobalVariables_OPC_UA_client.speed_j6_node).ToString(), System.Globalization.CultureInfo.InvariantCulture);
            */

            // Thread Sleep {2 ms}
            Thread.Sleep(2);
            
    
        }
    }

    // ------------------------ Threading Block { OPCUa Write Data } ------------------------//
    void OPCUa_w_thread_function(string ip_adr, string port_adr) {
        if (GlobalVariables_Main_Control.enable_w == true) {
            // OPCUa client configuration
            client_configuration_w = opcua_client_configuration();
            // Establishing communication
            client_end_point_w = CoreClientUtils.SelectEndpoint("opc.tcp://" + ip_adr + ":" + port_adr, useSecurity: false); // , operationTimeout: 5000);
            // Create session
            client_session_w = opcua_create_session(client_configuration_w, client_end_point_w);
        }

        // Threading while {write data}
        while (GlobalVariables_Main_Control.enable_w) {

            // -------------------- Cube Position Data -------------------- //

            /*
            opcua_write_value(client_session_w, GlobalVariables_OPC_UA_client.cube_position_node, GlobalVariables_OPC_UA_client.cube_position.ToString());
            opcua_write_value(client_session_w, GlobalVariables_OPC_UA_client.cube_scale_node, GlobalVariables_OPC_UA_client.cube_scale.ToString());
            opcua_write_value(client_session_w, GlobalVariables_OPC_UA_client.door_signal_node, GlobalVariables_OPC_UA_client.door_signal.ToString());
            */

            // Thread Sleep {10 ms}
            Thread.Sleep(10);
            
    
        }
    }
    // ------------------------ OPCUa Client {Application -> Configuration (STEP 1)} ------------------------//
    ApplicationConfiguration opcua_client_configuration() {
        // Configuration OPCUa Client {W/R -> Data}
        var config = new ApplicationConfiguration() {
            // Initialization (Name, Uri, etc.)
            ApplicationName = "OPCUa_AS", 
            ApplicationUri = Utils.Format(@"urn:{0}:OPCUa_AS", System.Net.Dns.GetHostName()),
            // Type -> Client
            ApplicationType = ApplicationType.Client,
            SecurityConfiguration = new SecurityConfiguration {
                // Security Configuration - Certificate
                ApplicationCertificate = new CertificateIdentifier { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\MachineDefault", SubjectName = Utils.Format(@"CN={0}, DC={1}", "OPCUa_AS", System.Net.Dns.GetHostName()) },
                TrustedIssuerCertificates = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Certificate Authorities" },
                TrustedPeerCertificates = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Applications" },
                RejectedCertificateStore = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\RejectedCertificates" },
                AutoAcceptUntrustedCertificates = true,
                AddAppCertToTrustedStore = true
            },
            TransportConfigurations = new TransportConfigurationCollection(),
            TransportQuotas = new TransportQuotas { OperationTimeout = 5000 },
            ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 },
            TraceConfiguration = new TraceConfiguration()
        };
        config.Validate(ApplicationType.Client).GetAwaiter().GetResult();
        if (config.SecurityConfiguration.AutoAcceptUntrustedCertificates) {
            config.CertificateValidator.CertificateValidation += (s, e) => { e.Accept = (e.Error.StatusCode == StatusCodes.BadCertificateUntrusted); };
        }

        var application = new ApplicationInstance {
            ApplicationName = "OPCUa_AS",
            ApplicationType = ApplicationType.Client,
            ApplicationConfiguration = config
        };
        application.CheckApplicationInstanceCertificate(false, 2048).GetAwaiter().GetResult();

        return config;
    }

    // ------------------------ OPCUa Client {Application -> Create Session (STEP 2)} ------------------------//
    Session opcua_create_session(ApplicationConfiguration client_configuration, EndpointDescription client_end_point) {
        return Session.Create(client_configuration, new ConfiguredEndpoint(null, client_end_point, EndpointConfiguration.Create(client_configuration)), false, "", 5000, null, null).GetAwaiter().GetResult();
    }

    // ------------------------ OPCUa Client {Write Value (Define - Node)} ------------------------//
    bool opcua_write_value(Session client_session, string node_id, string value_write) {
        // Initialization (Bide)
        NodeId init_node = NodeId.Parse(node_id);

        try {
            // Find Node (OPCUa Client)
            Node node = client_session.NodeCache.Find(init_node) as Node;
            DataValue init_data_value = client_session.ReadValue(node.NodeId);

            // Preparation data for writing
            WriteValue value = new WriteValue() {
                NodeId = init_node,
                AttributeId = Attributes.Value,
                Value = new DataValue(new Variant(Convert.ChangeType(value_write, init_data_value.Value.GetType()))),
            };

            // Initialization (Write)
            WriteValueCollection init_write = new WriteValueCollection();
            // Append variable
            init_write.Add(value);

            StatusCodeCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;

            // Wriate data
            client_session.Write(null, init_write, out results, out diagnosticInfos);

            // Check Result (Status)
            if (results[0] == StatusCodes.Good) {
                return true;
            } else {
                return false;
            }

        } catch (Exception e) {
            Console.WriteLine(e.Message);

            return false;
        }
    }
}
