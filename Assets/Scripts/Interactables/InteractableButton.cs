using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableButton : Interactables
{
    [SerializeField]
    buttonEvent buttonInteract;

    // Start is called before the first frame update
    void Start()
    {
        buttonInteract.Invoke(gameObject);
    }


    public void Interact(GameObject obj)
    {
        if (obj.CompareTag("Player") && IsInteractableByPlayer)
        {
            buttonInteract.Invoke(gameObject);
        }
    }
        
        
    
}


[System.Serializable]
public class buttonEvent : UnityEvent<GameObject>
{
}