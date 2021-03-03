using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StagesMovement : MonoBehaviour {
    public enum State
    {
        Normal,
        Moving,
    }
    public RectTransform insideStage;
    public RectTransform outsideStage;

    public float movementTime = 0.5f;

    //画布尺寸
    private Vector2 canvasSize;
    //当前状态
    private State state = State.Normal;

	// Use this for initialization
	void Start () {
        GameObject canvas = GameObject.Find("Canvas");
        RectTransform rt = canvas.transform as RectTransform;
        canvasSize = rt.sizeDelta;

        insideStage.anchoredPosition = Vector2.zero;
        outsideStage.anchoredPosition = new Vector2(canvasSize.x, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// 当前关卡是否可以移动
    /// </summary>
    /// <returns></returns>
    public bool IsMove()
    {
        return state == State.Normal ? true : false;
    }
    public void MoveLeft()
    {
        if (!IsMove()) return;
        outsideStage.anchoredPosition = new Vector2(canvasSize.x, 0);
        state = State.Moving;
        insideStage.DOAnchorPosX(-canvasSize.x, movementTime);
        Tweener tr = outsideStage.DOAnchorPosX(0, movementTime);
        tr.onComplete = () =>
        {
            RectTransform temp = insideStage;
            insideStage = outsideStage;
            outsideStage = temp;
            state = State.Normal;
        };
    }
    public void MoveRight()
    {
        if (!IsMove()) return;
        outsideStage.anchoredPosition = new Vector2(-canvasSize.x, 0);
        state = State.Moving;
        insideStage.DOAnchorPosX(canvasSize.x, movementTime);
        Tweener tr = outsideStage.DOAnchorPosX(0, movementTime);
        tr.onComplete = () =>
        {
            RectTransform temp = insideStage;
            insideStage = outsideStage;
            outsideStage = temp;
            state = State.Normal;
        };
    }
}
