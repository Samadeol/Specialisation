using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform Player;
    void Start()
    {
        
    }
    void Update()
    {
        if(Player.position.y > transform.position.y){
            transform.position=new Vector3(transform.position.x,Player.position.y,transform.position.z);
        }
    }
}
