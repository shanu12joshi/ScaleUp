
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    // public float CameraFollowSpeed = 0.125f;

    Vector3 offset;

    void Start(){
        offset = transform.position-player.position;
    }

    private void Update()
    {
        Vector3 desPosition = player.position + offset;

        // Vector3 newPosition = Vector3.Lerp(transform.position,desPosition,CameraFollowSpeed * Time.deltaTime);

        desPosition.x=0;
        // transform.Rotate(0,0,0,0);
        transform.position = desPosition;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
        transform.LookAt(player);
    }
}
