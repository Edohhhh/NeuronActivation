using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] Transform targetDestination;
    GameObject targetGameobject;
    Character targetCharacter;
    [SerializeField] float speed;

    public GameObject experiencePrefab;
    public int experienceAmount;

    private Rigidbody2D rgbd2d;

    [SerializeField] public int hp = 999;
    [SerializeField] int damage = 1;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        if (targetDestination != null)
        {
            targetGameobject = targetDestination.gameObject;
        }
    }

    private void FixedUpdate()
    {
        if (targetDestination != null)
        {
            Vector3 direction = (targetDestination.position - transform.position).normalized;
            rgbd2d.velocity = direction * speed;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameobject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (targetCharacter == null)
        {
            targetCharacter = targetGameobject.GetComponent<Character>();
        }

        if (targetCharacter != null)
        {
            targetCharacter.TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log($"Enemy took damage: {damage}.");

        if (hp <= 0)
        {
            Debug.Log("Enemy died.");
            Destroy(gameObject);
            DropExperience();
        }
    }


    // Método para asignar el destino del enemigo
    public void SetTarget(Transform target)
    {
        targetDestination = target;
        targetGameobject = target.gameObject;
    }

    void DropExperience()
    {
        Instantiate(experiencePrefab, transform.position, Quaternion.identity);
    }
}