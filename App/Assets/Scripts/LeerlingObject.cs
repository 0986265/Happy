using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LeerlingObject
{

    public static int id, active;

    public static string firstname, lastname, email, nickname, avatar, color;

    public static int Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }

    public static string Firstname
    {
        get
        {
            return firstname;
        }
        set
        {
            firstname = value;
        }
    }

    public static string Lastname
    {
        get
        {
            return lastname;
        }
        set
        {
            lastname = value;
        }
    }

    public static string Email
    {
        get
        {
            return email;
        }
        set
        {
            email = value;
        }
    }

    public static string Nickname
    {
        get
        {
            return nickname;
        }
        set
        {
            nickname = value;
        }
    }

    public static int Active
    {
        get
        {
            return active;
        }
        set
        {
            active = value;
        }
    }

    public static string Avatar
    {
        get
        {
            return avatar;
        }
        set
        {
            avatar = value;
        }
    }

    public static string Color
    {
        get
        {
            return color;
        }
        set
        {
            color = value;
        }
    }

}
