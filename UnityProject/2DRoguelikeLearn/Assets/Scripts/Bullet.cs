using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit = collision.collider.gameObject;
        Debug.Log("hit tag" + hit.tag);
        Health health = hit.GetComponent<Health>();

        if(health != null)
        {
            health.TakeDamage(20);
        }
        Destroy(this.gameObject);
    }
}
