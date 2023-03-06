using AppSample.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppSample.Api.Controllers;

/// <summary>
/// ���������� �������� ����������������� API
/// </summary>
[ApiController]
[AllowAnonymous]
[Route("healthcheck")]
public class HealthcheckController : ControllerBase
{
    /// <summary>
    /// </summary>
    public HealthcheckController()
    {
    }

    /// <summary>
    /// �������� ����������� API
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("heartbeat")]
    public HealthCheckResponse HealthCheck()
    {
        var response = new HealthCheckResponse
        {
            Result = "OK"
        };
        return response;
    }

    /// <summary>
    /// �������� ����������� ��������
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("serviceavailable")]
    public ServiceAvailableResponse ServiceAvailable()
    {
        var response = new ServiceAvailableResponse
        {
            Core = GetStatus(true),
            //TODO - ������ ������� ��������
            Db = GetStatus(true), 
            Redis = GetStatus(true),
        };
        return response;
    }

    static string GetStatus(bool checkMethod)
    {
        var result = checkMethod ? "OK" : "Fail";
        return result;
    }
}