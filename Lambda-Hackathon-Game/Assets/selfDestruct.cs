using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruct : MonoBehaviour
{
  public float delay = 5.0f;
  float countdown;
  bool hasExploded = false;

  public float radius = 4.0f;
  public float force = 600f;

  public GameObject explosionEffect;

  // Use this for initialization
  void Start()
  {
    countdown = delay;

  }

  // Update is called once per frame
  void Update()
  {
    countdown -= Time.deltaTime;
    if (countdown <= 0f && !hasExploded)
    {
      Explode();
      hasExploded = true;
    }
  }
  void Explode()
  {
    GameObject expEff = Instantiate(explosionEffect, transform.position, transform.rotation);
    Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

    foreach (Collider nearbyObj in colliders)
    {
      Rigidbody rb = nearbyObj.GetComponent<Rigidbody>();
      if (rb != null)
      {
        rb.AddExplosionForce(force, transform.position, radius);
      }
    }
    Destroy(this.gameObject);
    Destroy(expEff, 1.0f);
  }
}
