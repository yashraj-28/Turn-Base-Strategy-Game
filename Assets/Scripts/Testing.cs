using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
  
  [SerializeField] private Unit unit;
     // Start is called before the first frame update
    void Start()
    {
      
        //Debug.Log(new GridPosition(5,7));
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gridSystem.GetGridPosition(MouseWorld.GetPosition()));
        /*if(Input.GetKeyDown(KeyCode.T))
        {
            GridSystemVisual.Instance.HideAllGridPosition();
            GridSystemVisual.Instance.ShowGridPositionList
            (
                unit.GetMoveAction().GetValidActionGridPositionList()
            );
        }*/

        /*if(Input.GetKeyDown(KeyCode.T)){
            GridPosition mousegridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.GetPosition());
            GridPosition startgridPosition = new GridPosition(0,0);

            List<GridPosition> gridPositionList = PathFinding.Instance.FindPath(startgridPosition, mousegridPosition, out int pathLength);

            for (int i = 0; i < gridPositionList.Count - 1; i++)
            {
                Debug.DrawLine(
                    LevelGrid.Instance.GetWorldPosition(gridPositionList[i]),
                    LevelGrid.Instance.GetWorldPosition(gridPositionList[i + 1]),
                    Color.white,
                    10f
                );
            }
        }*/
        if(Input.GetKeyDown(KeyCode.T)){
            
        }

    }
}
