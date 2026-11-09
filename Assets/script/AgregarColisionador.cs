using UnityEngine;

public class AgregarColisionador : MonoBehaviour
{
    void Awake()
    {
        // Se asegura de que el objeto tenga un BoxCollider2D de forma automática
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<BoxCollider2D>();
        }

        // Configura el colisionador para que sea sólido (no Trigger)
        collider.isTrigger = false;
    }
}