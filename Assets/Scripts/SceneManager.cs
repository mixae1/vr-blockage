using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;
using System.Linq;
public class SceneManager : MonoBehaviour
{
    KerlingScoreCalculator kerlingScoreCalculator;
    GameObject[] balls;
    public Text tScore;
    public Text tLeftTime;
    public Text tEndGameText;
    public GameObject endGameText;
    public GameObject timePointText;
    public float gameTime = 30f;
    float timeLeft;
    bool isPlaying = false;

    public Animator animator;
    public float transitionDelayTime = 1.0f;

    void Awake() {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    void Start()
    {
        kerlingScoreCalculator = GetComponent<KerlingScoreCalculator>();
        balls = GameObject.FindGameObjectsWithTag("Ball");
        if(balls.Length == 0) balls = null;

        if(timePointText == null) timePointText = GameObject.FindGameObjectWithTag("T1");
        if(endGameText == null) endGameText = GameObject.FindGameObjectWithTag("T2");

        timePointText.SetActive(false);
        endGameText.SetActive(false);
    }

    void Update() {
        if(isPlaying) {
            timeLeft -= Time.deltaTime;
            int score = kerlingScoreCalculator.CalculateScore(balls);
            tScore.text = $"{score} / {kerlingScoreCalculator.maxPoints * (balls?.Length ?? 5) }!";
            tLeftTime.text = $"Осталось {(int)timeLeft} секунд!";
        
            if ((int)timeLeft <= 0) {
                Finish(score);
            }
        }

    }

    IEnumerator DelayLoadLevel(string scene)
    {
        animator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelayTime);
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }

    public void Menu() {
        StartCoroutine(DelayLoadLevel("MenuScene"));
    }

    public void StartGame() {
        timeLeft = gameTime;
        isPlaying = true;
        endGameText.SetActive(false);
        timePointText.SetActive(true);

        foreach(var ball in balls) {
            ball.GetComponent<SaveStartPosition>().setStartPos();
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    public void Finish(int points) {
        isPlaying = false;
        endGameText.SetActive(true);
        foreach(var ball in balls) {
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if(tEndGameText != null) {
            tEndGameText.text = $"Конец игры!\nВы заработали {points} очков из {kerlingScoreCalculator.maxPoints * (balls?.Length ?? 5)} возможных";
        }
    }

}
