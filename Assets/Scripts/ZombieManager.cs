using UnityEngine;
using System.Collections;

public class ZombieManager : MonoBehaviour {

    public float enemySpeed;
    public float damping;
    public GameObject survivor;
    public SurvivorManager survivorManager;
    public float playerHealth;
    public float damage;
    public bool isPlayerDead;

    public float coolDownTimer;

    private Transform myTransform;
    private float targetDistance;

    Rigidbody r;
    Animation a;

    void Start()
    {
        survivor = GameObject.FindGameObjectWithTag("player");
        survivorManager = survivor.GetComponent<SurvivorManager>();
        playerHealth = survivorManager.PlayerHealth;
        isPlayerDead = survivorManager.IsPlayerDead;
        coolDownTimer = 0;
        damage = -10;

        a = GetComponent<Animation>();
        r = GetComponent<Rigidbody>();
        myTransform = GetComponent<Transform>();

        a.wrapMode = WrapMode.Loop;
    }

    void FixedUpdate()
    {
        targetDistance = Vector3.Distance(survivor.transform.position, transform.position);
        if(targetDistance < 200f && targetDistance > 1f)
        {
            lookAtPlayer();
            walkTowardPlayer();

        } else if (playerHealth > 0)
        {
            attack();
        }

        if (coolDownTimer > 0)
        {
            coolDownTimer = coolDownTimer * Time.deltaTime * 2;
        }

        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

        if (playerHealth <= 0 && isPlayerDead == false)
        {
            playerDeadZombieBehavior();
        } 
    }

    void lookAtPlayer()
    {
        Vector3 v3 = survivor.transform.position - myTransform.position;
        v3.y = 0.0f;
        myTransform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(v3), Time.deltaTime * damping);
    }

    void walkTowardPlayer()
    {
        myTransform.position += myTransform.forward * enemySpeed * Time.deltaTime;
    }

    void attack()
    {
        if (coolDownTimer == 0)
        {
            a.Play("attack1");
            Debug.Log("player health is " + playerHealth);
            playerHealth += damage;
            coolDownTimer = 2;
        }
    }

    void playerDeadZombieBehavior()
    {
        a.Stop();
        Debug.Log("player is dead");
        isPlayerDead = true;
        a.Play("idle");
    }

}
