using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanning : MonoBehaviour
{
    public float mouseSensitivity;
    private Vector3 lastPosition;
    public bool active = true;
    public float maxY;
    public float minY;
    public float maxX;
    public float minX;

    void Update()
    {
        if (active)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastPosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                float lateX = transform.position.x;
                float lateY = transform.position.x;
                Vector3 delta = Input.mousePosition - lastPosition;
                transform.Translate(delta.x * -1 * mouseSensitivity, delta.y * -1 * mouseSensitivity, 0);
                if (transform.position.x > maxX)
                {
                    transform.Translate(maxX - transform.position.x, 0, 0);
                }
                else if (transform.position.x < minX)
                {
                    transform.Translate(minX - transform.position.x , 0, 0);
                }
                if (transform.position.y > maxY)
                {
                    transform.Translate(0, maxY - transform.position.y, 0);
                }
                else if (transform.position.y < minY)
                {
                    transform.Translate(0, minY - transform.position.y, 0);
                }
                lastPosition = Input.mousePosition;
            }
        }
        else
        {
            lastPosition = Input.mousePosition;
        }
    }
}
