using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Transform player;
    //health
    [SerializeField] public int playerHealth;
    public TextMeshProUGUI scorehealth;
    public TextMeshProUGUI scorelevel;

    private void Start()
    {
        
        //playerHealth = 3;
    }

    void Update()
    {
        scorehealth.text = "Health: " + playerHealth.ToString();
        scorelevel.text = "Level: " + SceneManager.GetActiveScene().name;
    }

    public void playerDamage()
    {
        playerHealth -= 1;


        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("Level1");
        }
    }

    public void playerKill()
    {
        playerHealth -= 2;
    }

    public void playerHeal()
    {
        if(playerHealth < 3)
        {
            playerHealth += 1;
        }

    }

    //fix to work with GameOverMenu

}