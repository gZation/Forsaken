using UnityEngine;

public class Boss : Enemy
{

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.transform == player)
        {
            player.gameObject.GetComponent<PlayerStateManager>().ApplyDamage(5);
        }
    }

    override public void ApplyDamage(int damage)
    {
        base.ApplyDamage(damage);
        if (Health <= 0f)
        {
            Debug.Log("You win!");
            Time.timeScale = 0f;
        }
    }

}
