using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        enemy.usedMove();
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
            if(atkID > 3 && !selected.hasRemaining(atkID)) {
                return;
            }
            selected.usedMove();
            moves.Add(selected, atkID);
            selected.disableCanvas();
        }
    }

    //speedsystem dict => //make a new dictionary with atk names "selected.getAbilities()[atkID]" and respective speeds
    public void EnemyPhase() {
        //change this to pick random target

        List<Character> alive = new List<Character>();
        if(warrior.isAlive()) {
            alive.Add(warrior);
        } else {
            Debug.Log("warrior is dead");
        }
        if(mage.isAlive()) alive.Add(mage);
        if(thief.isAlive()) alive.Add(thief);
        enemy.pickTarget(alive[Random.Range(0,alive.Count)]);

        int randomMove = Random.Range(0, 5);

        moves.Add(enemy, randomMove);
        enemy.setSpeed(randomMove);
        
        state = State.COMBATPHASE;

        CombatPhase();
    }

    public void CombatPhase() {
        // This is temporary thing that just plays all the moves out
        //speed sorting
        //reorder the map
        //attk after sorting

        //iterate and sort speed system dict
        //Algorithm
        //var sortedDict = from entry in myDict orderby entry.Value ascending select entry;

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
            if(move.Key.isAlive())move.Key.execute(move.Value);
        }

        //yield return new WaitForSeconds(2f);

        sortedMoves.Clear();

        completeTurn();
    }

    public void completeTurn() {
        if(warrior.isAlive()) warrior.refreshTurn();
        if(thief.isAlive()) thief.refreshTurn();
        if(mage.isAlive()) mage.refreshTurn();
        enemy.resetImmune();
        //check for character deaths

        if(!thief.isAlive() && !mage.isAlive() && !warrior.isAlive()) {
            state = State.LOSE;
            StartCoroutine(lose());
        } else if(!enemy.isAlive()) {
            state = State.WIN;
            StartCoroutine(win());
        } else {
            state = State.PLAYERTURN;
        }
    }

    public IEnumerator win() {
        Debug.Log("You have won!");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene (sceneName:"Menu");
    }

    public IEnumerator lose() {
        Debug.Log("You have lost!");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene (sceneName:"Menu");
    }
}
