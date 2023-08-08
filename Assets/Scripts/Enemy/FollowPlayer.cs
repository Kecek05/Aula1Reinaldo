using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour
{
  
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed;


    private float distance;
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveEnemy();
    
    }


    private void MoveEnemy()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
       
    }

 
    private void hitPlayer()
    {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hitPlayer();
        }
    }











}
