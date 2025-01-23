using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;
using System.Linq;

public class MenuManager : MonoBehaviour
{
    public Animator animator;
    public float transitionDelayTime = 1.0f;
    
    void Awake()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Exit() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    
    public void RunLevel() {
        StartCoroutine(DelayLoadLevel("Level3"));
    }

    IEnumerator DelayLoadLevel(string scene)
    {
        animator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelayTime);
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }

}
