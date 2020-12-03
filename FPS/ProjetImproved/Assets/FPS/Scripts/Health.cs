using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Tooltip("Maximum amount of health")]
    public float maxHealth = 100f;
    [Tooltip("Health ratio at which the critical health vignette starts appearing")]
    public float criticalHealthRatio = 0.3f;

    public UnityAction<float, GameObject> onDamaged;
    public UnityAction<float> onHealed;
    public UnityAction onDie;
    [SerializeField] private LevelHandler levelHandler;
    [SerializeField] private HeartManager healthManager;


    public float currentHealth { get; set; }
    public bool invincible { get; set; }
    public bool canPickup() => currentHealth < maxHealth;

    public float getRatio() => currentHealth / maxHealth;
    public bool isCritical() => getRatio() <= criticalHealthRatio;

    bool m_IsDead;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Heal(float healAmount)
    {
        float healthBefore = currentHealth;
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        // call OnHeal action
        float trueHealAmount = currentHealth - healthBefore;
        if (trueHealAmount > 0f && onHealed != null)
        {
            onHealed.Invoke(trueHealAmount);
        }
    }

    public void TakeDamage(float damage, GameObject damageSource)
    {
        if (invincible)
            return;

        float healthBefore = currentHealth;
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        // call OnDamage action
        float trueDamageAmount = healthBefore - currentHealth;
        if (trueDamageAmount > 0f && onDamaged != null)
        {
            onDamaged.Invoke(trueDamageAmount, damageSource);
        }

        HandleDeath();
    }

    public void Kill()
    {
        currentHealth = 0f;

        // call OnDamage action
        if (onDamaged != null)
        {
            onDamaged.Invoke(maxHealth, null);
        }

        if(this.gameObject.tag == "Enemy")
        {
            this.gameObject.SetActive(false);
        }
        HandleDeath();
    }

    private void HandleDeath()
    {
        if (m_IsDead)
            return;

        // call OnDie action
        if (currentHealth <= 0f)
        {
            if (onDie != null)
            {
                if (this.transform.gameObject.tag == "Enemy")
                {
                    m_IsDead = true;
                    onDie.Invoke();
                    PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 20);
                }
                else if (transform.gameObject.tag == "Boss")
                {
                    m_IsDead = true;
                    onDie.Invoke();
                    PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 100);                   
                }
                else
                {
                    levelHandler.Respawn();
                    healthManager.LoseHeart(1);
                    currentHealth = maxHealth;
                }

            }
            
        }
    }

}
