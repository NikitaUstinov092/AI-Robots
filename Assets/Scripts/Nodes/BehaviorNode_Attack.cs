using Plugins.BehaviourTree;
using Plugins.Blackboard;
using UnityEngine;

public class BehaviorNode_Attack : BehaviourNode
{
    [SerializeField] 
    private Blackboard blackboard;
    protected override void Run()
    {
       blackboard.TryGetVariable<bool>(BlackboardKeys.CLOSE_TO_OBJECT, out var value);

       if (!value)
       {
           Return(false);
       }
       var character = blackboard.GetVariable<Character>(BlackboardKeys.UNIT);
       character.Attack();
       Return(true);
    }
}
