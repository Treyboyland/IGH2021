using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    protected float speed;

    public void MoveLeft()
    {
        Vector3 delta = new Vector2();
        delta.x = -speed * Time.deltaTime;
        transform.position += delta;
    }

    public void MoveRight()
    {
        Vector3 delta = new Vector2();
        delta.x = speed * Time.deltaTime;
        transform.position += delta;
    }

    public void MoveUp()
    {
        Vector3 delta = new Vector2();
        delta.y = speed * Time.deltaTime;
        transform.position += delta;
    }

    public void MoveDown()
    {
        Vector3 delta = new Vector2();
        delta.y = -speed * Time.deltaTime;
        transform.position += delta;
    }

    public void Move(Vector2 inputAxes)
    {
        //Debug.LogWarning("Axes: " + inputAxes);
        Vector3 delta = new Vector3(inputAxes.x, inputAxes.y);
        delta.x *= speed * Time.deltaTime;
        delta.y *= speed * Time.deltaTime;
        transform.position += delta;
    }

    public void Move(Vector2 inputAxes, Rigidbody2D body)
    {
        //Debug.LogWarning("Axes: " + inputAxes);
        Vector3 delta = new Vector3(inputAxes.x, inputAxes.y);
        delta.x *= speed * Time.deltaTime;
        delta.y *= speed * Time.deltaTime;
        body.AddForce(delta, ForceMode2D.Impulse);
    }
}
