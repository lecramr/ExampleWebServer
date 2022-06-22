using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc;

namespace UI.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FunctionsController : ControllerBase
{
    private IConfiguration _configuration;
    
    public FunctionsController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    [Route("[action]")]
    public IActionResult ActivateOperator()
    {
        TcpClient client = new TcpClient();
        
        client.Connect(this._configuration["TcpSettings:Hostname"], int.Parse(this._configuration["TcpSettings:Port"]));
        
        StreamWriter streamWriter = new StreamWriter(client.GetStream());
        
        streamWriter.WriteLine(this._configuration["TcpSettings:MessageStart"]);
        streamWriter.Flush();
        
        return Ok();
    }

    [HttpGet]
    [Route("[action]")]
    public IActionResult DeactivateOperator()
    {
        TcpClient client = new TcpClient();
        
        client.Connect(this._configuration["TcpSettings:Hostname"], int.Parse(this._configuration["TcpSettings:Port"]));
        
        StreamWriter streamWriter = new StreamWriter(client.GetStream());
        
        streamWriter.WriteLine(this._configuration["TcpSettings:MessageStop"]);
        streamWriter.Flush();
        
        return Ok();
    }
}