using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    private int currentQuest = 0; 

    public void SetCurrentQuest(int questNumber)
    {
        currentQuest = questNumber;
    }

    public int GetCurrentQuest()
    {
        return currentQuest;
    }


}
