using System.Collections;
using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;


public class BehaviorNode_RotateToObject : BehaviourNode
{
    [SerializeField]
    protected Blackboard blackboard;
    
    protected override void Run()
    {
        if (!blackboard.HasVariable(BlackboardKeys.OBJECT_DETECTED))
        {
            Return(false);
            return;
        }

        var robot = blackboard.GetVariable<Character>(BlackboardKeys.UNIT);
        var target = blackboard.GetVariable<Transform>(BlackboardKeys.OBJECT_DETECTED);
        
        robot.Turn(target);
        Return(true);
    }
}


