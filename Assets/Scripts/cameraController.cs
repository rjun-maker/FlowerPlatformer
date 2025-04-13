using UnityEngine;

public class cameraController : MonoBehaviour {
   
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAheadX;
    private float lookAheadY;


    private void Update() {
       // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);
        transform.position = new Vector3(player.position.x + lookAheadX, (player.position.y/5) + lookAheadY, transform.position.z);
        lookAheadX = Mathf.Lerp(lookAheadX, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
        lookAheadY = Mathf.Lerp(lookAheadY, (aheadDistance * player.localScale.y), Time.deltaTime * cameraSpeed);
    }


    public void MoveToNewRoom(Transform _newRoom) {
        currentPosX = _newRoom.position.x;

    }



}
