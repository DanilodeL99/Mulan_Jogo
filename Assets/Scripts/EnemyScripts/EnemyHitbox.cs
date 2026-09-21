using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Player"))
        {
            ParrySystem playerParry = other.GetComponent<ParrySystem>();

            if (playerParry != null)
            {
                if (playerParry.IsParrying)
                {
                    
                    playerParry.ExecuteSuccessfulParry(transform.root);
                    Debug.Log("<color=green>PARRY</color>");

                   
                    gameObject.SetActive(false);
                }
                else
                {
                    
                    Debug.Log("<color=red>Damage Taken</color>");
                }
            }
        }
    }
}