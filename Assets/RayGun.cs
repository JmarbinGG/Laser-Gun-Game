using System.Collections;
using UnityEngine;

public class RayGun : MonoBehaviour
{
    public float shootRate;
    private float m_shootRateTimeStamp;
    public Animation anim;
    public GameObject m_shotPrefab;
    public GameObject muzzle;
    public GameObject rotationPoint;
    public float magazine = 20f;
    float lasersLeft;

    RaycastHit hit;
    float range = 1000.0f;

    void Start()
    {
        lasersLeft = magazine;
        anim = rotationPoint.GetComponent<Animation>();
    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            if (Time.time > m_shootRateTimeStamp)
            {
                shootRay();
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }

    }

    void shootRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, range) && lasersLeft > 0)
        {
            GameObject laser = GameObject.Instantiate(m_shotPrefab, muzzle.transform.position, muzzle.transform.rotation) as GameObject;
            laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            GameObject.Destroy(laser, 2f);

            lasersLeft--;
            if(lasersLeft == 0)
            {
                anim.Play("Reloadinge");
                lasersLeft = magazine;
            }
        }

    }

    void reload()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.Play("Reloadinge");
            new WaitForSeconds(3f);
            lasersLeft = magazine;
        }
        
        

    }



}