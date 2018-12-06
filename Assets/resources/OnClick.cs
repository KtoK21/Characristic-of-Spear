using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour {

    public Gene_Manager gene_manager;
    public int index;

    public void OnMotionClick()
    {
        if (gene_manager.count < 4)
        {
            gene_manager.Gene_pick[gene_manager.count] = index;
            gene_manager.count++;
        }
        else
        {
            Debug.Log("click more than 4 motions");
        }
        
    }
}
