using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera fpsCam;
    public LayerMask mask;
    public ParticleSystem muzzleFlash;
    public Transform Aimtrainer;

    public float damage = 10f;
    public float range = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }
    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, mask))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            AimTrainer aimtrainerScript = hit.transform.GetComponentInParent<AimTrainer>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            else if (aimtrainerScript != null && hit.transform.tag == "AimTrainerStartButton")
            {
                if (aimtrainerScript.aimTrainerOn == true)
                {
                    aimtrainerScript.QuitAimTrainer();
                }
                else if (aimtrainerScript.aimTrainerOn == false)
                {
                    aimtrainerScript.BeginAimTrainer();
                }
            }
            else if (hit.transform.tag == "Target")
            {
                if (hit.transform.GetComponentInParent<AimTrainer>() != null)
                {
                    hit.transform.GetComponentInParent<AimTrainer>().TargetHit();
                }
            }
        }
    }
}