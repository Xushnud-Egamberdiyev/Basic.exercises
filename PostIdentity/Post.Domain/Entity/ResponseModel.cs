﻿namespace Post.Domain.Entity;

public class ResponseModel
{
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public bool IsSuccess { get; set; } = false;
}
