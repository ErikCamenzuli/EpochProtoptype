using UnityEngine;

public class GunScript : MonoBehaviour
{

    public float damage;
    public float range;
    public float gunFireRate;
    public Camera cam;

    private float nextShotTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextShotTime)
        {
            nextShotTime = Time.time + 1f / gunFireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.name);

            EnemyHP enemy = hitInfo.transform.GetComponent<EnemyHP>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
