using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float smoothTime = 0.33f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 offset = new Vector3(2, 2, -10f);

    [SerializeField] private Transform target;

    private void Start()
    {
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
