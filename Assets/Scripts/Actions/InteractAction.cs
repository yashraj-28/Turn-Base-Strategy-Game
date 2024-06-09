using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAction : BaseAction
{   
    private int maxInteractDistance = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        {
            return;
        }

        //ActionComplete();
    }

    public override string GetActionName()
    {
        return "Interact";
    }

    public override EnemyAIAction GetEnemyAIAction(GridPosition gridPosition)
    {
        return new EnemyAIAction
        {
            gridPosition = gridPosition,
            actionValue = 0
        };
    }

    public override List<GridPosition> GetValidActionGridPositionList()
    {
         List<GridPosition> validGridPositionList = new List<GridPosition>();
        GridPosition unitGridPosition = unit.GetGridPosition();
        

        for(int x = -maxInteractDistance; x <= maxInteractDistance; x++)
        {
            for(int z = -maxInteractDistance; z <= maxInteractDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x,z);
                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                if(!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                {
                    continue;
                }

                IInteractable interactable = LevelGrid.Instance.GetInteractableAtGridPosition(testGridPosition);
                
                if(interactable == null)
                {
                    // No interactable (door/sphere) on this grid position
                    continue;
                }
               
                validGridPositionList.Add(testGridPosition);
                //Debug.Log(testGridPositon);
            }
        }
        return validGridPositionList;
    }

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        Debug.Log("Interact Action");

        IInteractable interactable = LevelGrid.Instance.GetInteractableAtGridPosition(gridPosition);  
        interactable.Interact(OnInteractComplete);

        ActionStart(onActionComplete);
    }
    private void OnInteractComplete()
    {
        ActionComplete();
    }
    
}
