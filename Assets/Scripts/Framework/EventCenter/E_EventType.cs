using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 事件类型 枚举
/// </summary>
public enum E_EventType 
{
    /// <summary>
    /// 怪物死亡事件 —— 参数：Monster
    /// </summary>
    E_Monster_Dead,
    /// <summary>
    /// 玩家获取奖励 —— 参数：int
    /// </summary>
    E_Player_GetReward,
    /// <summary>
    /// 玩家改变位置—— 参数：Vector3
    /// </summary>
    E_Player_ChangePos,
    /// <summary>
    /// 测试用事件 —— 参数：无
    /// </summary>
    E_Test,
    /// <summary>
    /// 场景切换时进度变化获取
    /// </summary>
    E_SceneLoadChange,
    /// <summary>
    /// 删除跑操场景上的物品
    /// </summary>
    E_SceneDeleteItem,

    /// <summary>
    /// 输入系统触发技能1 行为
    /// </summary>
    E_Input_Skill1,
    /// <summary>
    /// 输入系统触发技能2 行为
    /// </summary>
    E_Input_Skill2,
    /// <summary>
    /// 输入系统触发技能3 行为
    /// </summary>
    E_Input_Skill3,

    /// <summary>
    /// 水平热键 -1~1的事件监听
    /// </summary>
    E_Input_Horizontal,

    /// <summary>
    /// 竖直热键 -1~1的事件监听
    /// </summary>
    E_Input_Vertical,
    /// <summary>
    /// 按键切换事件
    /// </summary>
    E_KeyChange,
    /// <summary>
    /// 场景切换——参数（进入 true，出去false）
    /// </summary>
    E_Cg,
    /// <summary>
    /// 角色向上移动
    /// </summary>
    E_Input_Up,
    /// <summary>
    /// 角色向下移动
    /// </summary>
    E_Input_Down,
    /// <summary>
    /// 角色向左移动
    /// </summary>
    E_Input_Left,
    /// <summary>
    /// 角色向右移动
    /// </summary>
    E_Input_Right,
    /// <summary>
    /// 角色2向上移动
    /// </summary>
    E_P2_Input_Up,
    /// <summary>
    /// 角色2向下移动
    /// </summary>
    E_P2_Input_Down,
    /// <summary>
    /// 角色2向左移动
    /// </summary>
    E_P2_Input_Left,
    /// <summary>
    /// 角色2向右移动
    /// </summary>
    E_P2_Input_Right,
    /// <summary>
    /// 相机震动——参数：无
    /// </summary>
    E_Camera_Shake,
    /// <summary>
    /// 角色切换到下一个物品
    /// </summary>
    E_Input_NextObj,
    /// <summary>
    /// 角色切换到上一个物品
    /// </summary>
    E_Input_BeforeObj,
    /// <summary>
    /// 面板更新
    /// </summary>
    E_Panel_Update,
    /// <summary>
    /// 鼠标滚轮的事件监听
    /// </summary>
    E_Input_MouseScroll,
}
