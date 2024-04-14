using UnityEngine;

public class TriggerDamage : MonoBehaviour
{ 
    [SerializeField] 
    private float damage;
   private void OnTriggerEnter(Collider other)
   {
       if (other.TryGetComponent(out IDamagable damagable))
       {
           damagable.TakeDamage(damage);
       }
   }
}
