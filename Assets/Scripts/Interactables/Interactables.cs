using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Interactables : MonoBehaviour
{

    //properties
    [SerializeField]
    bool isInteractableByPlayer;
    [SerializeField]
    bool isInteractableByOthers;
    [SerializeField]
    int InteractPriority;

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

    [SerializeField]
    List<GameObject> PlayersInRange;

    public bool IsInteractableByPlayer { get => isInteractableByPlayer; }
    public bool IsInteractableByOthers { get => isInteractableByOthers; }


    

    protected virtual void Start()
    {
        //enable interaction  
        if(isInteractableByPlayer || isInteractableByOthers) 
        {
            //set interact range
            if (interactPoint == null) 
            {
                Debug.LogWarning("interactable has no set interact point but set as interactable");
                interactPoint = gameObject;
               
            }


            if (interactTriggerCollider == null) { Debug.LogError("interactable has no trigger collider set"); }
            else 
            {
                if (interactTriggerCollider is SphereCollider) 
                {
                    SphereCollider Scollider = interactTriggerCollider as SphereCollider;
                    Scollider.radius = interactRadius;
                }
            }

        }


        
       


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
        if(RequireRaycast && PlayersInRange.Count>0) 
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
                Ray ray = new Ray(startPoint, direction);
                
                bool hasHit = Physics.Raycast(ray, out hit, distance);

                Color rayColor = hasHit ? Color.green : Color.red;
                Debug.DrawRay(ray.origin, ray.direction * (hasHit ? hit.distance : distance), rayColor);

            }
        }
        else if(PlayersInRange.Count>0) 
        {
        //players are able to interact
        }
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("added something in interact list");
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
