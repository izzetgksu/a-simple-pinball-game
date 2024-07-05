using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float flipperStrength = 10f;
    public float flipperDamper = 1f;
    public string inputButtonName = "LeftPaddle";

    private HingeJoint hingeJoint;

    private void Awake()
    {
        hingeJoint = GetComponent<HingeJoint>();
        hingeJoint.useSpring = true;
    }

    private void Update()
    {
    
        MoveFlipper();
    }

    private void MoveFlipper()
    {
        JointSpring spring = new JointSpring
        {
            spring = flipperStrength,
            damper = flipperDamper
        };

        if (Input.GetKey(KeyCode.LeftArrow))
            spring.targetPosition = pressedPosition;
        else
            spring.targetPosition = restPosition;

        hingeJoint.spring = spring;
        hingeJoint.useLimits = true;
        hingeJoint.limits = new JointLimits
        {
            min = restPosition,
            max = pressedPosition
        };
    }
}
