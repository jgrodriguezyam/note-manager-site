﻿using NoteManager.Infrastructure.Client.BaseResponse;

namespace NoteManager.DTO.BaseResponse
{
    public class IsAliveResponse : SuccessResponse
    {
         public string Date { get; set; }
    }
}