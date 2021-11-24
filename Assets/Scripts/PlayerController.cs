using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<GameObject> players;
    public List<GameObject> enemies;
    private Vector3 initialPos;
    private bool isAttacking = false;
    private GameObject currentPlayer;
    private GameObject currentEnemy;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = players[0].transform.position;
        currentPlayer = players[0];
        currentEnemy = enemies[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttacking == true)
        {
            if (currentPlayer.transform.position.x < currentEnemy.transform.position.x - 1.2)
            {
                PlayerMove("attack");
            }
            else isAttacking = false;
        }
        else
        {
            if (currentPlayer.transform.position.x > initialPos.x)
            {
                PlayerMove("retreat");
            }
        }

    }

    void PlayerMove(string state)
    {
        if(state.Equals("attack"))
        {
            Vector2 position = currentPlayer.transform.position;
            position.x = position.x + 0.008f;
            if (currentPlayer.transform.position.y == currentEnemy.transform.position.y) Debug.Log("");
            else position.y = position.y + 0.002f;
            //position.y = position.y + 0.1f;
            currentPlayer.transform.position = position;

        }
        else
        {
            Vector2 position = currentPlayer.transform.position;
            position.x = position.x - 0.008f;
            if (currentPlayer.transform.position.y == currentEnemy.transform.position.y) Debug.Log("");
            else position.y = position.y - 0.008f;
            currentPlayer.transform.position = position;
        }

    }

    public void PlayerSelect(GameObject other)
    {
        currentPlayer = other;
        Debug.Log("Selected Player");
    }

    public void EnemySelect(GameObject other)
    {
        currentEnemy = other;
        isAttacking = true;
    }
}
