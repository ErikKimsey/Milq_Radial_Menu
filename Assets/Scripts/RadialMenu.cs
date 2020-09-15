using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public MenuBtn menuBtn;
    public int numberOfBtns;
    public float radius;
    List<MenuBtn> menuBtns = new List<MenuBtn>();
    private Vector3 menuCenter;
    private float arcIncrement;

    void Start()
    {
        menuCenter = transform.position;
        menuCenter = new Vector3(menuCenter.x, menuCenter.y, 0f);

        Debug.Log(menuCenter);
        arcIncrement = 180/4;
        CreateMenu();
    }

    private void CreateMenu(){
        for(int i=0; i < numberOfBtns; i++){
            Vector3 pos = CalcBtnPosition(i, radius);
            Debug.Log(pos);
            MenuBtn mb = Instantiate(menuBtn, pos, Quaternion.identity, transform);
            menuBtns.Add(mb);
        }
    }

    private Vector3 CalcBtnPosition(int i, float r){
        float x = r * Mathf.Cos((i * arcIncrement) + 280f) + menuCenter.x;
        float y = r * Mathf.Sin((i * arcIncrement) + 280f) + menuCenter.y;
        return new Vector3(x, y, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
