using UnityEngine;

public class playerMovement : MonoBehaviour {
    private Rigidbody2D body;
    [SerializeField] private float speed;
    private Animator anim;
    private bool grounded;

    private void Awake() {

        // Grab reference for rigidbody and animator
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    } 

    private void Update() {
        float horizontalInput = Input.GetAxis("Horizontal"); 

        // move left and right + speed
        body.linearVelocity = new Vector2((horizontalInput * speed), body.linearVelocity.y);
        
        // Flip player when moving left-right
        // scale is x: 0.2, y: 0.15 bc asset is very large
        if (horizontalInput > 0.01f) {
            transform.localScale = new Vector3(0.2f, 0.15f, 1);
        }
        else if (horizontalInput <= -0.01f) {
            transform.localScale = new Vector3(-0.2f, 0.15f, 1);
        }

        // jump
        if(Input.GetKey(KeyCode.Space) && grounded) { 
            Jump();
        }

        // Set animator parameters
        anim.SetBool("run", (horizontalInput != 0));   
        anim.SetBool("ground", grounded);

    }

    private void Jump() {
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed/2);
        grounded = false;
        anim.SetTrigger("jump");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground") {
            grounded = true;
        }
    }




}
