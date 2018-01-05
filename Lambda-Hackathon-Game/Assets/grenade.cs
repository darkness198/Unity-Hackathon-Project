using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class grenade : MonoBehaviour
{
  public Rigidbody grenadeObj;
  public float kick = 400f;

  void throwGrenade()
  {
    Rigidbody grenadeClone = (Rigidbody)Instantiate(grenadeObj, transform.position, transform.rotation);
    grenadeClone.AddForce(0, 300f, kick);
  }
  void Update()
  {
    if (Input.GetMouseButtonDown(1))
    {
      throwGrenade();
    }
  }
}