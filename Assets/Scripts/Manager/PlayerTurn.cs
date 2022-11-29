using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    [SerializeField] private TurnManager playerActive;
    private int playerIndex;
    private bool followThisPlayer;

    public void SetPlayerTurn(int index)
    {
        playerIndex = index;
        Debug.Log("005 :  " + index);
    }

    public bool IsPlayerTurn()
    {
        Debug.Log("006 :  " + playerIndex + " _006_ >" + TurnManager.GetInstance().IsItPlayerTurn(playerIndex));
        followThisPlayer = TurnManager.GetInstance().IsItPlayerTurn(playerIndex);

        if (followThisPlayer)
        {
            GetCurrentPlayer();
        }
        else
            Debug.Log("007:  " + followThisPlayer);

        return TurnManager.GetInstance().IsItPlayerTurn(playerIndex);
    }

    public void GetCurrentPlayer()
    {
        //followThisPlayer = playerActive;
        Debug.Log("Active 007:                              " + followThisPlayer);
        //Debug.Log("Active 000" + followThisPlayer);
    }
}
