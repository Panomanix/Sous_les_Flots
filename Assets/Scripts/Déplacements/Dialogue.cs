using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue()
    {
        // Faire en sorte que le PNJ regarde vers le joueur
        LookAtTarget(playerTransform, transform);

        // Faire en sorte que le joueur regarde vers le PNJ
        LookAtTarget(transform, playerTransform);
        Debug.Log("Bonjour! Je suis un PNJ et je parle!");
    }

    private void LookAtTarget(Transform target, Transform observer)
    {
        // Oriente l'observer pour qu'il regarde vers le target
        observer.LookAt(target);

        // Si vous ne voulez que l'observer s'oriente uniquement sur l'axe Y (pour qu'il ne "penche" pas vers le target),
        // vous pouvez réinitialiser les rotations X et Z après avoir appelé LookAt :
        observer.eulerAngles = new Vector3(0, observer.eulerAngles.y, 0);
    }
}
