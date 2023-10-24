using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public float vitesseText;

    public Animator animator;

    private Queue<string> names;
    private Queue<string> sentences;


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
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string name = names.Dequeue();
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, name));
    }

    IEnumerator TypeSentence (string sentence, string name)
    {
        nameText.text = name;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(vitesseText);
        }
    }

    private void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }
}
