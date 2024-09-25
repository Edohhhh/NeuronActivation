using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public float lifeTime = 5f; // Tiempo antes de que la bala desaparezca
    public float explosionRadius = 1f; // Radio de la explosi�n para aplicar da�o

    // Da�o que hereda del personaje que dispara
    public int bulletDamage = 10;

    // Referencia al personaje
    private Character character;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        // Aplicar la fuerza en la direcci�n hacia donde disparar
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        // Rotar la bala en la direcci�n del disparo
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        // Destruir la bala despu�s de `lifeTime` segundos si no colisiona con nada
        Destroy(gameObject, lifeTime);
    }

    // M�todo para asignar el da�o desde el Character
    public void SetCharacter(Character character)
    {
        this.character = character;
        this.bulletDamage = character.currentHp; // O alg�n otro valor, si tienes un atributo de da�o espec�fico
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Buscar todos los objetos que implementen IDamageable en un radio de explosi�n
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        ApplyDamage(colliders);

        // Destruir la bala despu�s de colisionar
        Destroy(gameObject);
    }

    // M�todo para aplicar da�o a los objetos que implementan IDamageable
    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamageable damageableObject = colliders[i].GetComponent<IDamageable>();
            if (damageableObject != null)
            {
                damageableObject.TakeDamage(bulletDamage);
            }
        }
    }

    // Visualizaci�n del �rea de colisi�n en el editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
