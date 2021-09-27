using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class movement : MonoBehaviour
{
    public string currentColor;
    public float jumpForce=10f;
    public Rigidbody2D circle;
    public SpriteRenderer spriteRenderer;
    public GameObject obstacle;
    public GameObject colorChanger;
    public Color blue;
    public Color yellow;
    public Color pink;
    public Color purple;
    public static int score = 0;
    public Text ScoreText;
    public Text finaltext;
    bool gameover=false;
    bool yops=true;
    float time=0f;
    void Start()
    {
        finaltext.enabled=false;
        setRandomColor();
    }
    void Update()
    {
        if(!yops) time+=Time.deltaTime;
        if((Input.GetButtonDown("Jump")|| Input.GetMouseButtonDown(0) )&& !gameover){
            circle.velocity=Vector2.up*jumpForce;
        }
        if(time >3f){
            gameover=false; 
            score=0;
            time=0;
            yops=true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        }
        ScoreText.text=score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "ColorChanger"){
            setRandomColor();
            Destroy(collision.gameObject);
            Instantiate(colorChanger, new Vector2(transform.position.x,transform.position.y+8.3f),transform.rotation);
        }
        else if(collision.tag=="Scored"){
            score++;
            Destroy(collision.gameObject);
            Instantiate(obstacle,new Vector2(transform.position.x,transform.position.y+8.2f),transform.rotation);
            return;
        }
        else if(collision.tag!=currentColor){
            gameover=true;
            finaltext.enabled=true;
            yops=false;

        }
    }
    void setRandomColor(){
        int rand = Random.Range(0,4);
        switch(rand){
            case 0:
                currentColor="blue";
                spriteRenderer.color=blue;
                break;
            case 1:
                currentColor="yellow";
                spriteRenderer.color=yellow;
                break;
            case 2:
                currentColor="pink";
                spriteRenderer.color=pink;
                break;
            case 3:
                currentColor="purple";
                spriteRenderer.color=purple;
                break;
        }
    }
}
