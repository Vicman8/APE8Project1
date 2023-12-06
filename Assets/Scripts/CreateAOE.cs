using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAOE : MonoBehaviour
{
    [SerializeField] int operation = 0;
    [SerializeField] int damageNum = 1;
    private DamageRaycast caster;

    public BoxCollider2D hitboxSquare;
    public CircleCollider2D hitboxCircle;

    private void Start() {
        caster = GetComponent<DamageRaycast>();
    }

    private void Update()
    {
        switch(operation) {
            case 1:
                caster.HitboxRect(transform.position, transform.localScale.x, transform.localScale.y, transform.eulerAngles.z, damageNum);
                break;
            case 2:
                caster.HitboxCircle(hitboxCircle, damageNum);
                break;
        }
    }
}
