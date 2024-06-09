using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : MonoBehaviour, IInteractable
{
    private GridPosition gridPosition;
    [SerializeField] private bool isOpen;
    private Animator animator;
    private Action onInteractComplete;
    private float timer;
    private bool isActive;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() 
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.SetInteractableAtGridPosition(gridPosition, this);    

        if(isOpen)
        {
            OpenDoor();
        }else{
            CloseDoor();
        }
    }
    private void Update() 
    {
        if(!isActive)
        {
            return;
        }

        timer -= Time.deltaTime;

        if(timer <= 0f)
        {   
            isActive = false;
            onInteractComplete();
        }    
    }
    public void Interact(Action onInteractComplete)
    {
        Debug.Log("Door.Interact()");

        this.onInteractComplete = onInteractComplete;
        isActive = true;
        timer = 0.5f;
        if(isOpen)
        {
            CloseDoor();
        }else{
            OpenDoor();
        }
    }
    private void OpenDoor()
    {
        isOpen = true;
        animator.SetBool("IsOpen", isOpen);
        PathFinding.Instance.SetIsWalkableGridPosition(gridPosition, true);
    }
    private void CloseDoor()
    {
        isOpen = false;
        animator.SetBool("IsOpen", isOpen);
        PathFinding.Instance.SetIsWalkableGridPosition(gridPosition, false);
    }
}
