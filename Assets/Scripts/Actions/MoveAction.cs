using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveAction : BaseAction
{
    private List<Vector3> positionList;
    private int currentPositionIndex;
    //[SerializeField] private Animator unitAnimator;
    [SerializeField] private int maxMoveDistance = 4;
    public event EventHandler OnStartMoving;
    public event EventHandler OnStopMoving;
    

    
    private void Update() {

        if(!isActive){
            return;
        }
        float stoppingDistance = .1f;

        Vector3 targetPosition = positionList[currentPositionIndex];
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

        if(Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {

        float moveSpeed = 4f;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

       // unitAnimator.SetBool("IsWalking",true);

        }else{
            //unitAnimator.SetBool("IsWalking", false);
            currentPositionIndex++;

            if(currentPositionIndex >= positionList.Count){

                OnStopMoving?.Invoke(this,EventArgs.Empty);
                ActionComplete();
            }
            
        }

        
    }
    
   
    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        List<GridPosition> pathGridPositionList = PathFinding.Instance.FindPath(unit.GetGridPosition(), gridPosition, out int pathLength);

        currentPositionIndex = 0;
        positionList= new List<Vector3>();

        foreach(GridPosition pathGridPosition in pathGridPositionList)
        {
            positionList.Add(LevelGrid.Instance.GetWorldPosition(pathGridPosition));
        }

        OnStartMoving?.Invoke(this, EventArgs.Empty);
        
        ActionStart(onActionComplete);
    }

   

    public override List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();
        GridPosition unitGridPosition = unit.GetGridPosition();

        for(int x = -maxMoveDistance; x <= maxMoveDistance; x++)
        {
            for(int z = -maxMoveDistance; z <= maxMoveDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x,z);
                GridPosition testGridPositon = unitGridPosition + offsetGridPosition;
                if(!LevelGrid.Instance.IsValidGridPosition(testGridPositon))
                {
                    continue;
                }
                if(unitGridPosition == testGridPositon)
                {
                    // same position where unit is already at
                    continue;
                }
                if(LevelGrid.Instance.HasAnyUnitOnGridPosition(testGridPositon))
                {
                    //  if grid position already occupied with another unit
                    continue;
                }

                if(!PathFinding.Instance.IsWalkableGridPosition(testGridPositon))
                {
                    continue;
                }
                if(!PathFinding.Instance.HasPath(unitGridPosition, testGridPositon))
                {
                    continue;
                }

                int PathFindingDistanceMultiplier = 10;
                if(PathFinding.Instance.GetPathLength(unitGridPosition, testGridPositon) > maxMoveDistance * PathFindingDistanceMultiplier)
                {
                    // path length is too long
                    continue;
                }

                validGridPositionList.Add(testGridPositon);
                //Debug.Log(testGridPositon);
            }
        }


        return validGridPositionList;
    }

    public override string GetActionName()
    {
        return "Move";
    }
    public override EnemyAIAction GetEnemyAIAction(GridPosition gridPosition)
    {
        int targetCountAtPosition = unit.GetAction<ShootAction>().GetTargetCountAtPosition(gridPosition);
        return new EnemyAIAction
        {
            gridPosition = gridPosition,
            actionValue = targetCountAtPosition * 10,
        };
    }
}
