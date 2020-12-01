using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float damage = 2f;
    public float radius = 1f;
    public LayerMask layerMask;
    private Damageable ennemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layerMask);

        if(hits.Length > 0)
        {

            print("We touched: " + hits[0].gameObject.tag);
            ennemyHealth = hits[0].transform.gameObject.GetComponentInChildren<Damageable>();
            ennemyHealth.InflictDamage(7.142857142857143f, false, this.transform.gameObject);
            //hits[0].gameObject.SetActive(false);
        }
    }
}
