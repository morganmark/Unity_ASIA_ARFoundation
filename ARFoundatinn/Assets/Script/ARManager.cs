using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

//RC 要求元件 > 在第一次套用腳本執行
[RequireComponent(typeof(ARRaycastManager))]

public class ARManager : MonoBehaviour
{
    //點擊生成物件
    [Header("生成物件")]
    public GameObject obj;
    //管理器
    [Header("AR管理器")]
    public ARRaycastManager arManager;
    //滑鼠座標
    Vector2 pointMouse;
    //碰撞資訊
    List<ARRaycastHit> hits;

    //click
    void Tap()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))//Mouse_(0>left 1>right 2>center)
        {
            pointMouse = Input.mousePosition;
            print(pointMouse);

            //判斷打物件
            if(arManager.Raycast(pointMouse, hits, TrackableType.PlaneWithinPolygon))
            {
                //生成物件(物件, 座標, 角度)
                //hit[0].pose.position 點擊到地面第一個地方
                //Quaternion.identity 零角度
                Instantiate(obj, hits[0].pose.position, Quaternion.identity);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Tap();
    }
}
