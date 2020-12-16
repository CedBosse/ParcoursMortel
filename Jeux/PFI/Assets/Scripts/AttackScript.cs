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

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layerMask);

        if(hits.Length > 0)
        {
            hitSound.Play(); ;
            Debug.Log("We touched " + hits[0].gameObject.tag);
            ennemyHp.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
