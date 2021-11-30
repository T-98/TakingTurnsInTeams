using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum State {
    START, 
    PLAYERTURN,
    ENEMYPHASE,
    COMBATPHASE,
    WIN,
    LOSE
}

public class CombatSystem : MonoBehaviour
{
    public State state;

    public Transform enemyPos;
    public Transform warriorPos;
    public Transform thiefPos;
    public Transform magePos;

    public Enemy enemy;
    public Warrior warrior;
    public Thief thief;
    public Mage mage;

    Character selected;

    //This will store what move a character did.
    Dictionary<Character, int> moves;

    void Start() {
        state = State.START;
        SetUp();
    }

    void Update() {
        if(!warrior.hasMove() && !thief.hasMove() && !mage.hasMove() && state == State.PLAYERTURN) {
            state = State.ENEMYPHASE;
            EnemyPhase();
        }
    }

    void SetUp() {
        enemy.Reset();
        warrior.Reset();
        thief.Reset();
        mage.Reset();
        moves = new Dictionary<Character, int>();
       // warrior.canvas = 
        warrior.disableCanvas();
        thief.disableCanvas();
        mage.disableCanvas();

        state = State.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn() {
        Debug.Log("Select your move");
    }

    public void selectedChara(Character Chara) {
        warrior.disableCanvas();
        thief.disableCanvas();
        mage.disableCanvas();
        if(Chara.hasMove()) {
            selected = Chara;
            selected.enableCanvas();
        }
    }

    public void OnAttackClick(int atkID) {
        if(selected.hasMove()) {
            //Use atkID to know which button was pressed
            //atkID is the key to the dictionary in respective character classes
            //Use it when different moves are being implemented
            selected.usedMove();
            moves.Add(selected, atkID);
            Debug.Log(selected.name + " selected attack " + atkID + " => "+ selected.getAbilities()[atkID]);
            selected.disableCanvas();
        }
    }

    public void EnemyPhase() {
        //change this to pick random target
        enemy.pickTarget(warrior);
        moves.Add(enemy, 0);
        
        state = State.COMBATPHASE;

        CombatPhase();
    }

    public void CombatPhase() {
        // This is temporary thing that just plays all the moves out
        //speed sorting
        //reorder the map
        //attk after sorting
        /*foreach(KeyValuePair<Character, int> move in moves.OrderBy(key=>key.speed))
        {

        }*/
        Dictionary<Character, int> sortedMoves = new Dictionary<Character, int>();
        while(moves.Count > 0) {
            Character i = moves.First().Key;
            int id = moves.First().Value;
            int speed = i.getSpeed();
            foreach(KeyValuePair<Character, int> move in moves) {
                if(move.Key.getSpeed() < speed) {
                    i = move.Key;
                    id = move.Value;
                    speed = move.Key.getSpeed();
                }
            }
            sortedMoves.Add(i, id);
            moves.Remove(i);
        }

        foreach (KeyValuePair<Character, int> move in sortedMoves) {
            Debug.Log(move.Key);
            Debug.Log(move.Value);
            move.Key.execute(move.Value);
        }

        //yield return new WaitForSeconds(2f);

        warrior.refreshTurn();
        thief.refreshTurn();
        mage.refreshTurn();
        sortedMoves.Clear();
        //check for character deaths
        state = State.PLAYERTURN;
    }
}
