using Plugins.Blackboard;
using Sirenix.OdinInspector;
using UnityEngine;

public class PatrolPointsSensor : MonoBehaviour
{
    [SerializeField] 
    private Transform _character;
    
    [SerializeField] 
    private Blackboard _blackboard;
    
    [SerializeField] 
    private Transform[] _points;
    
    [ShowInInspector, ReadOnly]
    private Transform currentPoint;
    private void Start()
    {
        // Находим рандомную точку и делаем ее текущей точкой
        currentPoint = _points[Random.Range(0, _points.Length)];
        
        _blackboard.SetVariable(BlackboardKeys.POINT_PATROL, currentPoint);
    }

    private void Update()
    {
        // Проверяем расстояние между персонажем и текущей точкой
        float distance = Vector3.Distance(_character.position, currentPoint.position);
        
        if (distance < 2f)
        {
            // Выбираем рандомную точку, которая не является текущей точкой
            Transform newPoint = currentPoint;
            while (newPoint == currentPoint)
            {
                newPoint = _points[Random.Range(0, _points.Length)];
                _blackboard.SetVariable(BlackboardKeys.POINT_PATROL, newPoint);
            }

            // Обновляем текущую точку
            currentPoint = newPoint;
        }
    }
}

