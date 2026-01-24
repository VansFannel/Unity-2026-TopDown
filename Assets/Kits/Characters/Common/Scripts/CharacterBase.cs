using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [SerializeField] float linearSpeed = 0.0f;

    Rigidbody2D rb2D;

    protected virtual void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {

    }

    protected void Move(Vector2 direction)
    {
        rb2D.position += direction * linearSpeed * Time.deltaTime;
    }
}
