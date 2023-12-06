using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRaycast : MonoBehaviour
{
    public void HitboxRect(Vector2 origin, float distance, float width, float zAngle, int damage = 1) {
        CheckHit(Physics2D.BoxCast(origin, new Vector2(width, distance), zAngle, new Vector2(0,-1), Mathf.Infinity, 6), damage);
    }
    public void HitboxRect(Vector2 origin, Vector2 dimensions, float zAngle, int damage = 1) {
        CheckHit(Physics2D.BoxCast(origin, dimensions, zAngle, new Vector2(0,-1), Mathf.Infinity, 6), damage);
    }


    public void HitboxCircle(CircleCollider2D hitbox, int damage = 1) {
        CheckHit(Physics2D.CircleCast(hitbox.bounds.center, hitbox.radius, transform.up, Mathf.Infinity, 6), damage);
    }
    public void HitboxCircle(Vector2 center, float radius, int damage = 1) {
        CheckHit(Physics2D.CircleCast(center, radius, Vector2.zero, Mathf.Infinity, 6), damage);
    }


    private bool CheckHit(RaycastHit2D hit, int damagePoints) {
        if(hit.collider.GetComponent<PlayerLose>() != null) {
            hit.collider.GetComponent<PlayerLose>().ReceiveDamage(damagePoints); //only player hitbox is on mask layer 6
            return true;
        }
        return false;
    }
}
