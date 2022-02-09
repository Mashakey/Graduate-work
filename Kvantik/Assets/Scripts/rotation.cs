using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
 
    private float initialDistance;
    private Vector3 initialScale;
    public float rotationRate = 1.5f;

    private void Update()
    {

        if (Input.touchCount == 2)
        {

            Rotation();
            Scale();
        }
    }
  

    private void Scale()
    {
        var touchZero = Input.GetTouch(0);
        var touchOne = Input.GetTouch(1);
        

        if (touchZero.phase == TouchPhase.Ended || touchZero.phase == TouchPhase.Canceled || touchOne.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Canceled)
        {
            return;
        }

        if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
        {
            initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
            initialScale = gameObject.transform.localScale;
        }
        else
        {
            var currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

            //если случайно
            if (Mathf.Approximately(initialDistance, 0))
            {
                return;
            }

            var factor = currentDistance / initialDistance;
            gameObject.transform.localScale = initialScale * factor;
        }
    }

    private void Rotation()
    {
        var touchRotateZero = Input.GetTouch(0);
        var touchRotateOne = Input.GetTouch(1);

        if (touchRotateZero.phase == TouchPhase.Ended || touchRotateZero.phase == TouchPhase.Canceled || touchRotateOne.phase == TouchPhase.Ended || touchRotateOne.phase == TouchPhase.Canceled)
        {
            return;
        }

        if (touchRotateZero.phase == TouchPhase.Moved || touchRotateOne.phase == TouchPhase.Moved)
        {
            gameObject.transform.Rotate(0, touchRotateZero.deltaPosition.y * rotationRate, 0, Space.World);
        }
    }
}
