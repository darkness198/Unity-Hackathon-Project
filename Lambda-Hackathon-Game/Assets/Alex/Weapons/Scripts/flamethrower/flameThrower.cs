using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameThrower : MonoBehaviour {

    [SerializeField]
    private GameObject flames;
	

	void Update () {
        if (Input.GetMouseButtonDown(0))
            flames.SetActive(true);

        if (Input.GetMouseButtonUp(0))
            flames.SetActive(false);
    }

}
