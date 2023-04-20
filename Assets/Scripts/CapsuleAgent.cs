using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class CapsuleAgent : MonoBehaviour
{
    private NavMeshAgent _agent;
    private float animationPerformingDelay = 0.0f;
    
    void Start()
    {
        _agent = this.GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                _agent.destination = hit.point;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            _agent.isStopped = true;
            other.GetComponent<DoorScript>().OpenDoor();
            animationPerformingDelay = other.GetComponent<DoorScript>().animationDuration;
            StartCoroutine(DelayCoroutine());
        }
    }

    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(animationPerformingDelay);
        
        _agent.isStopped = false;
        animationPerformingDelay = 0;
    }
}
