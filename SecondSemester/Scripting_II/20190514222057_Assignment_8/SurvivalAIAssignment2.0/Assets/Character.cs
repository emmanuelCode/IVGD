using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    GameEngine gameEngine;
   	enum eCharacterState
    {
        idle,
        aimingAtTarget,
        goingToTarget,
        pause,
        nbCharacterState,
        invalid
    }    

    [SerializeField]
    eCharacterState characterState;
    eCharacterState pausedState;

    [SerializeField]
    bool hasShovel;

    [SerializeField]
    Vector3 target;
    Timer stateTimer = new Timer();
    [SerializeField]
    float characterSpeed;

    public Vector3 deltaPos;
    Quaternion initialRotation;
    // Use this for initialization
    void Start ()
    {       
        hasShovel = false;
        gameEngine = GameObject.Find("GameEngine").GetComponent<GameEngine>();
		SetState (eCharacterState.idle);
	}

    void SetState(eCharacterState pState)
    {
        eCharacterState lastState = characterState;
        characterState = pState;
        switch(characterState)
        {
            case eCharacterState.idle:

                break;
            case eCharacterState.aimingAtTarget:
                initialRotation = transform.rotation;
                stateTimer.Set(1);
                break;
            case eCharacterState.goingToTarget:

                break;
            case eCharacterState.pause:
                if(lastState != eCharacterState.pause)
                    pausedState = lastState;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (characterState)
        {
            case eCharacterState.idle:

                break;
            case eCharacterState.aimingAtTarget:

                transform.rotation = Quaternion.Slerp(initialRotation, Quaternion.LookRotation(target - transform.position), stateTimer.Ratio);
                if (stateTimer.Ratio >= 1.0f)
                {
                    SetState(eCharacterState.goingToTarget);
                }
                break;
            case eCharacterState.goingToTarget:
                {
                    deltaPos = target - transform.position;
                    transform.Translate(deltaPos.normalized * Mathf.Min(characterSpeed * Time.deltaTime, deltaPos.magnitude), Space.World);
                    if (Vector3.Distance(transform.position, target) < 0.05f)
                    {
                        SetState(eCharacterState.idle);
                        SendMessage("OnDestinationReached");
                    }
                }
                break;
        }

/*        if (Input.GetKeyDown(KeyCode.A))
            SetPause(true);

        if (Input.GetKeyDown(KeyCode.S))
            SetPause(false);*/
    }

    public void SetPause(bool value)
    {
        if(value)
        {
            SetState(eCharacterState.pause);
        }
        else
        {
            characterState = pausedState;
        }
    }

    public void GotoPos(Vector3 pPos)
    {   
        gameEngine.SetAchievementScore("2 - Make the character move 1pt", 1);

        GameObject firstCoin = GameObject.FindGameObjectWithTag("Coin");
        GameObject firstHealthpack = GameObject.FindGameObjectWithTag("HealthPack");
        GameObject firstShovel = GameObject.FindGameObjectWithTag("Shovel");
        GameObject firstDiggingArea = GameObject.FindGameObjectWithTag("DiggingArea");

        if(firstCoin != null && firstCoin.transform.position == pPos)
        {
            gameEngine.SetAchievementScore("3 - Target One Coin 1pt", 1);
        }
        else if (firstHealthpack != null && firstHealthpack.transform.position == pPos)
        {
            gameEngine.SetAchievementScore("4 - Target One Healthpack 1pt", 1);
        }
        else if (firstShovel != null && firstShovel.transform.position == pPos)
        {
            gameEngine.SetAchievementScore("5 - Target One Shovel 1pt", 1);
        }
        else if (firstDiggingArea != null && firstDiggingArea.transform.position == pPos)
        {
            gameEngine.SetAchievementScore("6 - Target One Digging Area 1pt", 1);
        }
        else
        {
            GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
            GameObject[] healthpacks = GameObject.FindGameObjectsWithTag("HealthPack");
            GameObject[] shovels = GameObject.FindGameObjectsWithTag("Shovel");
            GameObject[] diggingAreas = GameObject.FindGameObjectsWithTag("DiggingArea");

            if (coins.Length > 0)
            {
                foreach (GameObject coin in coins)
                {
                    if (coin.transform.position == pPos)
                    {
                        gameEngine.SetAchievementScore("8 - Do not just rely on FindObjectWithTag 1pt", 1);
                        gameEngine.SetAchievementScore("3 - Target One Coin 1pt", 1);
                    }
                }
            }
            if (healthpacks.Length > 0)
            {
                foreach (GameObject healthpack in healthpacks)
                {
                    if (healthpack.transform.position == pPos)
                    {
                        gameEngine.SetAchievementScore("8 - Do not just rely on FindObjectWithTag 1pt", 1);
                        gameEngine.SetAchievementScore("4 - Target One Healthpack 1pt", 1);
                    }
                }
            }
            if (coins.Length > 0)
            {
                foreach (GameObject shovel in shovels)
                {
                    if (shovel.transform.position == pPos)
                    {
                        gameEngine.SetAchievementScore("8 - Do not just rely on FindObjectWithTag 1pt", 1);
                        gameEngine.SetAchievementScore("5 - Target One Shovel 1pt", 1);
                    }
                }
            }
            if (coins.Length > 0)
            {
                foreach (GameObject diggingArea in diggingAreas)
                {
                    if (diggingArea.transform.position == pPos)
                    {
                        gameEngine.SetAchievementScore("8 - Do not just rely on FindObjectWithTag 1pt", 1);
                        gameEngine.SetAchievementScore("6 - Target One Digging Area 1pt", 1);
                    }
                }
            }
        }

        target = new Vector3(pPos.x, 0, pPos.z);
        SetState(eCharacterState.aimingAtTarget);
    }

    void OnNoMoreHealth()
    {
        gameEngine.SetGameOver();
    }

    void OnShovelFound()
    {
        hasShovel = true;
    }

    public void ConsumeShovel()
    {
        hasShovel = false;
    }

    public bool HasShovel()
    {
        return hasShovel;
    }

}
