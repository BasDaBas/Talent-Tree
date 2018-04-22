using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Fireball : MonoBehaviour {

    public GameObject fieryEffect;
    public GameObject smokeEffect;
    public GameObject explodeEffect;

    public float minDamage;
    public float maxDamage;

    

    protected Rigidbody rgbd;

    public void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
    }      

    public void OnCollisionEnter(Collision col)
    {
        rgbd.Sleep();
        if (fieryEffect != null)
        {
            StopParticleSystem(fieryEffect);
        }
        if (smokeEffect != null)
        {
            StopParticleSystem(smokeEffect);
        }
        if (explodeEffect != null)
            explodeEffect.SetActive(true);

        if (col.collider.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<CharacterStats>().TakeDamage(0);
        }
    }

    public void StopParticleSystem(GameObject g)
    {
        ParticleSystem[] par;
        par = g.GetComponentsInChildren<ParticleSystem>();
        foreach(ParticleSystem p in par)
        {
            p.Stop();
        }
    }

    public void OnEnable()
    {
        if (fieryEffect != null)
            fieryEffect.SetActive(true);
        if (smokeEffect != null)
            smokeEffect.SetActive(true);
        if (explodeEffect != null)
            explodeEffect.SetActive(false);
    }
}


