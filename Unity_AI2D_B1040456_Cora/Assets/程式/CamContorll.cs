using UnityEngine;

public class CamContorll : MonoBehaviour
{
    public float speed = 3;

    private Transform target;

    private void Start()
    {
        target = GameObject.Find("兔子").transform;
    }

    private void LateUpdate()
    {
        Vector3 cam = transform.position;
        Vector3 tar = target.position;
        tar.z = -10;
        transform.position = Vector3.Lerp(cam, tar, 0.3f * Time.deltaTime * speed);
    }
}
