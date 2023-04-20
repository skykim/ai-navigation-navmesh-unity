using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public float animationDuration;
    private Animator doorAnimator;
    
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        foreach (var clip in doorAnimator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == "Open")
            {
                animationDuration = clip.length;
            }
        }
    }

    public void OpenDoor()
    {
        doorAnimator.SetTrigger("OpenDoor");
    }
    
    public void CloseDoor()
    {
        doorAnimator.SetTrigger("CloseDoor");
    }
}
