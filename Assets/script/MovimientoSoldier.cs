using UnityEngine;

public class MovimientoSoldier : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;

    // Opcional para detectar el suelo de forma sencilla
    private bool enSuelo;
    public Transform controladorSuelo;
    public float radioSuelo = 0.2f;
    public LayerMask queEsSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal usando la velocidad f�sica (respeta colisiones)
        float movimientoX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(movimientoX * velocidad, rb.linearVelocity.y);

        // Salto b�sico
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.001f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }
    }
}