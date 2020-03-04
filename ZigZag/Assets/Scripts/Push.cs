using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Push : MonoBehaviour
{
    private int toShow;
    private bool count;
    private Button theButton;
    private Image myImage;
    public Sprite imageOne, 
    imageTwo, imageThree;
    private float myDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        count = false;
        theButton = GetComponent<Button>();
        myImage = GetComponent<Image>();
        toShow = 3;
        theButton.onClick.AddListener(ButtonPushed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ButtonPushed()
    {
        count = true;
    }

    private void FixedUpdate() 
    {
        if(count)
        {
            switch(toShow)
            {
                case 0:
                    SceneManager.LoadScene("Game", LoadSceneMode.Single);
                    break;
                case 1:
                    myImage.sprite = imageOne;
                    break;
                case 2:
                    myImage.sprite = imageTwo;
                    break;
                case 3: 
                    myImage.sprite = imageThree;
                    break;
            }
            StartCoroutine(Wait());
            toShow--;
            count = false;
            Debug.Log(count);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(myDelay);
        count = true;
    }
}
