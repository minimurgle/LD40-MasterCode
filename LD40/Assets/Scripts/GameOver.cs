using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class GameOver : MonoBehaviour {

    [Header("Scripts")]
    public PlayerMoney playerMoney;
    public PowerAndAproval powerAndAproval;
    public TurnManager turnManager;
    public EventUI eventUI;

    [Space(2)]

    public Text gameOverText;
    public bool gameLost;
    int moneyGraceTurns = 1;
    public int aprovalGraceTurns = 1;


    public void CheckForMoneyLoss()
    {
        if (playerMoney.totalMoney > 0)
        {
            moneyGraceTurns = 1;
        }
        else if (playerMoney.totalMoney <= 0 && moneyGraceTurns > 0)
        {
            moneyGraceTurns -= 1;
            if (eventUI.event1Taken == false)
            {
                eventUI.eventText.text = "You're out of money, if you don't get it above 0 for the next turn you'll run out of funding!";
                eventUI.GameOverEvent();
                eventUI.event1Taken = true;
            }
            else if (eventUI.event2Taken == false)
            {

                eventUI.event2Text.text = "You're out of money, if you don't get it above 0 for the next turn you'll run out of funding!";
                eventUI.GameOverEvent();
                eventUI.event2Taken = true;
            }
            else
            {
                eventUI.event3Text.text = "You're out of money, if you don't get it above 0 for the next turn you'll run out of funding!";
                eventUI.GameOverEvent();
            }
        }
        else if (playerMoney.totalMoney <= 0 && moneyGraceTurns <= 0)
        {
            gameOverText.text = "The city's police department is out of funds, local municipality has decided to replace you";
            GameLost();
        }
    }

    public void CheckForAprovalLoss()
    {
        if (powerAndAproval.publicAproval > 0)
        {
            Debug.Log("Aproval good");
            aprovalGraceTurns = 1;
        }
        else if (powerAndAproval.publicAproval <= 0 && aprovalGraceTurns > 0)
        {
            Debug.Log("Aproval -1");
            aprovalGraceTurns -= 1;
            if (eventUI.event1Taken == false)
            {
                eventUI.eventText.text = "The public hates you, if you don't raise your approval for the next turn you'll be replaced!";
                eventUI.GameOverEvent();
                eventUI.event1Taken = true;
            }
            else if (eventUI.event2Taken == false)
            {
                eventUI.event2Text.text = "The public hates you, if you don't raise your approval for the next turn you'll be replaced!";
                eventUI.GameOverEvent();
                eventUI.event2Taken = true;
            }
            else
            {
                eventUI.event3Text.text = "The public hates you, if you don't raise your approval for the next turn you'll be replaced!";
                eventUI.GameOverEvent();

            }
            
        }
        else if (powerAndAproval.publicAproval <= 0 && aprovalGraceTurns <= 0)
        {
            Debug.Log("Aproval lose");
            gameOverText.text = "You were replaced due to growing concerns of your competence";
            GameLost();
        }
    }


    public void GameLost()
    {

        gameLost = true;
        gameOverText.gameObject.SetActive(true);
        SetScore();
    }

    public void GameWon()
    {
        gameLost = true;
        gameOverText.text = "Crime has taken over, you lose... Wait, REALLY?! You got rid of all the crime? HOW? I... I guess you win then? I didnt think it was possible.";
        gameOverText.gameObject.SetActive(true);
        SetScore();
    }

    void SetScore()
    {
        Analytics.CustomEvent("gameOver", new Dictionary<string, object>
        {
            {"turnsPlayed", turnManager.currentTurn }
        });
    }

}
