using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public float vitesseText;
    private bool displayingText = false;

    public Animator animator;

    private Queue<string> names;
    private Queue<string> sentences;

    private string currentName;
    private string currentSentence;


    void Start()
    {
        names = new Queue<string>();
        sentences = new Queue<string>();
    }

    public void StartDialogue(List<DialogueEntry> dialogues)
    {
        animator.SetBool("isOpen", true);

        names.Clear();
        sentences.Clear();

        foreach (DialogueEntry dialogue in dialogues)
        {
            names.Enqueue(dialogue.name);
            sentences.Enqueue(dialogue.dialogue);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        Debug.Log("Yolo");

        // Termine le dialogue s'il est arrivé au bout
        if (sentences.Count == 0 && !displayingText)
        {
            EndDialogue();
            return;
        }

        // Permet d'afficher tout le texte en cours d'un coup (lors d'un clique)
        if (displayingText)
        {
            TypeAllSentence(currentSentence, currentName);
            StopAllCoroutines();
        }

        // Affiche le texte à la vitesse indiqué
        else
        {
            currentName = names.Dequeue();
            currentSentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(currentSentence, currentName));
        }
    }

    // Affiche le texte à la vitesse indiqué
    IEnumerator TypeSentence (string sentence, string name)
    {
        nameText.text = name;
        dialogueText.text = "";
        displayingText = true;
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(vitesseText);
        }
        displayingText = false;
    }

    // Affiche tout le texte en cours d'un coup
    private void TypeAllSentence(string sentence, string name)
    {
        nameText.text = name;
        dialogueText.text = sentence;
        displayingText = false;
    }

    // Met fin au dialogue
    private void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }
}
