using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableButton : Interactables
{
    [SerializeField]
    buttonEvent buttonInteract;

    protected override void Start()
    {
        base.Start();
    }

    public void Interact(GameObject obj)
    {
       
       
            buttonInteract.Invoke(gameObject);
        
    }
        
        
    
}


[System.Serializable]
public class buttonEvent : UnityEvent<GameObject>
{

}