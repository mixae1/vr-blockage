using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KerlingScoreCalculator : MonoBehaviour
{
    // Точка WIN
    public Transform winPoint;

    // Максимальное количество очков
    public int maxPoints = 5;

    void Start()
    {

    }

    int CalculateBallScore(GameObject ball)
    {
        // Получаем позицию шара
        Vector3 ballPosition = ball.transform.position;

        // Рассчитываем расстояние до точки WIN
        float distance = Vector3.Distance(ballPosition, winPoint.position);

        // Рассчитываем очки
        int score = (int)Mathf.Max(maxPoints - distance, 0);

        return score;
    }

    public int CalculateScore(GameObject[] balls = null)
    {
        if (balls == null) { 
            balls = GameObject.FindGameObjectsWithTag("Ball");
        }

        // Переменная для хранения общей суммы очков
        int totalScore = 0;

        // Рассчитываем очки для каждого шара
        foreach (var ball in balls)
        {
            totalScore += CalculateBallScore(ball);
        }

        return totalScore;
    }
}