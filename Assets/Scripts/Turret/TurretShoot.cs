using UnityEngine;

public class TurretShoot : MonoBehaviour {

    public GameObject Turret;
    public GameObject Barrel;

    public ParticleSystem Flash;

    public float damage = 10f;
    public float range = 100f;
    int EnemyLayer = 1 << 8;

    public float timerDelay = 5f;
    protected float timer;

  
    void Start()
    {
        timer = timerDelay;
    }

    // Update is called once per frame
    void Update () {
        Lock();


    }

    void Shoot()
    {
        if (timer <= 0) {
            RaycastHit hit;
            if (Physics.Raycast(Barrel.transform.position, Turret.GetComponent<LockOnTarget>().direction, out hit, range, EnemyLayer))
            {
                //Debug.Log(Barrel.transform.position);
                Flash.Play();
                Debug.Log(hit.transform.name);
                Debug.DrawRay(Barrel.transform.position, Turret.GetComponent<LockOnTarget>().direction, Color.green, 2, false);

                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                if (target != null && target.tag == "Enemy")
                {
                    target.TakeDamage(damage);
                    if (target.health <= 0)
                    {
                        Turret.GetComponent<LockOnTarget>().lockedOn = false;
                    }
                    else if (target.tag != "Enemy")
                    {
                        Turret.GetComponent<LockOnTarget>().lockedOn = false;
                    }
                }
                
            }
            timer = timerDelay;
        }
    }

    void Lock()
    {
        timer = timer - Time.deltaTime;

        if (Turret.GetComponent<LockOnTarget>().lockedOn)
        {
            Shoot();
        }

        if (!Turret.GetComponent<LockOnTarget>().lockedOn)
        {
            Flash.Stop();
        }

    }
}
