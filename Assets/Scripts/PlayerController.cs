using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float powerLevel;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText(createCountText());
        setWinText("");
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
        setCountText(createCountText());
        if (count >= 12)
            setWinText("WIN!!");
    }

    void setCountText(string text)
    {
        countText.text = text;
    }
    void setWinText(string text)
    {
        winText.text = text;
    }

    string createCountText()
    {
        return "Count: " + count.ToString();
    }
}
