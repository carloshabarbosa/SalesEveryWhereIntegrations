using Domain;
using Domain.Publisher.Buildings;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BuildingController : ControllerBase
{
    private readonly IBuildingPublisher _buildingPublisher;

    public BuildingController(IBuildingPublisher buildingPublisher)
    {
        _buildingPublisher = buildingPublisher;
    }
    /// <summary>
    /// Esse método é utilzado para realizar a integração com o sitema de empreendimentos
    /// </summary>
    /// <response code="200">Empreendimento integrado com sucesso</response>
    /// <response code="400">Caso ocorra algum erro de validação ou algum problema de conexão!</response>    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] BuildingRequestDto request)
    {
        try
        {
            _buildingPublisher.Publish(request);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Unauthorized();
        }
    }
}