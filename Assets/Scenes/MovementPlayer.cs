using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public Rigidbody rb; // модификатор доступа и тип переменной отсюда можно брать методы 

    // модификатор паблик появляется в юнити и им можно напрямую управлять через инспектор
    public float strafeSpeed = 500f; // переменная (задается public) типа флоат обозначает движения вправо и влево
    public float runSpeed = 500f; // скорость бега 
    public float jumpForce = 15; // сила прыжка

    protected bool strafeLeft = false;
    protected bool strafeRight = false;
    protected bool doJump = false;

    // Update вызывается один раз за кадр
    void Update()
    {
        if (Input.GetKey("a")) // если нажимается кнопка а, то делаем шаг налево 
        {
            strafeLeft = true;
        }
        else
        {
            strafeLeft = false;
        }

        if (Input.GetKey("d")) // если нажимаем кнопку d, то делаем шаг направо
        {
            strafeRight = true;
        }
        else
        {
            strafeRight = false;
        }

        if (Input.GetKeyDown("space")) // если нажимаем пробел, то прыжок
        {
            doJump = true;
        }

        if(transform.position.y < -5F)
        {
            Debug.log("Game over")// жто будетдавать консоль при падание куба за пределы своей трассы
        }
    }

void OnVollisionEnter(Collision collision)//функция при помощи которой заканчивается игра при столкновении. но не стоит забывать дать каждому припятсвюю в юнити тэш obstacle
{
    if(collision.collider.tag == "Obstacle")
    {
        Debug.log("looooooser")
    }
}

    // FixedUpdate вызывается на каждом шаге физического движка
    void FixedUpdate()
    {
        // rb.AddForce(0, 0, runSpeed * Time.deltaTime);  // это бег// толчок по оси зед, толчок на мощность 500

        rb.MovePosition(transform.position + Vector3.forward + runSpeed * Time.deltaTime)// transform.position + Vector3.forwardэто такущая позиция + вперед

        if (strafeLeft) 
        {
        rb.addForce(-strafeSpeed * Time.deltaTime.0, 0, forceMode.VelocityChange); // нажимая на кнопку идет влево, функционал
        }
          if (strafeRight) 
        {
        rb.addForce(strafeSpeed * Time.deltaTime.0, 0, forceMode.VelocityChange);
        }
          if (doJump) 
        {
        rb.addForce(Vector3.up *jumpForce, ForceMode.Impulse);

        doJump = false;
        }
    }
}
