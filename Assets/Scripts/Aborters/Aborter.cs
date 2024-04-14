
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
        blackboard.OnVariableChanged += OnVariableChangedObjectDetected;
        blackboard.OnVariableRemoved += OnVariableChangedObjectDetected;
        
    }
        
    private void OnDisable()
    {
        blackboard.OnVariableChanged -= OnVariableChangedObjectDetected;
        blackboard.OnVariableRemoved -= OnVariableChangedObjectDetected;
    }
    
    private void OnVariableChangedObjectDetected(string name, object value)
    {
        if (name != BlackboardKeys.OBJECT_DETECTED) 
            return;
        Debug.Log("DETECTED");
        rootNode.Abort();
       
    }
}

