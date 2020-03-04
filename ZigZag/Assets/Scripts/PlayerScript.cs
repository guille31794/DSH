using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    private Vector3 dir;
    public GameObject ps, points;
    private bool isDead;
    public GameObject reset;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        dir = Vector3.zero;
        speed = 15;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isDead)
            if(dir == Vector3.forward)
                dir = Vector3.left;
            else
                dir = Vector3.forward;

        float amountToMove = speed * Time.deltaTime;

        transform.Translate(dir * amountToMove);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            Instantiate(ps, transform.position, Quaternion.identity);
            ++score;
            //points.text = "Score: " + score;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Tile")
        {
            RaycastHit hit;
            Ray downRay = new Ray(transform.position, -Vector3.up);

            if(!Physics.Raycast(downRay, out hit))
            {
                // Kill Player
                isDead = true;

                if(transform.childCount > 0)
                    transform.GetChild(0).transform.parent = null;
                    
                reset.SetActive(true);
            }
        }
    }
}
