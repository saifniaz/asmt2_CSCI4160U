using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    //public float speed = 0.25f;

    void LateUpdate()
    {
        transform.position = target.position;

    }
}
