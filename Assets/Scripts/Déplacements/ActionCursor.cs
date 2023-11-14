using UnityEngine;

public class ActionCursor : MonoBehaviour
{
    public Transform playerTransform; // Référence à votre joueur
    public Texture2D defaultCursorTexture;
    public Texture2D npcHoverCursorTexture;
    public Texture2D noSpeakCursorTexture; // Votre curseur "NoSpeak"
    public Vector2 hotspot = Vector2.zero;
    public float maxSpeakDistance; // Distance maximale pour interagir avec le PNJ
    public float maxSpeakRender;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        SetDefaultCursor();
    }

    private void Update()
    {
        CheckForNPCUnderCursor();
    }

    void CheckForNPCUnderCursor()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("NPC"))
            {
                // Vérifier la distance entre le joueur et le PNJ
                float distanceToNPC = Vector3.Distance(playerTransform.position, hit.collider.transform.position);

                if (distanceToNPC <= maxSpeakDistance)
                {
                    SetNPCHoverCursor();

                    if (Input.GetMouseButtonDown(0))
                    {
                        Dialogue dialogueScript = hit.collider.GetComponent<Dialogue>();
                        if (dialogueScript != null)
                        {
                            dialogueScript.StartDialogue();
                        }
                    }
                }
                else if (distanceToNPC <= maxSpeakRender)
                {
                    SetNoSpeakCursor();
                }
                else{
                    SetDefaultCursor();
                }

                return;
            }
        }

        SetDefaultCursor();
    }

    void SetDefaultCursor()
    {
        Cursor.SetCursor(defaultCursorTexture, hotspot, CursorMode.Auto);
    }

    void SetNPCHoverCursor()
    {
        Cursor.SetCursor(npcHoverCursorTexture, hotspot, CursorMode.Auto);
    }

    void SetNoSpeakCursor()
    {
        Cursor.SetCursor(noSpeakCursorTexture, hotspot, CursorMode.Auto);
    }
}
