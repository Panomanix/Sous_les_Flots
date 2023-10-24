using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;

//La composition du dialogue d'un personnage
[System.Serializable]
public class DialogueEntry
{
    public string name;
    public string dialogue;
}

//Un dialogue entier avec un personnage
[System.Serializable]
public class CharacterDialogue
{
    public string name;
    public List<DialogueEntry> dialogues;
}

//Les dialogues d'une qu�te pr�cise
[System.Serializable]
public class Quest
{
    public string name;
    public List<CharacterDialogue> characterDialogues;
}

//Ensemble du JSON
[System.Serializable]
public class JSONData
{
    public string version;
    public string language;
    public List<Quest> quests;
}


public class DialogueReader : MonoBehaviour
{
    public TextAsset jsonFile;
    private JSONData dialoguesData;

    private void Start()
    {
        LoadDialoguesFromJSON();
    }

    public void LoadDialoguesFromJSON()
    {
        Debug.Log("jsonFile.text = " + jsonFile.text);
        dialoguesData = JsonConvert.DeserializeObject<JSONData>(jsonFile.text);

        //dialoguesData = JsonUtility.FromJson<JSONData>(jsonFile.text);

        if (dialoguesData == null)
        {
            Debug.LogError("Erreur de chargement des donn�es JSON.");
            return;
        }

        // Affiche la structure de donn�es apr�s la d�s�rialisation
        Debug.Log("Structure Json = " + JsonUtility.ToJson(dialoguesData));
    }

    public List<DialogueEntry> GetDialogue(string questName, string characterName)
    {
        Debug.Log("Qu�te " + questName);
        Debug.Log("Personnage : " + characterName);

        // Recherche de la qu�te correspondant au num�ro de qu�te
        Debug.Log("QuestName = " + questName);
        Quest quest = dialoguesData.quests.Find(q => q.name == questName);

        if (quest != null)
        {
            // Recherche du personnage dans la liste de dialogues de la qu�te
            CharacterDialogue characterDialogue = quest.characterDialogues.Find(c => c.name == characterName);

            if (characterDialogue != null)
            {
                // R�cup�ration des dialogues du personnage pour la qu�te
                return characterDialogue.dialogues;
            }
        }

        return null;
    }
}