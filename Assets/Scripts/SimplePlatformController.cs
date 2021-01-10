using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true;     // skierowanie w prawo
    [HideInInspector]
    public bool jump = false;           // wykonywanie skoku
    public float moveForce = 365f;      // prędkość ruchu (mnożnik prędkości)
    public float maxSpeed = 5f;         // maksymalna prędkość
    public float jumpForce = 1000f;     // prędkość skoku

    public Transform groundCheck;       // obiekt groundCheck

    private bool grounded = false;      // czy postać na ziemi
    private Rigidbody2D rb2d;           // referencja do obiekt typu RigidBody2D będącego składnikiem postaci

    private float horizontalInput;      // jak długo przytrzymywano klawisz ruchu

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>(); // inicjalizacja referencji do ciała postaci
    }

    // aktualizacja w każdej klatce
    void Update()
    {
        grounded = Physics2D.Linecast(  //rzuca odcinek i informuje, czy jakiś obiekt dotknął tej linii
                transform.position,     //początek linii -- bieżący obiekt
                groundCheck.position,   //koniec linii -- obiekt potomny groundCheck
                1 << LayerMask.NameToLayer("Ground")); //tylko stykanie z warstwą "Ground"
        
        // włączenie skoku, jeśli wciśnięto spację i postać jest na ziemi
        if (Input.GetButtonDown("Jump") && grounded)
            jump = true;
    }

    // odwracanie postaci
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }

    // obliczenia parametrów ruchu wykonywane częściej niż raz na klatkę ruchu
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");  // wciśnięcie i przytrzymanie klawiszy kursora w lewo lub w prawo

        // przyspieszanie - wielokrotność stopnia przytrzymywania klawisza ruchu i bieżącej prędkości
        if (horizontalInput * rb2d.velocity.x < maxSpeed)
            SpeedUp();

        // ograniczenie do maks. prędkości
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = GetMaxSpeed();

        // odwracanie postaci
        if (horizontalInput > 0 && !facingRight)
            Flip();
        else if (horizontalInput < 0 && facingRight)
            Flip();
        
        // w razie skoku dodaj moc pionową
        if (jump)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }

    }
    // przyśpieszanie - dodawanie do mocy wielokrotności bieżącej prędkości, stopnia przytrzymania klawisza i mnożnika prędkości
    void SpeedUp() => rb2d.AddForce(Vector2.right * horizontalInput * moveForce);

    // pobranie maks. prędkości jako wektora dwuwymiar.
    Vector2 GetMaxSpeed() => new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
}
