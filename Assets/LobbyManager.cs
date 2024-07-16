using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class LobbyManager : MonoBehaviour
{
    //Add the player prefabs to add the player in lobby
    //after player finalizes their type save it and pass it to Player Manager
    // Start the next player choose option 
    // 

    int playerCount = 1; // starts with P1
    [SerializeField] GameObject[] PlayerPrefabs;
    [SerializeField] GameObject LobbyUIPanel1, LobbyUIPanel2;
   
    LobbyState currentState;
    public enum LobbyState
    {
        choosePlayer,
        chooseType
    }

    private void Start()
    {
        playerCount = 1;
        LobbyUIPanel1.SetActive(true);
        LobbyUIPanel2.SetActive(false);
        currentState = LobbyState.choosePlayer;
    }
     void ChangeState(LobbyState newState)
    {
        currentState = newState;

        switch (newState)
        {

            case LobbyState.choosePlayer:
                LobbyUIPanel1.SetActive(true);
                LobbyUIPanel2.SetActive(false);
              
                break;
            case LobbyState.chooseType:
                LobbyUIPanel1.SetActive(false);
                LobbyUIPanel2.SetActive(true);
              
                break;
            default:
                break;
        }
    }


    public void OnPlayerChoose(InputAction.CallbackContext context)
    {
        if (currentState == LobbyState.choosePlayer)  // because this part is on panel 1
        {
            playerCount++;
            ChangeState(LobbyState.chooseType);
        }
    }
    public void OnAIChoose(InputAction.CallbackContext context) 
    {
        if (currentState == LobbyState.choosePlayer)
        {
            playerCount++;
            //randomly choose a type and go to next player 
        }
    
    }


    //Types of player not the player count
    public void OnPlayerOne(InputAction.CallbackContext context)
    {
        if(currentState == LobbyState.chooseType)
        {

        }
    }

    public void OnPlayerTwo(InputAction.CallbackContext context)
    {
        if (currentState == LobbyState.chooseType)
        {

        }
    }

    public void OnPlayerThree(InputAction.CallbackContext context)
    {
        if (currentState == LobbyState.chooseType)
        {

        }
    }

    public void OnPlayerFour(InputAction.CallbackContext context)
    {
        if (currentState == LobbyState.chooseType)
        {

        }
    }

    public void OnPlayerFive(InputAction.CallbackContext context)
    {
        if (currentState == LobbyState.chooseType)
        {

        }
    }
}
