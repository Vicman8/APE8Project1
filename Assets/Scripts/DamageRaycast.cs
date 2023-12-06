using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRaycast : MonoBehaviour
{
    private LayerMask mask;
    private void Start() {
        mask = LayerMask.GetMask("PlayerHitbox");
    }

    public void HitboxRect(Vector2 origin, float distance, float width, float zAngle, int damage = 1) {
        CheckHit(Physics2D.OverlapBox(origin, new Vector2(width, distance), zAngle, mask), damage);
    }
    public void HitboxRect(Vector2 origin, Vector2 dimensions, float zAngle, int damage = 1) {
        CheckHit(Physics2D.OverlapBox(origin, dimensions, zAngle, mask), damage);
    }


    public void HitboxCircle(CircleCollider2D hitbox, int damage = 1) {
        CheckHit(Physics2D.CircleCast(hitbox.bounds.center, hitbox.radius, transform.up, Mathf.Infinity, mask), damage);
    }
    public void HitboxCircle(Vector2 center, float radius, int damage = 1) {
        CheckHit(Physics2D.CircleCast(center, radius, Vector2.zero, Mathf.Infinity, mask), damage);
    }


    private bool CheckHit(Collider2D hit, int damagePoints) {
        if(hit.GetComponent<PlayerLose>() != null) {
            hit.GetComponent<PlayerLose>().ReceiveDamage(damagePoints); //only player hitbox is on mask layer 6
            return true;
        }
        return false;
    }
    private bool CheckHit(RaycastHit2D hit, int damagePoints) {
        if(hit.collider.GetComponent<PlayerLose>() != null) {
            hit.collider.GetComponent<PlayerLose>().ReceiveDamage(damagePoints); //only player hitbox is on mask layer 6
            return true;
        }
        return false;
    }
}
