using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Transform player; // Asigna el objeto del jugador en el Inspector
    public float detectionRange = 10f;
    public float minDetectionDistance = 2f; // Distancia mínima para detenerse
    public float speed = 3f;
    public Animator monsterAnimator; // Asigna el componente Animator en el Inspector

    void Update()
    {
        // Calcula la distancia entre el monstruo y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si el jugador está dentro del rango de visión
        if (distanceToPlayer <= detectionRange)
        {
            // Si la distancia es mayor que la distancia mínima de detección
            if (distanceToPlayer > minDetectionDistance)
            {
                // Orienta al monstruo hacia el jugador
                transform.LookAt(player);

                // Activa la animación de caminar (Walk)
                monsterAnimator.SetBool("Walk", true);

                // Mueve al monstruo hacia el jugador
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else
            {
                // Si la distancia es menor que la distancia mínima, detiene al monstruo
                monsterAnimator.SetBool("Walk", false);
            }
        }
        else
        {
            // Si el jugador está fuera del rango, detiene al monstruo
            monsterAnimator.SetBool("Walk", false);
        }
    }
}
