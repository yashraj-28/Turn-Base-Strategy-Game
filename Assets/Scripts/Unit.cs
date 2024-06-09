using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Unit : MonoBehaviour
{

    private const int ACTION_POINTS_MAX = 9;    
    private GridPosition gridPosition;
   // private MoveAction moveAction;
    //private SpinAction spinAction;
    //private ShootAction shootAction;
    private BaseAction[] baseActionArray;
    private int actionPoints = ACTION_POINTS_MAX;
    [SerializeField] private bool isEnemy;
    private HealthSystem healthSystem;
    public static event EventHandler OnAnyActionPointsChanged;
    public static event EventHandler OnAnyUnitSpawned;
    public static event EventHandler OnAnyUnitDead;

    private void Awake() {
        //moveAction = GetComponent<MoveAction>();
        //spinAction = GetComponent<SpinAction>();
        //shootAction = GetComponent<ShootAction>();
        baseActionArray = GetComponents<BaseAction>();
        healthSystem = GetComponent<HealthSystem>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this);

        TurnSystem.Instance.OnTurnChanged += TurnSystem_OnTurnChanged;

        healthSystem.OnDead += HealthSystem_OnDead;

        OnAnyUnitSpawned?.Invoke(this, EventArgs.Empty);
    }

    // Update is called once per frame
    void Update()
    {
       
        
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if(newGridPosition != gridPosition)
        {
            // unit changed grid position
            GridPosition oldGridPosition = gridPosition;
            gridPosition = newGridPosition;

            LevelGrid.Instance.UnitMovedGridPosotion(this, oldGridPosition, newGridPosition);
        }
       
    }

    public T GetAction<T>() where T : BaseAction
    {
        foreach(BaseAction baseAction in baseActionArray)
        {
            if(baseAction is T)
            {
                return (T)baseAction;
            }
        }
        return null;
    }

    /*public MoveAction GetMoveAction()
    {
        return moveAction;
    }

    public SpinAction GetSpinAction()
    {
        return spinAction;
    }
    public ShootAction GetShootAction()
    {
        return shootAction;
    }*/
   
   public GridPosition GetGridPosition()
   {
    return gridPosition;
   }

   public Vector3 GetWorldPosition()
   {
    return transform.position;
   }

   public BaseAction[] GetBaseActionArray()
   {
    return baseActionArray;
   }

   public bool TrySpendActionPointsToTakeAction(BaseAction baseAction)
   {
    if(CanSpendActionPointsToTakeAction(baseAction))
    {
        SpendActionPoints(baseAction.GetActionPointsCost());
        return true;
    }else {
        return false;
    }
   }

   public bool CanSpendActionPointsToTakeAction(BaseAction baseAction)
   {
        if(actionPoints >= baseAction.GetActionPointsCost())
        {
            return true;
        }else{
            return false;
        }
   }

   private void SpendActionPoints(int amount)
   {
        actionPoints -= amount;
        OnAnyActionPointsChanged?.Invoke(this, EventArgs.Empty);
   }
   public int GetActionPoints()
   {
        return actionPoints;
   }

   private void TurnSystem_OnTurnChanged(object sender, EventArgs e)
   {
        if((IsEnemy() && !TurnSystem.Instance.IsPlayerTurn()) ||
        (!IsEnemy() && TurnSystem.Instance.IsPlayerTurn()))
        {

        actionPoints = ACTION_POINTS_MAX;
        OnAnyActionPointsChanged?.Invoke(this, EventArgs.Empty);
        }
   }
   public bool IsEnemy()
   {
    return isEnemy;
   }

   public void Damage(int damageAmount)
   {
    //Debug.Log(transform + " damage");
    healthSystem.Damage(damageAmount);
   }
   private void HealthSystem_OnDead(object sender, EventArgs e)
   {
        LevelGrid.Instance.RemoveUnitAtGridPosition(gridPosition, this);
        Destroy(gameObject);

        OnAnyUnitDead?.Invoke(this, EventArgs.Empty);
   }
   public float GetHealthNormalized()
   {
        return healthSystem.GetHealthNormallized();
   }
}
