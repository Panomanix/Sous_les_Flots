using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public string characterName;
    public DialogueManager dialogueManager;
    public GameManager gameManager;
    public DialogueReader dialogueReader;

    // Lance le dialogue lorsqu'on clique sur le personnage
    private void OnMouseDown()
    {
        if (dialogueManager != null)
        {
            StartDialogue();
        }
    }

    // Commencer un dialogue
    public void StartDialogue()
    {
        int currentQuest = gameManager.GetCurrentQuest();
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
