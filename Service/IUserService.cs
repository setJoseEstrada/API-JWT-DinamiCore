using DynamiCore.Models.Response;
using DynamiCore.Models.Request;
using Microsoft.AspNetCore.Mvc;


namespace DynamiCore.Service
{
    public interface IUserService
    {

        AccesoResponde Auth(AuthRequest model);

    }
}
