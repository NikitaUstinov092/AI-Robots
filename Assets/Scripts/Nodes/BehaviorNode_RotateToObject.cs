using System.Collections;
using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;


public class BehaviorNode_RotateToObject : BehaviourNode
{
    [SerializeField]
    private Blackboard blackboard;
    
    private Coroutine coroutine;
    protected override void Run()
    {
        if (!blackboard.HasVariable(BlackboardKeys.OBJECT_DETECTED))
        {
            Return(false);
            return;
        }

        var robot = blackboard.GetVariable<Character>(BlackboardKeys.ROBOT);
        var target = blackboard.GetVariable<Transform>(BlackboardKeys.OBJECT_DETECTED);
        
        robot.Turn(target);
        Return(true);
    }
    
    protected override void OnDispose()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    private IEnumerator Rotate(Character character, Transform transform)
    {
        character.Turn(transform);
        yield return new WaitForSeconds(1);
        Return(true);
    }
}


