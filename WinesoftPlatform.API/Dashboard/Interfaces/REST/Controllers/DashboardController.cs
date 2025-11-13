// 1. Importa los 'using' necesarios
using Microsoft.AspNetCore.Mvc;
using WinesoftPlatform.API.Dashboard.Domain.Model.Queries;
using WinesoftPlatform.API.Dashboard.Domain.Services;

namespace WinesoftPlatform.API.Dashboard.Interfaces.REST.Controllers;

/**
 * Controlador de API para el Bounded Context de Dashboard.
 * Define los endpoints que el frontend consumirá.
 */
// [Authorize] // <-- Descomenta esto cuando tengas tu 'IdentityAccess' Bounded Context listo
[ApiController]
[Route("api/v1/dashboard")] // Ruta base para este controlador
[Produces("application/json")]
public class DashboardController : ControllerBase
{
    // 2. Inyecta la Interfaz del Servicio (la que creamos en el Paso 3)
    private readonly IDashboardQueryService _dashboardQueryService;

    public DashboardController(IDashboardQueryService dashboardQueryService)
    {
        _dashboardQueryService = dashboardQueryService;
    }

    // 3. Define un endpoint para cada widget

    /**
     * Endpoint para el widget "Recent Orders (Filtered)"
     */
    [HttpGet("recent-orders")]
    public async Task<IActionResult> GetRecentOrders()
    {
        var orders = await _dashboardQueryService.HandleGetRecentOrders();
        return Ok(orders);
    }

    /**
     * Endpoint para el widget "Supply Levels (Current)"
     */
    [HttpGet("supply-levels")]
    public async Task<IActionResult> GetSupplyLevels()
    {
        var levels = await _dashboardQueryService.HandleGetSupplyLevels();
        return Ok(levels);
    }

    /**
     * Endpoint para el widget "Low Stock Alerts"
     */
    [HttpGet("low-stock-alerts")]
    public async Task<IActionResult> GetLowStockAlerts()
    {
        var alerts = await _dashboardQueryService.HandleGetLowStockAlerts();
        return Ok(alerts);
    }

    /**
     * Endpoint para el gráfico "Daily Supply Rotation" (con filtro de fecha)
     */
    [HttpGet("supply-rotation")]
    public async Task<IActionResult> GetSupplyRotation([FromQuery] GetDashboardMetricsQuery query)
    {
        var data = await _dashboardQueryService.HandleGetSupplyRotation(query);
        return Ok(data);
    }
    
    /**
     * Endpoint para el widget "Costs Summary" (con filtro de fecha)
     */
    [HttpGet("costs-summary")]
    public async Task<IActionResult> GetCostsSummary([FromQuery] GetDashboardMetricsQuery query)
    {
        var data = await _dashboardQueryService.HandleGetCostsSummary(query);
        return Ok(data);
    }
}