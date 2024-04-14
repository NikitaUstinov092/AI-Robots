
using Plugins.Blackboard;
using UnityEngine;

public class BehaviorNode_LookAtObject : BehaviorNode_RotateToObject
{
  protected override void Run()
  {
    if (!blackboard.HasVariable(BlackboardKeys.OBJECT_DETECTED))
    {
      Return(false);
    }
    
    if (blackboard.TryGetVariable<bool>(BlackboardKeys.OBJECT_VISUAL, out var value))
    { 
      if (value) 
      { 
        Return(false);
      }
    }
    
    var character = blackboard.GetVariable<Character>(BlackboardKeys.UNIT);
    var target = blackboard.GetVariable<Transform>(BlackboardKeys.OBJECT_DETECTED);
        
    character.Turn(target);
    Return(true);
  }
}
