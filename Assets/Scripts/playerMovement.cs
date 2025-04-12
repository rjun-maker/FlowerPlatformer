using UnityEngine;

public class playerMovement : MonoBehaviour {
    private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    private Animator anim;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private float wallJumpCooldown;
    private float horizontalInput;
    

    private void Awake() {

        // Grab reference for rigidbody and animator
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    } 

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal"); 

        // move left and right + speed
        
        

        // Flip player when moving left-right
        // scale is x: 0.2, y: 0.15 bc asset is very large
        if (horizontalInput > 0.01f) {
            transform.localScale = new Vector3(0.2f, 0.15f, 1);

        } else if (horizontalInput <= -0.01f) {
            transform.localScale = new Vector3(-0.2f, 0.15f, 1);
        }

        // Set animator parameters
        anim.SetBool("run", (horizontalInput != 0));   
        anim.SetBool("ground", isGrounded());


        // wall jump logic
        if (wallJumpCooldown > 0.2f) {

            // player velocity (movement left and right)
            body.linearVelocity = new Vector2((horizontalInput * speed), body.linearVelocity.y);

            if (onWall() && isGrounded()) {
                body.gravityScale = 0;
                body.linearVelocity = Vector2.zero;
            } else {
                body.gravityScale = 1;
            }

             // jump
            if (Input.GetKey(KeyCode.Space)) { 
                Jump();
            }

        } else {
            wallJumpCooldown += Time.deltaTime;
        }

    }




    private void Jump() {

        if (isGrounded()) {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
            anim.SetTrigger("jump");

        } else if (onWall() && !isGrounded()) {

            if (horizontalInput == 0) {
                body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            } else {
                body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 5, 10);
            }
            
            wallJumpCooldown = 0;
            
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision) {
    //     // if(collision.gameObject.tag == "Ground") {
    //     //     grounded = true;
    //     // }
    // }

    // determines if there is anything underneath the player
    private bool isGrounded() { 
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    // detects if player is on wall
    private bool onWall() { 
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }



}
