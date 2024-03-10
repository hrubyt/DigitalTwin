using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Reseter : MonoBehaviour
{
    // Button for reset
    [SerializeField] Button btn_Reset;
    void Start() {
        btn_Reset.onClick.AddListener(ResetScene);        
    }

    void ResetScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
