using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform pointA; // Точка A
    public Transform pointB; // Точка B
    public float speed = 5f; // Скорость перемещения

    private Transform target; // Целевая точка перемещения

    private void Start()
    {
        // Начинаем с перемещения к точке B
        target = pointB;
    }

    private void Update()
    {
        // Вычисляем направление и расстояние к целевой точке
        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;

        // Если расстояние меньше определенной величины, меняем целевую точку и разворачиваем персонаж
        if (distance < 0.1f)
        {
            if (target == pointA || target == pointB)
            {
                target = (target == pointA) ? pointB : pointA;
                transform.Rotate(0f, 180f, 0f); // Мгновенный разворот на 180 градусов
            }
        }

        // Перемещаем персонаж в направлении целевой точки с определенной скоростью
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}


