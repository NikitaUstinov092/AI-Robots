using System.Collections;
using Plugins.Blackboard;
using UnityEngine;

public class NoticeSensor : MonoBehaviour
{
   [SerializeField] 
   private Blackboard _blackboardCurrentUnit;
   
   [SerializeField] 
   private Blackboard _blackboardFriendUnit;

   [SerializeField] 
   private Transform box;

   private bool isRunning = false;
   private void OnEnable()
   {
      _blackboardCurrentUnit.OnVariableChanged += CheckValue;
   }
   
   private void OnDisable()
   {
      _blackboardCurrentUnit.OnVariableChanged -= CheckValue;
   }

   private void CheckValue(string key, object type)
   {
      if (!_blackboardCurrentUnit.HasVariable(BlackboardKeys.OBJECT_DETECTED))
          return;
     
      if (!_blackboardFriendUnit.HasVariable(BlackboardKeys.OBJECT_DETECTED) &&
          !_blackboardFriendUnit.HasVariable(BlackboardKeys.TARGET) &&
          !_blackboardCurrentUnit.HasVariable(BlackboardKeys.FRIEND_NEED_NOTICE))
      {
         if (!isRunning)
         {
            isRunning = true;
            StartCoroutine(SetVariableNotice(BlackboardKeys.FRIEND_NEED_NOTICE, true));
         }
        
      }
      else if(_blackboardFriendUnit.HasVariable(BlackboardKeys.TARGET))
      {
         if (!isRunning)
         {
            isRunning = true;
            StartCoroutine(SetVariableNotice(BlackboardKeys.TARGET, box));
         }
      }
      
   }

   private IEnumerator SetVariableNotice(string variableName, object value)
   {
      yield return new WaitForSeconds(3);
      _blackboardCurrentUnit.SetVariable(variableName, value);
      isRunning = false;
   }
}
   

  

