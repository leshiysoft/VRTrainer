using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрип позволяет объекту перемещаться от нажитий WASD и 
// поворачиваться от движения мыши с зажатой правой кнопкой

public class Flying : MonoBehaviour
{

    public float MovingSpeed = 3f;
    public float MouseSensitivity = 1f;

    Vector3 lastMousePosition;

    void Start ()
    {
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        Vector3 stepDirection = MovingDirection();
        Vector3 step = transform.forward * stepDirection.z + transform.right * stepDirection.x;
        transform.Translate(step * MovingSpeed * Time.deltaTime, Space.World);

        if (Input.GetMouseButton(1))
        {
            Vector3 mouseDeltaPosition = Input.mousePosition - lastMousePosition;

            Vector3 deltaRotation = new Vector3(-mouseDeltaPosition.y* MouseSensitivity, mouseDeltaPosition.x* MouseSensitivity, 0);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + deltaRotation);
        }
        lastMousePosition = Input.mousePosition;
    }

    Vector3 MovingDirection()
    {
        Vector3 result = new Vector3(0,0,0);

        if (Input.GetKey(KeyCode.W))
        {
            result += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            result += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            result += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            result += Vector3.right;
        }

        return result;
    }
}

