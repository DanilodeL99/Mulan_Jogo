using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ParrySystem : MonoBehaviour
{
    [Header("Configurações do Parry")]
    [SerializeField] private float parryWindowDuration = 0.2f; 
    [SerializeField] private float parryCooldown = 0.5f;      

    private bool isParrying = false;
    private bool canParry = true;

    [Header("Congelamento de tela")]
    [SerializeField] private float hitStopDuration = 0.15f;   

    public bool IsParrying => isParrying;

    void Update()
    {
        
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame && canParry && !isParrying)
        {
            StartCoroutine(TriggerParryWindow());
        }
    }

    IEnumerator TriggerParryWindow()
    {
        isParrying = true;
        canParry = false;

        Debug.Log("Espaço");

        yield return new WaitForSeconds(parryWindowDuration);

        isParrying = false;

       
        yield return new WaitForSeconds(parryCooldown);
        canParry = true;
    }


    public void ExecuteSuccessfulParry(Transform enemyTransform)
    {
        Debug.Log("PARRY");

      
        StartCoroutine(DoHitStop(hitStopDuration));
    }

    IEnumerator DoHitStop(float duration)
    {
        float originalTimeScale = Time.timeScale;
        Time.timeScale = 0.0f; 

        yield return new WaitForSecondsRealtime(duration);

        Time.timeScale = originalTimeScale; 
    }
}