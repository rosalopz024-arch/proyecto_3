using UnityEngine;

public class NPC_Controller : MonoBehaviour
{
    public float velocidad = 2f;
    public Transform puntoA;
    public Transform puntoB;
    private Vector3 objetivoActual;

    void Start()
    {
        // Empieza patrullando hacia el punto B
        if (puntoB != null)
        {
            objetivoActual = puntoB.position;
        }
    }

    void Update()
    {
        if (puntoA == null || puntoB == null) return;

        // Mover hacia el punto objetivo
        transform.position = Vector3.MoveTowards(transform.position, objetivoActual, velocidad * Time.deltaTime);

        // Si llega cerca del objetivo, cambiar de dirección
        if (Vector3.Distance(transform.position, objetivoActual) < 0.1f)
        {
            if (objetivoActual == puntoB.position)
            {
                objetivoActual = puntoA.position;
                Girar(false); // Voltear sprite hacia la izquierda
            }
            else
            {
                objetivoActual = puntoB.position;
                Girar(true); // Voltear sprite hacia la derecha
            }
        }
    }

    void Girar(bool mirarDerecha)
    {
        Vector3 escala = transform.localScale;
        escala.x = mirarDerecha ? Mathf.Abs(escala.x) : -Mathf.Abs(escala.x);
        transform.localScale = escala;
    }
}