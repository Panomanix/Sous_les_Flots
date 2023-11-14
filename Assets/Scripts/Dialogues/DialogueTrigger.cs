using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public string characterName;
    public GameManager gameManager;
    public DialogueManager dialogueManager;
    public DialogueReader dialogueReader;

    // Lance le dialogue lorsqu'on clique sur le personnage
    private void OnMouseDown()
    {
        if (gameManager == null || dialogueManager == null || dialogueReader == null)
        {
            Debug.Log("Vous n'avez pas renseignés un ou plusieurs managers");
            return;
        }
        
        StartDialogue();

    }

    // Commencer un dialogue
    public void StartDialogue()
    {
        int currentQuest = gameManager.GetCurrentQuest() + 1;
        List<DialogueEntry> dialogue = dialogueReader.GetDialogue("quest" + currentQuest, characterName);
        if (dialogue != null)
        {
            dialogueManager.StartDialogue(dialogue);
        }
        else
        {
            Debug.LogWarning("Dialogue non trouvé pour la quête " + currentQuest + " avec le personnage " + characterName);
        }
    }
}
