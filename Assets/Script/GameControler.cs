using UnityEngine;
using System.Collections;
using UnityEngine.UI;                                      //引入UI的命名空间

public class GameControler : MonoBehaviour
{
    //声明控件（变量）：用于接收资源图片（精灵）。如ImaUser.overrideSprite = Resources.Load("···", typeof(Sprite)) as Sprite;
    public Image ImaUser;                                  //用户的出牌
    public Image ImaComputer;                              //计算机的出牌
    public Image ImaWiner;                                 //显式胜负结果
    public Text TxtInfoTip;                                //信息提示

    int intUser = 0;                                       //用户出牌
    int intComputer = 0;                                   //计算机出牌
    string strJudgeResult = null;                          //判断胜负结果

    //点击调用。要想调用该方法，必须选中需要点击的Button按钮添加事件。即上图关联脚本的方法  
    //用户点击剪刀                                                       
    public void UserClikJiDao()
    {
        intUser = 0;
        ProcessCard();
    }

    //用户点击包袱
    public void UserClikBaoFu()
    {
        intUser = 1;
        ProcessCard();
    }
    //用户点击锤子
    public void UserClikChuiZi()
    {
        intUser = 2;
        ProcessCard();
    }

    //内部牌的逻辑处理
    void ProcessCard()
    {
        //显示用户出牌
        switch (intUser)
        {
            case 0:
                ImaUser.overrideSprite = Resources.Load("Textures/Human/jiandao", typeof(Sprite)) as Sprite;
                break;
            case 1:
                ImaUser.overrideSprite = Resources.Load("Textures/Human/bu", typeof(Sprite)) as Sprite;
                break;
            case 2:
                ImaUser.overrideSprite = Resources.Load("Textures/Human/quantou", typeof(Sprite)) as Sprite;
                break;
            default:
                break;
        }

        //显示计算机出牌
        //调用ComputerSendCard()方法
        intComputer = ComputerSendCard();
        switch (intComputer)
        {
            case 0:
                ImaComputer.overrideSprite = Resources.Load("Textures/computer/jiandao1", typeof(Sprite)) as Sprite;
                break;
            case 1:
                ImaComputer.overrideSprite = Resources.Load("Textures/computer/bu1", typeof(Sprite)) as Sprite;
                break;
            case 2:
                ImaComputer.overrideSprite = Resources.Load("Textures/computer/chuitou1", typeof(Sprite)) as Sprite;
                break;
            default:
                break;
        }
        //调用方法判断胜负
        strJudgeResult = JudgeWiner(intUser, intComputer);
        if (strJudgeResult == "平手")
        {
            TxtInfoTip.text = "“平手”好可惜啊，再来一局吧";
            ImaWiner.overrideSprite = Resources.Load("Textures/drawInfo/draw", typeof(Sprite)) as Sprite;
        }
        else if (strJudgeResult == "用户赢")
        {
            TxtInfoTip.text = "哇！好厉害，你赢了耶";
            ImaWiner.overrideSprite = Resources.Load("Textures/victoryInfo/shengli", typeof(Sprite)) as Sprite;
        }
        else if (strJudgeResult == "计算机赢")
        {
            TxtInfoTip.text = "哈哈。。。你是猴子派来的傻逼吗？这么简单都输了";
            ImaWiner.overrideSprite = Resources.Load("Textures/failImfo/chuxuol", typeof(Sprite)) as Sprite;
        }
    }

    //产生随机数给计算机出牌
    int ComputerSendCard()
    {
        int intReturnRandomResult = 0;
        System.Random r = new System.Random();
        intReturnRandomResult = r.Next(3);
        return intReturnRandomResult;
    }
    //判断胜负的方法
    string JudgeWiner(int userCard, int computerCar)
    {
        string strResult = null;
        switch (userCard)
        {
            case 0:
                if (computerCar == 0)
                {
                    strResult = "平手";
                }
                else if (computerCar == 1)
                {
                    strResult = "用户赢";
                }
                else if (computerCar == 2)
                {
                    strResult = "计算机赢";
                }
                break;

            case 1:
                if (computerCar == 0)
                {
                    strResult = "计算机赢";
                }
                else if (computerCar == 1)
                {
                    strResult = "平手";
                }
                else if (computerCar == 2)
                {
                    strResult = "用户赢";
                }
                break;
            case 2:
                if (computerCar == 0)
                {
                    strResult = "用户赢";
                }
                else if (computerCar == 1)
                {
                    strResult = "计算机赢";
                }
                else if (computerCar == 2)
                {
                    strResult = "平手";
                }
                break;
            default:
                break;
        }
        return strResult;
    }
}