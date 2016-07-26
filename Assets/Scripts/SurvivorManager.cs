using UnityEngine;
using System.Collections;

public class SurvivorManager : MonoBehaviour
{
   private float playerHealth;
    private bool isPlayerDead;

   public float PlayerHealth
    {
        get
        {
            return playerHealth = 100f;
        }

        set
        {
            playerHealth = value;
        }
    }

    public bool IsPlayerDead
    {
        get
        {
            return isPlayerDead = false;
        }

        set
        {
            isPlayerDead = value;
        }
    }
}