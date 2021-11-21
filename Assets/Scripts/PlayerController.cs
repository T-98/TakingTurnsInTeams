using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<GameObject> players;
    public List<GameObject> enemies;
    private Vector3 initialPos;
    private bool isAttacking = false;
    private int selectPlayer = 0;
    private int selectEnemy = 0;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = players[selectPlayer].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttacking == true)
        {
            if (players[selectPlayer].transform.position.x < enemies[selectEnemy].transform.position.x - 1.2)
            {
                PlayerMove("attack");
            }
            else isAttacking = false;
        }
        else
        {
            if (players[selectPlayer].transform.position.x > initialPos.x)
            {
                PlayerMove("retreat");
            }
        }

    }

    void PlayerMove(string state)
    {
        if(state.Equals("attack"))
        {
            Vector2 position = players[selectPlayer].transform.position;
            position.x = position.x + 0.008f;
            //position.y = position.y + 0.1f;
            players[selectPlayer].transform.position = position;

        }
        else
        {
            Vector2 position = players[selectPlayer].transform.position;
            position.x = position.x - 0.008f;
            //position.y = position.y + 0.1f;
            players[selectPlayer].transform.position = position;
        }

    }

    public void PlayerSelect(string which)
    {
      if(which.Equals("player2"))
        {
            selectPlayer = 1;
        }
      else
        {
            selectPlayer = 0;
        }
    }

    public void EnemySelect(string which)
    {
        if (which.Equals("enemy2"))
        {
            selectEnemy = 1;
        }
        else
        {
            selectEnemy = 0;
        }
        isAttacking = true;
    }
}
