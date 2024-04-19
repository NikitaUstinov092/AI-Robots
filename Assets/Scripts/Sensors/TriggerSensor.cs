using Plugins.Blackboard;
using Sirenix.OdinInspector;
using UnityEngine;

public class TriggerSensor : MonoBehaviour
{
   [SerializeField]
   private Blackboard blackboard;
   
   private void OnTriggerEnter(Collider other)
   { 
      HandleTrigger(other.transform);
   }
   
   private void OnTriggerExit(Collider other)
   {
      ResetTrigger();
   }
   
   [Button]
   public void HandleTrigger(Transform target)
   {
      blackboard.SetVariable(BlackboardKeys.OBJECT_DETECTED, target);
   }
   
   [Button]
   public void ResetTrigger()
   {
      blackboard.RemoveVariable(BlackboardKeys.OBJECT_DETECTED);
   }
}
