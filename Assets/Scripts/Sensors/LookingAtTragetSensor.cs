using System;
using System.Collections;
using System.Collections.Generic;
using Plugins.Blackboard;
using UnityEngine;

public class LookingAtTragetSensor : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    
    [SerializeField]
    private Transform objectToCheck;
    
    [SerializeField]
    private float angleThreshold = 30f;

    [SerializeField] 
    private Blackboard blackboard;

    private void Update()
    {
        if(!blackboard.TryGetVariable<Transform>(BlackboardKeys.OBJECT_DETECTED, out _))
            return;
        
        if(IsPlayerLookingAtObject())
            blackboard.SetVariable(BlackboardKeys.OBJECT_VISUAL, true);
    }


    private bool IsPlayerLookingAtObject()
    {
        var objectDirection = objectToCheck.position - playerTransform.position;
        
        objectDirection.Normalize();
        
        var playerForward = playerTransform.forward;
        
        var angle = Vector3.Angle(playerForward, objectDirection);

        // Проверяем, если угол меньше порогового значения
        return angle < angleThreshold;
    }
}
