using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 10;
    public int damage = 10;
    private bool killed = false;

    public bool Killed
    {
        get { return killed; }
    }

    public void TakeDamage(int damageAmount)
    {
        if (!killed)
        {
            enemyHealth -= damageAmount;
            if (enemyHealth <= 0)
            {
                killed = true;
                OnKill();
            }
        }
    }

    protected virtual void OnKill()
    {
        
        gameObject.SetActive(false);
    }
}