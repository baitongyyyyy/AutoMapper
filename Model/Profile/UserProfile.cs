using WebApplication1.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;


public class UserProfile : Profile
{
    public UserProfile()
    {
        this.CreateMap<User, UserViewModel>();
    }
}