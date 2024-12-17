using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int playerHealth = 3;
    int startHealth;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] int maxNumJumps = 0;
    [SerializeField] float jumpSpeed = 8f;
    int numJumps;

    void Awake()
    {
        int numGameSessions = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        startHealth = playerHealth;
        numJumps = maxNumJumps;
        Debug.Log("Player Health" + playerHealth);
        Debug.Log("Player Lives" + playerLives);
    }



    public void InitiateJump()
    {
        if (numJumps > 0)
        {
            rb.velocity += new Vector2(0f, jumpSpeed);
            numJumps--;
        }
    }

    public void AddToMaxNumJumps()
    {
        maxNumJumps++;
    }

    public void ResetNumJumps()
    {
        numJumps = maxNumJumps;
    }



    public void ProcessPlayerDamage()
    {
        if (playerHealth > 1)
        {
            TakeHealth();
        }
        else
        {
            TakeLife();
        }
    }
    void TakeHealth()
    {
        playerHealth--;
        Debug.Log("Player Health" + playerHealth);
    }


    void TakeLife()
    {
        if (playerLives > 1)
        {
            playerLives--;
            playerHealth = startHealth;
            Debug.Log("Player Lives" + playerLives);
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
        else
        {
            ResetGameSession();
        }
    }

    void ResetGameSession()
    {
        FindAnyObjectByType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}