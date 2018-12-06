using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapping : MonoBehaviour {

    public Gene_Manager gene_Manager;
    public GameObject rightHand;
    public GameObject leftHand;
    public int number;
    Vector3 rightStart;
    Vector3 leftStart;
    Vector3 rightEnd;
    Vector3 leftEnd;
    int L_start_y;
    int R_start_y;
    int L_end_y;
    int R_end_y;

   
    // Use this for initialization
    void Start () {
        
        L_start_y = gene_Manager.LGene[number].Hand_start_L;    
        R_start_y = gene_Manager.LGene[number].Hand_start_R; 
        L_end_y = gene_Manager.LGene[number].Hand_end_L; 
        R_end_y = gene_Manager.LGene[number].Hand_end_R;

       rightStart = new Vector3(0.251f, 0.6f+R_start_y*0.1f, -0.028f);

       leftStart = new Vector3(0.241f, 0.6f+L_start_y*0.1f, 0.398f);
       rightEnd = new Vector3(0.251f, 0.6f+R_end_y*0.1f, 0.317f);
       leftEnd = new Vector3(0.241f, 0.6f+L_end_y*0.1f, 0.743f);

        
        StartCoroutine(AnimateL());
        StartCoroutine(AnimateR());


    }

    public void refresh()
    {
        L_start_y = gene_Manager.LGene[number].Hand_start_L;
        R_start_y = gene_Manager.LGene[number].Hand_start_R;
        L_end_y = gene_Manager.LGene[number].Hand_end_L;
        R_end_y = gene_Manager.LGene[number].Hand_end_R;

        rightStart = new Vector3(0.251f, 0.6f + R_start_y * 0.1f, -0.028f);

        leftStart = new Vector3(0.241f, 0.6f + L_start_y * 0.1f, 0.398f);
        rightEnd = new Vector3(0.251f, 0.6f + R_end_y * 0.1f, 0.317f);
        leftEnd = new Vector3(0.241f, 0.6f + L_end_y * 0.1f, 0.743f);


        StartCoroutine(AnimateL());
        StartCoroutine(AnimateR());

    }

    // Update is called once per frame
    IEnumerator AnimateR() {
        rightHand.transform.localPosition = rightStart;
        while (Vector3.Distance(rightHand.transform.localPosition,rightEnd)>0.1f)
        {
            
            Debug.Log(Vector3.Distance(rightStart, rightEnd));
            rightHand.transform.localPosition = Vector3.MoveTowards(rightHand.transform.localPosition, rightEnd, Time.deltaTime);
            
            yield return null;

        }
        yield return StartCoroutine(ReAnimateR());
    }

    IEnumerator AnimateL()
    {
        leftHand.transform.localPosition = leftStart;
        while (Vector3.Distance(leftHand.transform.localPosition, leftEnd) > 0.1f)
        {
            Debug.Log(Vector3.Distance(rightStart, rightEnd));
            leftHand.transform.localPosition = Vector3.MoveTowards(leftHand.transform.localPosition, leftEnd, Time.deltaTime);

            yield return null;

        }
        yield return StartCoroutine(ReAnimateL());
    }

    IEnumerator ReAnimateL()
    {
        leftHand.transform.localPosition = leftEnd;
        while (Vector3.Distance(leftHand.transform.localPosition, leftStart) > 0.1f)
        {
            Debug.Log(Vector3.Distance(leftStart, leftEnd));
            leftHand.transform.localPosition = Vector3.MoveTowards(leftHand.transform.localPosition, leftStart, Time.deltaTime);

            yield return null;

        }
        yield return StartCoroutine(AnimateL());
    }

    IEnumerator ReAnimateR()
    {
        rightHand.transform.localPosition = rightEnd;
        while (Vector3.Distance(rightHand.transform.localPosition, rightStart) > 0.1f)
        {
            Debug.Log(Vector3.Distance(rightStart, rightEnd));
            rightHand.transform.localPosition = Vector3.MoveTowards(rightHand.transform.localPosition, rightStart, Time.deltaTime);

            yield return null;

        }
        yield return StartCoroutine(AnimateR());
    }
}
