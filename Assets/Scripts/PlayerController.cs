using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float powerLevel;
    public Text countText;

    private Rigidbody rb;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
    }

    // 物理演算を呼び出す直前に実行される
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * powerLevel);
    }

    void OnCollisionExit(Collision other)
    {
        if (!other.gameObject.CompareTag("PickUp"))
            return;
        other.gameObject.SetActive(false);
        count += 1;
        setCountText();
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
