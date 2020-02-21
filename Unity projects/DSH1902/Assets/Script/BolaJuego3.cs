using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolaJuego3 : MonoBehaviour
{
    public float fuerza;
    public Camera cameraSphere;
    private Vector3 offset;
    private Rigidbody rb;
    private int diamondNumber;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hi, Willy!");
        rb = GetComponent<Rigidbody>();
        offset = cameraSphere.transform.position;
        diamondNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float mh = Input.GetAxis("Horizontal"),
        mv = Input.GetAxis("Vertical");

        Vector3 mov = new Vector3(mv, 0, mh);
        rb.AddForce(mov * fuerza);

        cameraSphere.transform.position = this.transform.position + offset;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Wall"))
            SceneManager.LoadScene("Scenes/scene3", LoadSceneMode.Single);

        if (other.gameObject.CompareTag("Diamond"))
        {
            other.gameObject.SetActive(false);
            diamondNumber++;
        }

        if(diamondNumber == 6)
            SceneManager.LoadScene("Scenes/scene1", LoadSceneMode.Single);
    }
}
