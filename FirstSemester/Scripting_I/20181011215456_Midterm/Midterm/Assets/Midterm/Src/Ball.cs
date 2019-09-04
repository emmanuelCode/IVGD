using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Camera ballCam;
    public int healthPoints = 10;
    public float strength = 10f;

    private Dictionary<string, int> inventory;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.inventory = new Dictionary<string, int>();

        this.SetupInventory();
    }

    void SetupInventory()
    {
        this.inventory.Add("HealthPotions", 0);
        this.inventory.Add("Keys", 0);
        this.inventory.Add("Coins", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //YOU'VE INVERSE THE VECTORS TO CONFUSE US !!! FIXED !!
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.rb.AddTorque(Vector3.back * this.strength);//testing something 
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.rb.AddTorque(Vector3.forward * this.strength);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.rb.AddTorque(Vector3.right * this.strength);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.rb.AddTorque(Vector3.left * this.strength);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rb.AddForce(Vector3.up * this.strength, ForceMode.Impulse);
        }

// Press Enter to consume a health potion //DONE
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            ConsumeHealthPotion();
        }


// Press I to print your inventory //DONE

        if (Input.GetKey(KeyCode.I))
        {
            PrintInventory();
        }

        //player die if no heathpoints
        if (this.healthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void PrintInventory()
    {
        string output = "You have: ";

        for (int i = 0; i < inventory.Count; i++ /* TODO fill in for loop here */)
        {
            string key = "";

            if (i == 0)
            {
                key = "HealthPotions";
            }
            else if (i == 1)
            {
                key = "Keys"; // TYPO HERE "s"
            }
            else if (i == 2)
            {
                key = "Coins";
            }

            // TODO fill output variable with inventory items
            output += key + " " + inventory[key] + ","; //DONE
        }

        print(output);
    }


    void ConsumeHealthPotion()
    {
        if (this.inventory["HealthPotions"] > 0)
        {
            // TODO remove a health potion and add 5 health //DONE
            this.inventory["HealthPotions"] -= 1;
            healthPoints += 5;


            // Health should never be above 10 points  //DONE
            if (healthPoints >= 10) //> or >= ???
            {

                healthPoints = 10;
            }



        }
    }


    public void KeyAquired()
    {
        this.inventory["Keys"] = this.inventory["Keys"] + 1; //typo here "s"
    }


    public void CoinAquired()
    {
        this.inventory["Coins"] = this.inventory["Coins"] + 1;
    }

    public void HealthPotionAquired()
    {
        this.inventory["HealthPotions"] = this.inventory["HealthPotions"] + 1;
    }

    public bool HasKey()
    {
        // Return true if the ball has a key in the inventory

        return this.inventory["Keys"] == 1; //TO TEST but done
    }

    public void ConsumeKey()
    {
        if (this.inventory["Keys"] > 0)
        {
            // Subtract 1 key

            this.inventory["Keys"] -= 1; // DONE
        }
    }


}