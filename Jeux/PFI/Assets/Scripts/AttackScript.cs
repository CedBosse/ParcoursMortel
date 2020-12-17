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
            Vector3 direction = (targetPosition.position - transform.position);
            hitSound.Play(); ;
            ennemyHp.TakeDamage(damage);
            rb.AddRelativeForce(direction * 500);
            gameObject.SetActive(false);
        }
    }
}
