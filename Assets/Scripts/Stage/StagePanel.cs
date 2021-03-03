using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StagePanel : MonoBehaviour {
    public int maxLevel = 4;
    public int minLevel = 1;
    //当前关卡
    public int level;
    private StagesMovement sMovement;

    private Button leftButton;
    private Button rightButton;
    private Transform stageToggleParent;
    //private GameObject stageToggleTemplate;

    public Toggle[] stageToggles;

    private void Awake()
    {
        sMovement = transform.Find("Stages").GetComponent<StagesMovement>();

        stageToggleParent = transform.Find("stagesGroup");
        //stageToggleTemplate=transform.Find("")
        leftButton = transform.Find("left").GetComponent<Button>();
        rightButton = transform.Find("right").GetComponent<Button>();
        leftButton.onClick.AddListener(() =>
        {
            if (sMovement.IsMove())
            {
                if (level <= minLevel) return;
                level--;
                level = Mathf.Clamp(level, minLevel, maxLevel);

                sMovement.MoveRight();
            }

        });
        rightButton.onClick.AddListener(() =>
        {
            if (sMovement.IsMove())
            {
                if (level >= maxLevel) return;
                level++;
                level = Mathf.Clamp(level, minLevel, maxLevel);

                sMovement.MoveLeft();
            }

        });
    }
    // Use this for initialization
    void Start () {
        level = minLevel;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
