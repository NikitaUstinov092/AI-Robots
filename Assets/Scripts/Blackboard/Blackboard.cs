using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Plugins.Blackboard
{
    public sealed class Blackboard : MonoBehaviour
    {
        public event Action<string, object> OnVariableChanged;
        public event Action<string, object> OnVariableRemoved;

        [ShowInInspector, ReadOnly]
        private readonly Dictionary<string, object> variables = new();

        public T GetVariable<T>(string key)
        {
            return (T) variables[key];
        }

        public bool TryGetVariable<T>(string key, out T value)
        {
            if (variables.TryGetValue(key, out var result))
            {
                value = (T) result;
                return true;
            }
            
            value = default;
            return false;
        }
        
        public bool HasVariable(string key)
        {
            return variables.ContainsKey(key);
        }
        
        [Title("Methods")]
        [Button]
        public void SetVariable(string key, object value)
        {
            variables[key] = value;
            OnVariableChanged?.Invoke(key, value);
        }
        
        [Button]
        public void RemoveVariable(string key)
        {
            if (variables.TryGetValue(key, out var value))
            {
                variables.Remove(key);
                OnVariableRemoved?.Invoke(key, value);
            }
        }
    }
}