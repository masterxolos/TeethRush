using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DG.Tweening;
using UnityEngine;

public class ToothManager : MonoBehaviour
{
    public GameObject[] teeth = new GameObject[40];
    public  GameObject[] damakdakiDislerArray = new GameObject[15];
    public int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Jump()
    {
        int i = 0;
        while (i <= count - 1 && teeth[i] != null)
        {
            if(teeth[i].GetComponent<NodeMovement>() != null)
                teeth[i].GetComponent<NodeMovement>().enabled = false;
            else if(teeth[i].GetComponent<NewMovement>() != null)
                teeth[i].GetComponent<NewMovement>().enabled = false;
            i++;
        }

        i = 0;
        while (i <= count - 1 && teeth[i] != null)
        {
            teeth[i].GetComponent<Animator>().enabled = false;
            teeth[i].transform.DOMove(damakdakiDislerArray[i].transform.position, 0.3f);
            
            //todo eskiden gözükmüyo diye büyütüyoduk
            //_manager.teeth[i].transform.DOScale(0, 0.2f);
            
            yield return new WaitForSeconds(0.2f);
            damakdakiDislerArray[i].SetActive(true);
            Destroy(teeth[i]);
            i++;
            yield return new WaitForSeconds(0.15f);
            Debug.Log(i + "silindi");
        }
    }
}
