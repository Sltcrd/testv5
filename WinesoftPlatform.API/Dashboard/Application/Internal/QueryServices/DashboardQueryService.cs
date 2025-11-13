
using WinesoftPlatform.API.Dashboard.Domain.Model.Queries;
using WinesoftPlatform.API.Dashboard.Domain.Services;
using WinesoftPlatform.API.Dashboard.Interfaces.REST.Resources;
using WinesoftPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
namespace WinesoftPlatform.API.Dashboard.Application.Internal.QueryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/**
 * Implementation del servicio de consultas del Dashboard.
 * Implementa la interfaz IDashboardQueryService.
 */
public class DashboardQueryService : IDashboardQueryService
{
    private readonly AppDbContext _context;

    public DashboardQueryService(AppDbContext context)
    {
        _context = context;
    }
    
    public Task<IEnumerable<RecentOrderResource>> HandleGetRecentOrders()
    {
        var mockOrders = new List<RecentOrderResource>
        {
            new(1001, "PENDING", new DateTime(2025, 10, 28, 10, 0, 0, DateTimeKind.Utc), 101, 50),
            new(1002, "SHIPPED", new DateTime(2025, 10, 27, 14, 30, 0, DateTimeKind.Utc), 102, 100),
            new(1003, "DELIVERED", new DateTime(2025, 10, 25, 9, 15, 0, DateTimeKind.Utc), 103, 200),
            new(1004, "CANCELLED", new DateTime(2025, 10, 24, 11, 0, 0, DateTimeKind.Utc), 101, 30),
            new(1005, "PENDING", new DateTime(2025, 10, 28, 12, 0, 0, DateTimeKind.Utc), 104, 20)
        };
        
        return Task.FromResult(mockOrders.AsEnumerable());
    }

    public Task<IEnumerable<SupplyLevelResource>> HandleGetSupplyLevels()
    {
        var mockLevels = new List<SupplyLevelResource>
        {
            new("Botellas 750ml", 50),
            new("Corchos", 40),
            new("Cebada", 120),
            new("Levadura Seca", 15),
            new("Etiquetas Adhesivas", 500)
        };
        
        return Task.FromResult(mockLevels.AsEnumerable());
    }

    public Task<IEnumerable<LowStockAlertResource>> HandleGetLowStockAlerts()
    {
        var mockAlerts = new List<LowStockAlertResource>
        {
            new("Botellas 750ml", 50, 100),
            new("Corchos", 40, 50)
        };
        
        return Task.FromResult(mockAlerts.AsEnumerable());
    }

    public Task<IEnumerable<SupplyRotationResource>> HandleGetSupplyRotation(GetDashboardMetricsQuery query)
    {
        var mockRotation = new List<SupplyRotationResource>
        {
            new(new DateTime(2025, 10, 1), 8),
            new(new DateTime(2025, 10, 2), 12),
            new(new DateTime(2025, 10, 3), 5),
            new(new DateTime(2025, 10, 4), 15),
            new(new DateTime(2025, 10, 5), 7),
            new(new DateTime(2025, 10, 6), 10),
            new(new DateTime(2025, 10, 7), 9)
        };
        
        return Task.FromResult(mockRotation.AsEnumerable());
    }

    public Task<CostsSummaryResource> HandleGetCostsSummary(GetDashboardMetricsQuery query)
    {
        var endDate = query.EndDate ?? DateTime.UtcNow;
        var startDate = query.StartDate ?? endDate.AddDays(-30); 
        
        var mockSummary = new CostsSummaryResource(
            TotalCost: 14200.50,
            StartDate: startDate,
            EndDate: endDate
        );
        
        return Task.FromResult(mockSummary);
    }
}