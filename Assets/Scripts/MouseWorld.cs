using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    [SerializeField] private LayerMask mousePlaneLayerMask;
     private static MouseWorld instance;
    // Start is called before the first frame update
    private void Awake() {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
   
    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.GetMouseScreenPosition());
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask );
        return raycastHit.point;
    }
}
