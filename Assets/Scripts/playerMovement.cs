using UnityEngine;

public class playerMovement : MonoBehaviour {
    private Rigidbody2D body;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();

    } 

    private void Update() {
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal"), body.linearVelocity.y);
         

    }
}
