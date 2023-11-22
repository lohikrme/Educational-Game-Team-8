using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrekController : MonoBehaviour
{
    public AudioSource audioPlayer;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider: " + other.gameObject.name);
        if(other.gameObject.name.Equals("PlayerArmature"))
        {
            audioPlayer.Play();
            transform.Translate(0,5,0);
        }
    }
}
