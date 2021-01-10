using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true; // Infinite scroller we move in one direction
    [HideInInspector]
    public bool jump = false;         // Has our character jumped?
    public float moveForce = 365f;                    // movement Force multiplier
    public float maxSpeed = 5f;                       // Maximum velocity
    public float jumpForce = 1000f;                   // y Velocity of Jumping
    public Transform groundCheck;                     // Used to compute if our character is touching the ground.
                                                      // Essentially casting a ray downwards onto the ground plane.

    private bool grounded = false;                    // Are we on the ground or not?
    private Rigidbody2D rb2d;                         // Instance of our RigidBody. Good practice to do this, as opposed
                                                      // to directly referencing our rigidbody object.
    private float horizontalInput; 

    public int TestValue1;
    public int TestValue2;

    // Use this for initialization
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Czy postać jest na ziemi
        grounded = Physics2D.Linecast( //rzuca odcinek i informuje, czy jakiś obiekt dotknął tej linii
                transform.position, //początek
                groundCheck.position, //koniec
                1 << LayerMask.NameToLayer("Ground")); //ograniczenie do określonej warstwy
        
        // Włączenie skoku, jeśli wciśnięto spację i postać jest na ziemi
        if (Input.GetButtonDown("Jump") && grounded)
            jump = true;
    }

    // Odwracanie postaci
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }

    // Called once per physics frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");  // wciśnięcie i przytrzymanie klawiszy kursora w lewo lub w prawo

        //Przyspieszanie
        if (horizontalInput * rb2d.velocity.x < maxSpeed)
            SpeedUp();

        // If we're greater than our max speed, then keep moving us at max speed.
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = GetMaxSpeed();

        // Odwracanie postaci
        if (horizontalInput > 0 && !facingRight)
            Flip();
        else if (horizontalInput < 0 && facingRight)
            Flip();
        
        // W razie skoku dodaj moc pionową
        if (jump)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }

    }

    void SpeedUp() => rb2d.AddForce(Vector2.right * horizontalInput * moveForce);
    Vector2 GetMaxSpeed() => new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
}
