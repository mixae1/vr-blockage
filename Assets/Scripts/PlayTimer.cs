using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayTimer : MonoBehaviour
{
    public float timer;
    public List<Text> texts;
    public List<TextMeshProUGUI> meshTexts;
    float startTimer;

    bool enable = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    public void Play() {
        enable = true;
        startTimer = Time.time;
    }

    public void Stop() {
        enable = false;
    }

    void Update()
    {
        if(enable) timer = Time.time - startTimer;
        foreach (var item in texts)
        {
            item.text = $"{timer} s";
        }
        foreach (var item in meshTexts)
        {
            item.text = $"{timer} s";
        }
    }
}
