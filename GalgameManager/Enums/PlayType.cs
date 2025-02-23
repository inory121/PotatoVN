﻿using Windows.UI;
using GalgameManager.Helpers;
using Microsoft.UI;

namespace GalgameManager.Enums;

public enum PlayType
{
    None,
    Playing,
    Played,
    Shelved,
    Abandoned,
    WantToPlay
}

public static class PlayTypeHelper
{
    public static string GetLocalized(this PlayType playType)
    {
        return ("PlayType_" + playType).GetLocalized();
    }
    
    public static PlayType CastToPlayTyped(this string localizedString)
    {
        if (localizedString == "PlayType_Playing".GetLocalized())
            return PlayType.Playing;
        if (localizedString == "PlayType_Played".GetLocalized())
            return PlayType.Played;
        if (localizedString == "PlayType_Shelved".GetLocalized())
            return PlayType.Shelved;
        if (localizedString == "PlayType_Abandoned".GetLocalized())
            return PlayType.Abandoned;
        if (localizedString == "PlayType_WantToPlay".GetLocalized())
            return PlayType.WantToPlay;
        return PlayType.None;
    }

    /// <summary>
    /// 转换为bgm的收藏类型
    /// </summary>
    public static int ToBgmCollectionType(this PlayType playType)
    {
        switch (playType)
        {
            default:
            case PlayType.None:
            case PlayType.WantToPlay: 
                return 1;
            case PlayType.Played:
                return 2;
            case PlayType.Playing:
                return 3;
            case PlayType.Shelved:
                return 4;
            case PlayType.Abandoned:
                return 5;
        }
    }
    
    /// <summary>
    /// 转换为Vndb的收藏类型
    /// </summary>
    public static int ToVndbCollectionType(this PlayType playType)
    {
        switch (playType)
        {
            default:
            case PlayType.None:
            case PlayType.WantToPlay:
                return 5;
            case PlayType.Played:
                return 2;
            case PlayType.Playing:
                return 1;
            case PlayType.Shelved:
                return 3;
            case PlayType.Abandoned:
                return 4;
            // Blacklist: 6
        }
    }
    
    /// <summary>
    /// Vndb转换为游玩状态
    /// </summary>
    public static PlayType VndbCollectionTypeToPlayType(this int vndbCollectionType)
    {
        switch (vndbCollectionType)
        {
            default:
                return PlayType.None;
            case 1:
                return PlayType.Playing;
            case 2:
                return PlayType.Played;
            case 3:
                return PlayType.Shelved;
            case 4:
                return PlayType.Abandoned;
            case 5:
                return PlayType.WantToPlay;
        }
    }

    /// <summary>
    /// Bgm转换为游玩状态
    /// </summary>
    public static PlayType BgmCollectionTypeToPlayType(this int bgmCollectionType)
    {
        switch (bgmCollectionType)
        {
            default:
                return PlayType.None;
            case 1:
                return PlayType.WantToPlay;
            case 2:
                return PlayType.Played;
            case 3:
                return PlayType.Playing;
            case 4:
                return PlayType.Shelved;
            case 5:
                return PlayType.Abandoned;
        }
    }

    /// <summary>
    /// 转为代表色
    /// </summary>
    public static Color ToColor(this PlayType playType)
    {
        switch (playType)
        {
            default:
            case PlayType.None:
                return Colors.Gray;
            case PlayType.WantToPlay:
                return Colors.Pink;
            case PlayType.Played:
                return Colors.LimeGreen;
            case PlayType.Playing:
                return Colors.Blue;
            case PlayType.Shelved:
                return Colors.Orange;
            case PlayType.Abandoned:
                return Colors.IndianRed;
        }
    }
}