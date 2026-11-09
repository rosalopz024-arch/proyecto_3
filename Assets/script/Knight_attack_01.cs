using UnityEngine;

public class KnightController : MonoBehaviour
{
    [Header("Patrulla y Movimiento")]
    public float velocidad = 2f;
    public Transform comprobadorBorde;
    public float distanciaRaycast = 0.5f;
    public LayerMask capaSuelo;

    [Header("Detecci�n y Ataque")]
    public float rangoAtaque = 1.5f;
    public Transform jugador;

    private bool mirandoDerecha = true;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Si no asignaste el jugador en el Inspector, lo busca autom�ticamente por nombre o tag
        if (jugador == null)
        {
            GameObject objJugador = GameObject.Find("Soldier");
            if (objJugador != null) jugador = objJugador.transform;
        }
    }

    void Update()
    {
        // 1. Verificar distancia con el jugador para atacar
        if (jugador != null && Vector2.Distance(transform.position, jugador.position) <= rangoAtaque)
        {
            Atacar();
        }
        else
        {
            Patrullar();
        }
    }

    void Patrullar()
    {
        // Movimiento constante en la direcci�n actual
        float direccion = mirandoDerecha ? 1f : -1f;
        rb.linearVelocity = new Vector2(direccion * velocidad, rb.linearVelocity.y);

        // Detectar si hay suelo adelante antes de avanzar (para no caerse de la plataforma)
        Vector2 OrigenRay = comprobadorBorde != null ? comprobadorBorde.position : transform.position;
        RaycastHit2D haySuelo = Physics2D.Raycast(OrigenRay, Vector2.down, distanciaRaycast, capaSuelo);

        if (haySuelo.collider == null)
        {
            Girar();
        }
    }

    void Atacar()
    {
        // Detenerse al atacar
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);

        // Disparar animaci�n de ataque si tienes el par�metro Trigger "Attacking" o "Attack" en el Animator
        if (anim != null)
        {
            anim.SetTrigger("Attack");
        }
    }

    void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmosSelected()
    {
        // Visualizar el rango de ataque en la ventana Scene
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoAtaque);
    }
}