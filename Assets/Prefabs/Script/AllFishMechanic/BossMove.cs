using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    [SerializeField] Transform fish;
    Rigidbody2D rg;
    [SerializeField] Boss boss;
    RectTransform rect;
    public bool inRange;
    
    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        rg = GetComponent<Rigidbody2D>();
        rect = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, fish.position);
        if (distance <= StaticClass.Boss_maxRange && distance > StaticClass.Boss_minRange && !boss.isDed)
        {
            inRange = true;
            transform.position = Vector3.MoveTowards(transform.position, fish.position, StaticClass.Boss_speed * Time.deltaTime);
            rg.velocity = new Vector2(0, rg.velocity.y);

            if (transform.position.x - fish.position.x < 0)
                rect.rotation = Quaternion.Euler(0f, 180f, 0f);
            else
                rect.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
            inRange = false;
    }
}
