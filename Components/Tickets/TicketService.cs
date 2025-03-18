using DataRacingV1.Components.Tickets;
using DataRacingV1.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;

public class TicketService
{
    private readonly TicketDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TicketService(TicketDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<TicketEntity>> GetTicketsAsync()
    {
        return await _context.Tickets.ToListAsync();
    }

    public async Task<List<TicketEntity>> GetTicketsByUserAsync()
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        return await _context.Tickets.Where(t => t.ClientId == user.Id).ToListAsync();
    }




    public async Task<TicketEntity> GetTicketByIdAsync(int id)
    {
        return await _context.Tickets.FindAsync(id);
    }

    public async Task AddTicketAsync(Ticket ticket)
    {
        var ticketEntity = new TicketEntity
        {
            ClientId = await GetCurrentUserIdAsync(),
            EditorId = "",
            Status = "New",
            Cost = ticket.Cost,
            VehiculoTipo = ticket.VehicleDetails.Tipo,
            VehiculoFabricante = ticket.VehicleDetails.Fabricante,
            VehiculoModelo = ticket.VehicleDetails.Modelo,
            VehiculoVariante = ticket.VehicleDetails.Variante,
            /*VehiculoPotencia = ticket.VehicleDetails.Potencia,
            VehiculoManual = ticket.VehicleDetails.Manual,
            InfoDueno = ticket.VehicleInfo.Dueno,
            InfoDominio = ticket.VehicleInfo.Dominio,
            InfoCombustible = ticket.VehicleInfo.Combustible,
            InfoTransmision = ticket.VehicleInfo.Transmision,
            InfoAdmision = ticket.VehicleInfo.Admision,
            InfoEscape = ticket.VehicleInfo.Escape,
            InfoComentarios = ticket.VehicleInfo.Comentarios,
            FileEquipo = ticket.UploadedFile.Equipo,
            FileArchivo = ticket.UploadedFile.Archivo,*/
            
        };

        _context.Tickets.Add(ticketEntity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTicketAsync(TicketEntity ticket)
    {
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTicketAsync(int id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket != null)
        {
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
        }
    }

    private async Task<string> GetCurrentUserIdAsync()
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        return user?.Id;
    }
}
