using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothness = 10;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, smoothness * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, smoothness * 0.5f * Time.deltaTime);
    }
}
