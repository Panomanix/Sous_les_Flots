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

//Les dialogues d'une quête précise
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
            Debug.LogError("Erreur de chargement des données JSON.");
            return;
        }

        // Affiche la structure de données après la désérialisation
        Debug.Log("Structure Json = " + JsonUtility.ToJson(dialoguesData));
    }

    public List<DialogueEntry> GetDialogue(string questName, string characterName)
    {
        Debug.Log("Quête " + questName);
        Debug.Log("Personnage : " + characterName);

        // Recherche de la quête correspondant au numéro de quête
        Debug.Log("QuestName = " + questName);
        Quest quest = dialoguesData.quests.Find(q => q.name == questName);

        if (quest != null)
        {
            // Recherche du personnage dans la liste de dialogues de la quête
            CharacterDialogue characterDialogue = quest.characterDialogues.Find(c => c.name == characterName);

            if (characterDialogue != null)
            {
                // Récupération des dialogues du personnage pour la quête
                return characterDialogue.dialogues;
            }
        }

        return null;
    }
}