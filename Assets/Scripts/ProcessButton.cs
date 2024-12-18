using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ProcessButton : MonoBehaviour
{

    public InputActionReference menu;
    public InputActionReference exit;

    public GameObject MenuObject;
    public Canvas canvas;
    public Light m_light;
    Renderer menuRenderer;

    public Slider slider;
    

    // Start is called before the first frame update
    void Start()
    {
        menu.action.performed += logMenu;
        exit.action.performed += logExit;

        menuRenderer = MenuObject.GetComponent<Renderer>();
        
    }

    void logMenu(InputAction.CallbackContext context){
        menuRenderer.enabled = !menuRenderer.enabled;
        canvas.enabled = !canvas.enabled;
    }

    void logExit(InputAction.CallbackContext context){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        m_light.intensity = slider.value;
    }
}
