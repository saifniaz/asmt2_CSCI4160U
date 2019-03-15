using UnityEngine;
using UnityEngine.UI;

public class playerControll : MonoBehaviour
{
    public float speed = 2f;
    public float rotSpeed = 10f;
    public Camera fpsCamera;
    public Text text;

    int paintHit = 0;
    Rigidbody rigidbody;
    Vector3 m_EulerAngleVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, 100, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //transform.Rotate(0, y, 0);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z + speed);
        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z - speed);
        } else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime * -1);
            rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime * 1);
            rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            rigidbody.velocity = new Vector3(0,0,0);
        }else if (Input.GetKeyDown(KeyCode.Space)) {
            //Shoot
            Shoot();
        }
    }

    void Shoot() {
        RaycastHit hit;
        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit)) {
            Debug.Log(hit.transform.name);

            target t = hit.transform.GetComponent<target>();
            if(t != null) {
                paintHit++;
                text.text = "HIT : " + paintHit.ToString();
                t.takeDamage(10);
            }
        }
    }
}
