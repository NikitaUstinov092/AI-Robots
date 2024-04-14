using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
   [SerializeField]
   private float health;

   void IDamagable.TakeDamage(float damage)
   {
      if (health > 0)
      {
         health -= damage;
      }

      if (health < 0)
      {
         health = 0;
      }
   }
}


public interface IDamagable
{
   void TakeDamage(float damage);
}
