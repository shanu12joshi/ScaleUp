using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    float deltaZ;
    public Transform player;
    // public float CameraFollowSpeed = 0.125f;

    Vector3 offset;
    
    void Start(){

        deltaZ = transform.position.z - player.position.z;

        // offset = transform.position-player.position;
    }

    private void Update()
    {

        transform.position = new Vector3(transform.position.x,transform.position.y, player.position.z + deltaZ);
        // Vector3 desPosition = player.position + offset;

        // // Vector3 newPosition = Vector3.Lerp(transform.position,desPosition,CameraFollowSpeed * Time.deltaTime);

        // desPosition.x=0;
        // // transform.Rotate(0,0,0,0);
        // transform.position = desPosition;
        // GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
        // transform.LookAt(player);
    }
}
