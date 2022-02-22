using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cuida do spawn do jogador
public class PlayerSpawnManager : MonoBehaviour
{
    private GameObject spaceShip;

    private EnemyMovement[] allEnemy;
    private BulletHandler[] allBullets;
    private ParticleSystemHandler playerParticle;

    public bool isDead = false;
    private Vector2 spawnPosSpaceShip;

    private void Awake()
    {
        spaceShip = GameObject.FindGameObjectWithTag("Player"); //esse aqui encontra mais rápido

        playerParticle = GameObject.Find("SpaceShip").GetComponent<ParticleSystemHandler>();
    }

    void Start()
    {
        spawnPosSpaceShip = spaceShip.transform.position;
    }

    void Update()
    {
        if (isDead)
        {
            StartCoroutine(SpaceShipRespawn());

            DestroyAllObjects();
        }

        allEnemy = Object.FindObjectsOfType(typeof(EnemyMovement)) as EnemyMovement[];
        allBullets = Object.FindObjectsOfType(typeof(BulletHandler)) as BulletHandler[];
    }

    private IEnumerator SpaceShipRespawn()  //nao reinicia imediatamente pra dar um respiro
    {
        spaceShip.GetComponentInChildren<SpriteRenderer>().enabled = false;
        playerParticle.canRunParticle = true;

        yield return new WaitForSeconds(1f);

        spaceShip.transform.position = spawnPosSpaceShip;
        Physics.SyncTransforms();

        spaceShip.GetComponentInChildren<SpriteRenderer>().enabled = true;

        isDead = false;
    }

    // Destrói todos os inimigos e tiros da cena pra reiniciar o jogo sem chamar
    // o Scene manager.LoadScene.
    // Poderia fazer isso, mas ai o me parece que o jogo não seria "infinito" ?
    private void DestroyAllObjects() 
    {
        foreach (var enemy in allEnemy)
        {
            if (enemy == null) { break; }

            GameObject newEnemy = enemy.gameObject;

            Destroy(newEnemy);
        }

        foreach (var bullet in allBullets)
        {
            if (bullet == null) { break; }

            GameObject newBullet = bullet.gameObject;

            Destroy(newBullet);
        }
    }

}
