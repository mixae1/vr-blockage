using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownPlatform : MonoBehaviour
{
    // Коэффициент замедления
    public float slowdownFactor = 0.75f;

    void OnCollisionEnter(Collision collision)
    {
        // Проверяем, столкнулся ли объект с шаром
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Получаем доступ к rigidbody шара
            Rigidbody rb = collision.rigidbody;

            // Замедляем шар
            rb.velocity *= slowdownFactor;
        }
    }
}