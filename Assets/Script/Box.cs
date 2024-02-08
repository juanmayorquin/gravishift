using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Vector2 startPos;
    private Transform dragging = null;
    private Vector3 offset;

    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 
                                                 float.PositiveInfinity, LayerMask.GetMask("Movable"));
            if (hit)
            {
                dragging = hit.transform;
                offset = dragging.position - UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        } else if (Input.GetMouseButtonUp(0)) {
            dragging = null;
        }

        if (dragging != null)
        {
            dragging.position = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            rb.velocity = Vector2.zero;
        }
    }

    public void Respawn()
    {
        transform.position = startPos;
        rb.velocity = Vector2.zero;
    }
}
