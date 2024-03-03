using Plugins.Blackboard;
using Sirenix.OdinInspector;
using UnityEngine;

public class TriggerSensor : MonoBehaviour
{
   [SerializeField]
   private Blackboard[] _blackboards;
   
   [Button]
   public void HandleTrigger()
   {
      foreach (var blackBoard in _blackboards)
      {
         blackBoard.SetVariable(BlackboardKeys.OBJECT_DETECTED, transform);
      }
   }
}
