using UnityEngine;

public class playerMovement : MonoBehaviour {
    private Rigidbody2D body;
    [SerializeField] private float speed;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();

    } 

    private void Update() {
        body.linearVelocity = new Vector2((Input.GetAxis("Horizontal") * speed), body.linearVelocity.y);
         

    }
}
