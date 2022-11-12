using UnityEngine;

public class AimTrainer : MonoBehaviour
{
    public int targetsLeft;
    float timeSinceSpawn = 0f;
    float score;
    public bool aimTrainerOn = false;

    public GameObject target;

    Vector3 targetPos;

    void Update()
    {
        if (aimTrainerOn && targetsLeft < 30)
        {
            timeSinceSpawn += Time.deltaTime;
        }
    }

    public void BeginAimTrainer()
    {
        targetsLeft = 30;
        score = 0f;
        aimTrainerOn = true;
        targetPos = new Vector3(Random.Range(20f, 30f), Random.Range(5.5f, 0.5f), 39.75f);
        GameObject currentTarget = Instantiate(target, targetPos, target.transform.rotation);
        currentTarget.transform.parent = gameObject.transform;
    }

    public void TargetHit()
    {
        score += 100 - (timeSinceSpawn * 25);
        targetsLeft -= 1;
        Destroy(transform.GetChild(2).gameObject);
        if (targetsLeft < 1)
        {
            QuitAimTrainer();
        } else if (targetsLeft > 0)
        {
            targetPos = new Vector3(Random.Range(20f, 30f), Random.Range(5.5f, 0.5f), 39.75f);
            GameObject currentTarget = Instantiate(target, targetPos, target.transform.rotation);
            currentTarget.transform.parent = gameObject.transform;
            timeSinceSpawn = 0f;
        }
    }

    public void QuitAimTrainer()
    {
        aimTrainerOn = false;
        for (int i = transform.childCount; i > 2; i--)
        {
            Destroy(transform.GetChild(2).gameObject);
        }
        targetsLeft = 0;
        Debug.Log(Mathf.RoundToInt(score));
    }
}
