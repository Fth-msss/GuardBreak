using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactables
{
    [SerializeField]
    doorState state;
    [SerializeField]
    Animator animator;
    
    bool isOpen=false;
    [SerializeField]
    bool isLocked;

    public void UnlockDoor () 
    {
   
    }

    public void OpenDoor() 
    {
     if (!isOpen) 
        {
            //animator.SetTrigger("ChangedoorState");
            isOpen = true;
            animator.Play("dooropen");
        }
    }

    public void CloseDoor() 
    {
       if(isOpen) 
        {
            //animator.SetTrigger("ChangedoorState");
            animator.Play("doorclose");
            isOpen = false;
        }
    }

    public void ReverseDoor() 
    {
        animator.SetTrigger("ChangedoorState");
    }
}


enum doorState 
{
    open,closed,moving

}