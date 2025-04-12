using UnityEngine;

public class playerMovement : MonoBehaviour {
    private Rigidbody2D body;
    [SerializeField] private float speed;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();

    } 

    private void Update() {
        float horizontalInput = Input.GetAxis("Horizontal"); 
        body.linearVelocity = new Vector2((horizontalInput * speed), body.linearVelocity.y);
        
        // Flip player when moving left-right
        // scale is x: 0.2, y: 0.15 bc asset is very large
        if (horizontalInput > 0.01f) {
            transform.localScale = new Vector3(0.2f, 0.15f, 1);
        }
        else if (horizontalInput <= -0.01f) {
            transform.localScale = new Vector3(-0.2f, 0.15f, 1);
        }


        if(Input.GetKey(KeyCode.Space)) { 
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed/2);
        }

    }
}
