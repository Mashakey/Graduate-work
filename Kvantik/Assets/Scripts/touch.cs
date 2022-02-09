using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{
    const float pinchTurnRatio = Mathf.PI / 2;
    const float minTurnAngle = 0;
    private float rotationRate = 1.5f;
    /// <summary>
    ///   The delta of the angle between two touch points
    /// </summary>
    static public float turnAngleDelta;
    /// <summary>
    ///   The angle between two touch points
    /// </summary>
    static public float turnAngle;

    /// 
    static public Touch LastTouch;
    static public void Calculate()
    {
        turnAngle = turnAngleDelta = 0;

        if (Input.touchCount == 1)
        {

            Touch touch1 = Input.touches[0];

            turnAngle = Angle(touch1.position, LastTouch.position);
            float prevTurn = Angle(touch1.position + touch1.deltaPosition,
                                   LastTouch.deltaPosition + LastTouch.position);
            turnAngleDelta = Mathf.DeltaAngle(prevTurn, turnAngle);

            if (Mathf.Abs(turnAngleDelta) > minTurnAngle)
            {
                turnAngleDelta *= pinchTurnRatio;
            }
            else
            {
                turnAngle = turnAngleDelta = 0;
            }
            LastTouch = Input.touches[0];
        }

        else if (Input.touchCount == 2)
        {
            Touch touch1 = Input.touches[0];
            Touch touch2 = Input.touches[1];

            if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {

                turnAngle = Angle(touch1.position, touch2.position);
                float prevTurn = Angle(touch1.position + touch1.deltaPosition,
                                       touch2.position + touch2.deltaPosition);
                turnAngleDelta = Mathf.DeltaAngle(prevTurn, turnAngle);

                if (Mathf.Abs(turnAngleDelta) > minTurnAngle)
                {
                    turnAngleDelta *= pinchTurnRatio;                    
                }
                else
                {
                    turnAngle = turnAngleDelta = 0;
                }
            }
        }
    }


    static private float Angle(Vector2 pos1, Vector2 pos2)
    {
        Vector2 from = pos2 - pos1;
        Vector2 to = new Vector2(1, 0);

        float result = Vector2.Angle(from, to);
        Vector3 cross = Vector3.Cross(from, to);

        if (cross.z > 0)
        {
            result = 360f - result;
        }

        return result;
    }
}

