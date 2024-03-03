using System.Collections;
using System.Collections.Generic;
using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;

public class Aborter : MonoBehaviour
{
    [SerializeField]
    private Blackboard blackboard;

    [SerializeField]
    private BehaviourNode rootNode;
    
    private void OnEnable()
    {
        blackboard.OnVariableChanged += OnVariableChangedNeedNotice;
        blackboard.OnVariableRemoved += OnVariableChangedNeedNotice;
        blackboard.OnVariableChanged += OnVariableChangedObjectDetected;
        blackboard.OnVariableRemoved += OnVariableChangedObjectDetected;
        
    }
        
    private void OnDisable()
    {
        blackboard.OnVariableChanged -= OnVariableChangedNeedNotice;
        blackboard.OnVariableRemoved -= OnVariableChangedNeedNotice;
        blackboard.OnVariableChanged -= OnVariableChangedObjectDetected;
        blackboard.OnVariableRemoved -= OnVariableChangedObjectDetected;
    }

    private void OnVariableChangedNeedNotice(string name, object value)
    {
        // if (name != BlackboardKeys.FRIEND_NEED_NOTICE) 
        //     return;
        //
        // if (value is true)
        // {
        //     rootNode.Abort();
        // }
    }
    
    private void OnVariableChangedObjectDetected(string name, object value)
    {
        if (name != BlackboardKeys.OBJECT_DETECTED) 
            return;
        Debug.Log("DETECTED");
        rootNode.Abort();
       
    }
}

