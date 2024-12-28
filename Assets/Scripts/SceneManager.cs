using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
public class SceneManager : MonoBehaviour
{
    public Light m_light;
    public Slider slider;

    void Start()
    {
        float lightKoef = PlayerPrefs.GetFloat("lightKoef", 0.5f);
        Debug.Log("Загружаем значение из PlayerPrefs: " + lightKoef);

        if(m_light != null) {
            m_light.intensity = lightKoef;
        } else {
            Debug.Log("Где света?");
        }
        if(slider != null) {
            slider.value = lightKoef;
        }
    }


    public void ChangeLightKoef() {
        PlayerPrefs.SetFloat("lightKoef", slider.value);
        Debug.Log("Сохраняем значение в PlayerPrefs: " + slider.value);

        if(m_light != null) {
            m_light.intensity = slider.value;
        }
    }

    public void Exit() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void Menu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }

    public void RunLevel() {
        TMP_Text text = GameObject.FindGameObjectWithTag("LevelLabel").GetComponent<TMP_Text>();
        switch (text.text)
        {
            case "Уровень 1":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
                break;
            case "Уровень 2":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
                break;
            case "Уровень 3":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
                break;
            default: 
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
                break;
        }
        
    }
}
