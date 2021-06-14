using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    public GameObject exlposion;
    public GameObject playerExplosion;

    public int scoreValue;
    private GameController gameController;//script

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindWithTag("GameController");
        if(go != null)
        {
            gameController = go.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("找不到tag为GameController的对象");
        }

        if(gameController==null)
        {
            Debug.Log("找不到脚本GameController.cs");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //print(other.name);
        if(other.tag == "Boundary")
        {
            return;
        }

        gameController.AddScore(scoreValue);

        Instantiate(exlposion, transform.position, transform.rotation);
        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);

    }
}
