using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float damage = 2f;
    public float radius = 1f;
    public LayerMask layerMask;
    public AudioSource hitSound;
    [SerializeField] EnemyHealth ennemyHp;
    private Rigidbody rb;
    [SerializeField] private Transform targetPosition;
    private float force = 250;

    private void Awake()
    {
        rb = targetPosition.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layerMask);

        if(hits.Length > 0)
        {
            hitSound.Play(); ;

            if (rb.rotation.y < 0)
            {
                rb.AddForce(-force, 150, 0, ForceMode.Impulse);
            }               
            else
                rb.AddForce(force, 150, 0, ForceMode.Impulse);
           
            ennemyHp.TakeDamage(damage);          
            gameObject.SetActive(false);
        }
    }
}
