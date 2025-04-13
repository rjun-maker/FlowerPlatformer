using UnityEngine;

public class cameraController : MonoBehaviour {
   
   [SerializeField] private float speed;
   private float currentPosX;
   private Vector3 velocity = Vector3.zero;


    private void update() {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed * Time.deltaTime);
    }


    private void moveToNewRoom(Transform _newRoom) {
        currentPosX = _newRoom.position.x;

    }



}
