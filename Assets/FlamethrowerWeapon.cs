using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlamethrowerWeapon : MonoBehaviour
{
    float timeToAttack = 4f;
    float timer;

    [SerializeField] GameObject leftFlamethrower;
    [SerializeField] GameObject rightFlamethrower;

    PlayerMove playerMove;

    [SerializeField] int FlameDamage = 50;

    [SerializeField] Vector2 flameAttackSize = new Vector2(4f, 2f);

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("Flame!");
        timer = timeToAttack;

        if (playerMove.lastHorizontalVector > 0)
        {

            rightFlamethrower.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightFlamethrower.transform.position, flameAttackSize, 0f);
            ApplyDamage(colliders);
        }
        else
        {
            leftFlamethrower.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftFlamethrower.transform.position, flameAttackSize, 0f);
            ApplyDamage(colliders);

        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamageable e = colliders[i].GetComponent<IDamageable>();
            if (e != null)
            {
                e.TakeDamage(FlameDamage);
            }
        }
    }
}
