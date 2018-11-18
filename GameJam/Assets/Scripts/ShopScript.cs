using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour {

    public int lvl;
    public int price=5000;
    public GameObject fastOption;
    private bool trigger = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        trigger = true;
      Instantiate(fastOption, new Vector2(this.gameObject.transform.position.x - this.gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2,
          this.gameObject.transform.position.y + this.gameObject.GetComponent<SpriteRenderer>().bounds.size.y), Quaternion.identity);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        trigger = false;
        Destroy(GameObject.Find("FastOption(Clone)"));
    }
    private void Update()
    {
        if (trigger)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                switch (gameObject.name)
                {
                    case "Drill":
                        GameObject.Find("GameController").GetComponent<GameController>().drillLVL = lvl;
                        break;
                    case "TNT":
                        GameObject.Find("GameController").GetComponent<GameController>().tntLVL = lvl;
                        break;
                    case "Gun":
                        GameObject.Find("GameController").GetComponent<GameController>().gunLVL = lvl;
                        break;
                    case "Rope":
                        GameObject.Find("GameController").GetComponent<GameController>().ropeLVL = lvl;
                        break;
                    case "Bag":
                        GameObject.Find("GameController").GetComponent<GameController>().bagLVL = lvl;
                        break;
                    case "Cameq":
                        GameObject.Find("GameController").GetComponent<GameController>().cameqLVL = lvl;
                        break;


                }
                GameObject.Find("CashController").GetComponent<CashController>().AddCash(-price);
                Destroy(gameObject);
            }
        }
    }
}
