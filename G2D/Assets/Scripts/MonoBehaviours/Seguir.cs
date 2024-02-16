using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
{
    public Transform target; // El transform del jugador Pomodoro
    public float speed = 3f; // Velocidad de movimiento del enemigo

    private void Update()
    {
        if (target != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            // Mueve el enemigo en la dirección del jugador con una velocidad constante
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}




