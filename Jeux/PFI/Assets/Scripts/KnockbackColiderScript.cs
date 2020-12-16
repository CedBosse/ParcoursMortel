using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackColiderScript : MonoBehaviour
{
    public float knockbackStrength;
    Rigidbody rb;

    private void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, 1f);
        if (hits.Length > 0)
        {
            rb = hits[0].transform.gameObject.GetComponentInChildren<Rigidbody>();
            if (rb != null)
            {
                if (rb.gameObject.tag == "Enemy")
                {
                    rb.AddForce(transform.right * knockbackStrength);
                }
            }
        }
    }
}
