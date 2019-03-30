using UnityEngine;
using System.Collections;

public class HeroControllSC : MonoBehaviour {
    public float MaxSpeed = 5f; //максимальная скорость персонажа
    private bool isFacingRight = true;//переменная для определения направления персонажа вправо/влево
    private Animator anim;//ссылка на компонент анимаций
                          
    private bool isGrounded = false;    //находится ли персонаж на земле или в прыжке?
    public Transform groundCheck; //ссылка на компонент Transform объекта для определения соприкосновения с землей
    private float groundRadius = 0.2f;//радиус определения соприкосновения с землей
    public LayerMask whatIsGround;  //ссылка на слой, представляющий землю
    CloseWind cw = new CloseWind(); //отвечает за отображение меню
    //private float vScrollbarValue;  //скрол для отображения заряда оружия
    void OnGUI()
    {
        //vScrollbarValue = GUI.VerticalScrollbar(new Rect(transform.position.x+15, transform.position.y+5, 100, 30), vScrollbarValue, 1.0f, 10.0f, 0.0f);
    }
    /// <summary>
    /// Начальная инициализация
    /// </summary>
    void Start ()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        //если нажата пауза
        if (Input.GetKeyDown(KeyCode.Pause))
            cw.pause();

        //если персонаж на земле и нажат пробел...
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            //устанавливаем в аниматоре переменную в false
            anim.SetBool("Ground", false);
            //прикладываем силу вверх, чтобы персонаж подпрыгнул
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
        }
    }
    /// <summary>
    /// Выполняем действия в методе FixedUpdate, т. к. в компоненте Animator персонажа
    /// выставлено значение Animate Physics = true и анимация синхронизируется с расчетами физики
    /// </summary>
    private void FixedUpdate()
    {
        //определяем, на земле ли персонаж
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //устанавливаем соответствующую переменную в аниматоре
        anim.SetBool("Ground", isGrounded);
        //устанавливаем в аниматоре значение скорости взлета/падения
        anim.SetFloat("JSpeed", GetComponent<Rigidbody2D>().velocity.y);
        //если персонаж в прыжке - выход из метода, чтобы не выполнялись действия, связанные с бегом
        if (!isGrounded)
            return;

        //используем Input.GetAxis для оси Х. метод возвращает значение оси в пределах от -1 до 1.
        //при стандартных настройках проекта 
        //-1 возвращается при нажатии на клавиатуре стрелки влево (или клавиши А),
        //1 возвращается при нажатии на клавиатуре стрелки вправо (или клавиши D)
        float move = Input.GetAxis("Horizontal");

        //в компоненте анимаций изменяем значение параметра Speed на значение оси Х.
        //приэтом нам нужен модуль значения
        anim.SetFloat("Speed", Mathf.Abs(move));

        //обращаемся к компоненту персонажа RigidBody2D. задаем ему скорость по оси Х, 
        //равную значению оси Х умноженное на значение макс. скорости
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * MaxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        //если нажали клавишу для перемещения вправо, а персонаж направлен влево
        if (move > 0 && !isFacingRight)
            //отражаем персонажа вправо
            Flip();
        //обратная ситуация. отражаем персонажа влево
        else if (move < 0 && isFacingRight)
            Flip();
    }
    /// <summary>
    /// Метод для смены направления движения персонажа и его зеркального отражения
    /// </summary>
    private void Flip()
    {
        //меняем направление движения персонажа
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }
}

