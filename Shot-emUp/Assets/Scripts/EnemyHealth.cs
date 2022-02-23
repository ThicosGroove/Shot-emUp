using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 2;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject myhealthBar;
    [SerializeField] private GameObject myGun;

    private BoxCollider2D boxCollider2D;
    private ParticleSystemHandler particle;
    private SpriteRenderer sprite;

    private float currentHealth;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        particle = GetComponent<ParticleSystemHandler>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        currentHealth = maxHealth;
    }

    private void Update()
    {
        HealthBarFiller();
    }

    private void HealthBarFiller()
    {
        float fillAmountPercentage = currentHealth / maxHealth;
        float lerpSpeed = 4f * Time.deltaTime;

        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, fillAmountPercentage, lerpSpeed);
    }

    public void TakeDemage() // o dano é sempre 1
    {
        if (currentHealth > 1)
        {
            currentHealth--;

            StartCoroutine(BlinkColorWhenHit());
        }
        else
          StartCoroutine(ShouldDie());
    }

    private IEnumerator BlinkColorWhenHit()
    {
        sprite.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        sprite.color = Color.white;
    }


    IEnumerator ShouldDie() // pra dar tempo de rodar as particular
    {
        myGun.SetActive(false);
        boxCollider2D.enabled = false;
        myhealthBar.SetActive(false);
        sprite.enabled = false;

        particle.canRunParticle = true;

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }


}
