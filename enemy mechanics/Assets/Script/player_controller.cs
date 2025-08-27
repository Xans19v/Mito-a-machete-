using UnityEngine;

public class player_controller : MonoBehaviour
{
    [SerializeField] private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward*Time.deltaTime*speed*vertical);
        transform.Translate(Vector3.right*Time.deltaTime*speed*horizontal); 
    }
}
