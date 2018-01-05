using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] trees;

    [SerializeField]
    private GameObject treeCollider;

    [SerializeField]
    private GameObject fireSound;


   [SerializeField]
    private GameObject[] treeFire;

    private int whichTree;
    private bool treeAlive;

    void Start()
    {
        
        whichTree = Random.Range(0, trees.Length);
        Debug.Log(whichTree);
        trees[whichTree].SetActive(true);
        treeCollider.SetActive(true);
        treeAlive = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Flame Collider" && treeAlive)
        {
            treeFire[whichTree].SetActive(true);
            fireSound.SetActive(true);
            StartCoroutine(WaitAndRegrow());
            Debug.Log("On fire");
        }
    }

    //


    private IEnumerator WaitAndRegrow()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            trees[whichTree].SetActive(false);
            treeFire[whichTree].SetActive(false);
            fireSound.SetActive(false);
            treeCollider.SetActive(false);
            treeAlive = false;
            yield return new WaitForSeconds(60);
            whichTree = Random.Range(0, trees.Length);
            Debug.Log(whichTree);
            trees[whichTree].SetActive(true);
            treeCollider.SetActive(true);
            treeAlive = true;
        }

    }
}
//when collided with flame
//catch fire
//turn on fire sound
//burn for 20 seconds
//disapear
//grow back after 60 seconds

    //explode when shoot several times
    //explode when bomb goes off nearby
