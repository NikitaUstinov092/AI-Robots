using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;

public class BehaviourNode_Object_Detected : BehaviourNode
{
    [SerializeField]
    private Blackboard blackboard;
    
    protected override void Run()
    {
        blackboard.TryGetVariable(BlackboardKeys.OBJECT_DETECTED, out Transform isDetected);
        Return(!isDetected);
    }
}
