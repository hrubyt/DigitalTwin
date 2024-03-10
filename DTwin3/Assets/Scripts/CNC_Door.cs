using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CNC_Door : MonoBehaviour {

    // Door button
    public Button btn_door;

    [SerializeField] private bool start_movement = true;

    private bool openDoor = false;
    [SerializeField] private float speed = 0.5f;

    private const float openDoorPos = -0.65f;
    private const float closeDoorPos = 0f;

    private float targetDoorPos = 0f;

    void Start() {
        btn_door.onClick.AddListener(() => ToggleDoor());
    }

    void Update() {
        if (start_movement) {
            // Pohyb dveri
            transform.localPosition = new Vector3(
                Mathf.MoveTowards(transform.localPosition.x, targetDoorPos, speed * Time.deltaTime),
                transform.localPosition.y,
                transform.localPosition.z
            );

            // Zastavení pohybu, pokud jsme dosáhli cílové pozice
            if (Mathf.Approximately(transform.localPosition.x, targetDoorPos)) {
                start_movement = false;
            }
        }
    }

    void ToggleDoor() {
        
        openDoor = !openDoor;
        if (openDoor) {
            targetDoorPos = openDoorPos;
        } else {
            targetDoorPos = closeDoorPos;
        }

        // Nastavení pohybu dverí
        start_movement = true;
    }
}
