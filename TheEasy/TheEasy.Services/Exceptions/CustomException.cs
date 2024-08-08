﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEasy.Services.Exceptions;

public class CustomException : Exception
{
    public int stutusCode {  get; set; }

    public CustomException(int code, string message)
    {
        this.stutusCode = code;
    }
}
