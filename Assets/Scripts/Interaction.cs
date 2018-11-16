using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interaction : MonoBehaviour {

    NavMeshAgent navmeshAgent;

    void Start()
    {
        navmeshAgent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();

        }
        
    }

    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if(Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactionObject = interactionInfo.collider.gameObject;
            if(interactionObject.tag == "interactable Object")
            {
                Debug.Log("Interactable Object");
            }
            else
            {
                navmeshAgent.SetDestination(interactionInfo.point);
            }
        }
    }



}
