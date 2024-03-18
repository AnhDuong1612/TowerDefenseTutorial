using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//public class UpgradeUIHandle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
//{
//    public bool mouse_over = false;
//    public void OnPointerEnter(PointerEventData evenData)
//    {
//        mouse_over = true;
//        UIManager.main.SetHoveringState(true);
//    }

//    // tai sao phai get set trong ham kia 
//    // bien mat obj neu di chuot qua 
//    public void OnPointerExit(PointerEventData evenData)
//    {
//        mouse_over = false;
//        UIManager.main.SetHoveringState(false);
//        gameObject.SetActive(false);
//    }
//}
// doan code tren tuc la muon kiem tra neu chuot an vao doi tuong nay thi no hien thi la true con nguoc lai thi no hien thi la false  de lam the thi no se luu
// ui manager - upgradeuihandle . Lay ra trang thai cua ui manager thi thong qua con tro chuot . Neu con tro chuot di chuyen qua thi chuyen trang thai hien thi thanh true con neu di chuyen
// ra thi chuyen trang thai thanh false tuc
// con tro chuot an vao thi hien thi ui con tro chuot khong an vao thi khong hien thi ui .
// cach ket noi ui voi con tro chuo