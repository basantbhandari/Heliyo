using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    bool add_force;
    public GameObject splash_ball;
    public float force;
    int score = 0;
    public Text score_txt;

    int highscore;
    public Text highscore_txt;
    public GameObject gameOverMenu;

    private void Start()
    {
        add_force = true;
        highscore_txt.text = "highscore: " + PlayerPrefs.GetInt("highscore");
    }

    //when ball collide to other object
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "h_peice" && add_force) {

            add_force = false;
            Invoke("fix_bounce", 0.2f);
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 1f, 0f) * Time.deltaTime * force);

            GameObject splash = Instantiate(splash_ball);
            Vector3 pos = transform.position;
            pos.y = pos.y-0.06f;
            splash.transform.position = pos;


            splash.transform.SetParent(GameObject.Find("helix").transform);


        } else if (collision.gameObject.tag == "gameover") {

            gameOverMenu.SetActive(true);
            //stop music and destroy scene

        }


    }

    void fix_bounce() {
        add_force = true;
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "score")
        {

            highscore = PlayerPrefs.GetInt("highscore");
            score++;
            if (score > highscore) {

                highscore = score;
                PlayerPrefs.SetInt("highscore", highscore);
                highscore_txt.text = "highscore: " + PlayerPrefs.GetInt("highscore");

            }
            score_txt.text = "score: "+score ;
           
        }
    }

    private void Update(){
        if (transform.position.y + 1.20f < Camera.main.transform.position.y) {

            Vector3 pos = Camera.main.transform.position;
            pos.y = transform.position.y+ 1.20f;
            Camera.main.transform.position = pos;
        }
    }


  


}
