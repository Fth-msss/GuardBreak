using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactables
{

   
    [SerializeField]
    Animator animator;

    [Header("door properties")]
    [SerializeField]
    bool isOpen=false;
    [SerializeField]
    bool isLocked;

    //locked doors are not 
    public void UnlockDoor () 
    {
        //ya sen beni cok olumsuz etkiliyosun
        //artýk hürrem izlemeden rahat rahat bisey yapamiyorum
        Debug.Log("locked doors are not implemented yet");
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


