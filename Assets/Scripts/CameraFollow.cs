
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float CameraFollowSpeed = 0.125f;

    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desPosition = player.position + offset;

        Vector3 newPosition = Vector3.Lerp(transform.position,desPosition,CameraFollowSpeed * Time.deltaTime);

        transform.position = newPosition;
        transform.LookAt(player);
    }
}
