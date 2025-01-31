﻿/*
NewExParamPanel.cs is part of the Experica.
Copyright (c) 2016 Li Alex Zhang and Contributors

Permission is hereby granted, free of charge, to any person obtaining a 
copy of this software and associated documentation files (the "Software"),
to deal in the Software without restriction, including without limitation
the rights to use, copy, modify, merge, publish, distribute, sublicense,
and/or sell copies of the Software, and to permit persons to whom the 
Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included 
in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF 
OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

namespace Experica.Command
{
    public class NewExParamPanel : MonoBehaviour
    {
        public AppManager uicontroller;
        public Text namecheck;
        public Button confirm, cancel;
        string pname; object param; bool isvalidname, isvalue;

        public void OnNewExParamName(string name)
        {
            if (uicontroller.exmgr.el.ex.ExtendParam.ContainsKey(name))
            {
                namecheck.text = "Name Already Exists";
                isvalidname = false;
            }
            else
            {
                namecheck.text = "";
                pname = name;
                isvalidname = true;
            }
            if (isvalidname && isvalue)
            {
                confirm.interactable = true;
            }
            else
            {
                confirm.interactable = false;
            }
        }

        public void OnNewExParamValue(string value)
        {
            param = value;
            isvalue = true;
            if (isvalidname && isvalue)
            {
                confirm.interactable = true;
            }
            else
            {
                confirm.interactable = false;
            }
        }

        public void Confirm()
        {
            uicontroller.expanel.NewExParam(pname, param);
            uicontroller.expanel.DeleteExParamPanel();
        }

        public void Cancel()
        {
            uicontroller.expanel.DeleteExParamPanel();
        }
    }
}