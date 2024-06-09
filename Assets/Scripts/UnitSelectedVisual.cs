using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] private Unit unit; 
    private MeshRenderer meshRenderer;

    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedChange;

        UpdateVisual();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UnitActionSystem_OnSelectedChange( object sender, EventArgs empty)
    {
        UpdateVisual();
    }
    private void UpdateVisual()
    {

        if(UnitActionSystem.Instance.GetSelectedUnit() == unit){
            meshRenderer.enabled = true;
        }else{
            meshRenderer.enabled = false;
        }
    }
    private void OnDestroy() {
        UnitActionSystem.Instance.OnSelectedUnitChanged -= UnitActionSystem_OnSelectedChange;
    }
}
