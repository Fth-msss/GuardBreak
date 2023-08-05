using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Interactables : MonoBehaviour
{

    //properties
    [SerializeField]
    bool isInteractableByPlayer;
    [SerializeField]
    bool isInteractableByOthers;

    [Header("interaction settings")]
    [SerializeField]
    bool RequireRaycast;
    [SerializeField]
    GameObject interactPoint;
    [SerializeField]
    float interactRadius = 10;
    [SerializeField]
    Collider interactTriggerCollider;

    //what object does to self when interacted
    [SerializeField]
    UnityEvent onInteract;

    public bool IsInteractableByPlayer { get => isInteractableByPlayer; }
    public bool IsInteractableByOthers { get => isInteractableByOthers; }


    

    private void Start()
    {
        if(interactPoint == null) { interactPoint = gameObject; }
        if(interactTriggerCollider == null) { Debug.LogError("no collider on interactable"); }

        if(!isInteractableByPlayer) { interactTriggerCollider.enabled = false; }
    }






    //functions

    //what object does on interact 
    public void Interact() 
    {
    onInteract.Invoke();
    }

    //send a feedback on players who can interact with this object
    private void Update()
    {
        if(RequireRaycast) 
        {
        foreach (GameObject player in PlayersInRange) 
            {
               

                Vector3 startPoint = interactPoint.transform.position;
                Vector3 endPoint = player.transform.position;

                Vector3 direction = (endPoint - startPoint).normalized;
                float distance = Vector3.Distance(startPoint, endPoint);
               
                RaycastHit hit;
                if (Physics.Raycast(startPoint, direction, out hit))
                {
                    if (ReferenceEquals(player,hit.collider.gameObject)) 
                    {
                    //player is able to interact
                    }
                  
                }

            }
        }
    }

    List<GameObject> PlayersInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
        PlayersInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            PlayersInRange.Remove(other.gameObject);
        }
    }



}
