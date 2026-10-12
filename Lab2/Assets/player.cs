using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update public float moveSpeed; // How fast the character moves[cite: 26]

    public float moveSpeed;
    public float jumpHeight; // How high the character jumps[cite: 26]
    
    public KeyCode Spacebar; // The button used for jumping[cite: 26]
    public KeyCode L; // The button used for left movement[cite: 26]
    public KeyCode R; // The button used for right movement[cite: 26]

    public Transform groundCheck; // An invisible point in space to check if player is touching the ground[cite: 32]
    public float groundCheckRadius; // Size of the circle around the player's feet[cite: 32]
    public LayerMask whatIsGround; // Stores what is considered ground[cite: 32]
    private bool grounded; // Check if the character is standing on solid ground[cite: 32]

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // FixedUpdate is called every fixed frame-rate interval
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Spacebar) && grounded) // When user presses space once and is grounded[cite: 38]
        {
            Jump();
        }

        if (Input.GetKey(L)) // When user presses the left movement button[cite: 30]
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Player_0 (1)>().velocity.y);
            
            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        if (Input.GetKey(R)) // When user presses the right movement button[cite: 30]
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Player_0 (1)>().velocity.y);
            
            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Player_0 (1)>().velocity.x, jumpHeight);
    }
}
