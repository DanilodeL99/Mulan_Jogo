using UnityEngine;

public class SimpleEnemyAttack : MonoBehaviour
{
    [Header("Configurações do Inimigo")]
    [SerializeField] private Transform player;
    [SerializeField] private float attackRange = 3f;  
    [SerializeField] private float attackCooldown = 2f; 

    private float attackTimer;
    private bool isAttacking = false;

    [Header("Hitbox de Ataque")]
    [SerializeField] private GameObject attackHitbox; 

    void Start()
    {
        attackTimer = attackCooldown;

       
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (attackHitbox != null)
        {
            attackHitbox.SetActive(false); 
        }
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        
        if (distanceToPlayer <= attackRange)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0f && !isAttacking)
            {
                StartCoroutine(PerformAttack());
                attackTimer = attackCooldown;
            }
        }
    }

    System.Collections.IEnumerator PerformAttack()
    {
        isAttacking = true;
        Debug.Log("Preparando Ataque");

       
        yield return new WaitForSeconds(0.4f);

        if (attackHitbox != null) attackHitbox.SetActive(true);
        Debug.Log("Ataque vindo");

        yield return new WaitForSeconds(0.2f);

        if (attackHitbox != null) attackHitbox.SetActive(false);

        isAttacking = false;
    }
}