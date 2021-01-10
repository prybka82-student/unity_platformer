using UnityEngine;
using System.Collections;

public class PlatformFall : MonoBehaviour
{
    public float fallDelay = 1f; // Czas, po którym platforma zacznie opadać

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
    }

    // Dotknięcie platformy przed obiekt o tagu "Player" spowoduje opadanie platformy po czasie fallDelay
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            Invoke("Fall", fallDelay);
    }
    // Make our object fall by turning off isKinematic.
    void Fall()
    {
        rb2d.isKinematic = false;
    }
}
