using Plugins.Blackboard;
using UnityEngine;

public class CloseTargetSensor : MonoBehaviour
{
    [SerializeField] 
    private Blackboard blackboard;
    
    
    private void Update()
    {
        if (!blackboard.TryGetVariable<Transform>(BlackboardKeys.OBJECT_DETECTED, out var target))
        {
            blackboard.RemoveVariable(BlackboardKeys.CLOSE_TO_OBJECT);
            return;
        }
        
        if (!blackboard.TryGetVariable<Character>(BlackboardKeys.UNIT, out var unit))
        {
            blackboard.RemoveVariable(BlackboardKeys.CLOSE_TO_OBJECT);
            return;
        }

        var requiredDistance = blackboard.GetVariable<int>(BlackboardKeys.REQUIRED_DISTANCE);

        if (Vector3.Distance(target.position, unit.transform.position) < requiredDistance)
        {
            blackboard.SetVariable(BlackboardKeys.CLOSE_TO_OBJECT, true);
        }
        else
        {
            blackboard.SetVariable(BlackboardKeys.CLOSE_TO_OBJECT, false);
        }
    }
    
}
