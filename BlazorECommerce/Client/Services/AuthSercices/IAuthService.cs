﻿namespace BlazorECommerce.Client.Services.AuthSercices;

public interface IAuthService
{
    Task<ServiceResponse<int>?> Register(UserRegister request);
    Task<ServiceResponse<string>?> Login(UserLogin request);
}