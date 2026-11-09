using UnityEngine;

public class BloqueSorpresa : MonoBehaviour
{
    public GameObject premioPrefab;
    public Transform puntoAparicion;
    private bool yaUsado = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.name == "Soldier") && !yaUsado)
        {
            if (collision.transform.position.y < transform.position.y)
            {
                DarPremio();
            }
        }
    }

    void DarPremio()
    {
        yaUsado = true;

        if (premioPrefab != null)
        {
            Vector3 posicion = puntoAparicion != null ? puntoAparicion.position : transform.position + Vector3.up;
            Instantiate(premioPrefab, posicion, Quaternion.identity);
        }
    }
}