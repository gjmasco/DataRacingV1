using DataRacingV1.Components.Pages;
using DataRacingV1.Components.Tickets;
using DataRacingV1.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System;
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




    public async Task<List<TicketEntity>> SearchTicketsAsync(string searchString)
    {
        var allTickets = await GetTicketsAsync(); // Await the result

        if (string.IsNullOrEmpty(searchString))
        {
            return allTickets;
        }

        return allTickets.Where(t =>
            t.Id.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            (t.ClientId?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.EditorId?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.Status?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.Cost?.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.VehiculoTipo?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.VehiculoFabricante?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.VehiculoModelo?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.VehiculoVariante?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.VehiculoPotencia?.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.VehiculoManual?.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.InfoDueno?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.InfoKm?.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.InfoDominio?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.InfoCombustible?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.InfoTransmision?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.InfoAdmision?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.InfoEscape?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.InfoComentarios?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.InfoDTCs?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.FileEquipo?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false) ||
            (t.FileArchivo?.Contains(searchString, StringComparison.OrdinalIgnoreCase) ?? false)
        ).ToList();
    }




    public async Task<List<TicketEntity>> GetTicketsAsync()
    {
        var tickets = new List<TicketEntity>();

        using (var command = _context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "SELECT * FROM Tickets"; // Consulta SQL (ajusta según tu necesidad)
            await _context.Database.OpenConnectionAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var ticket = new TicketEntity
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        ClientId = reader["ClientId"] == DBNull.Value ? null : reader["ClientId"].ToString(),
                        EditorId = reader["EditorId"] == DBNull.Value ? null : reader["EditorId"].ToString(),
                        Status = reader["Status"] == DBNull.Value ? null : reader["Status"].ToString(),
                        Cost = reader["Cost"] == DBNull.Value ? null : reader.GetInt32(reader.GetOrdinal("Cost")),
                        VehiculoTipo = reader["VehiculoTipo"].ToString(),
                        VehiculoFabricante = reader["VehiculoFabricante"].ToString(),
                        VehiculoModelo = reader["VehiculoModelo"].ToString(),
                        VehiculoVariante = reader["VehiculoVariante"].ToString(),
                        VehiculoPotencia = reader["VehiculoPotencia"] == DBNull.Value ? null : Convert.ToSingle(reader["VehiculoPotencia"]),
                        VehiculoManual = reader["VehiculoManual"] == DBNull.Value ? null : Convert.ToBoolean(reader["VehiculoManual"]),
                        InfoDueno = reader["InfoDueno"] == DBNull.Value ? null : reader["InfoDueno"].ToString(),
                        InfoKm = reader["InfoKm"] == DBNull.Value ? null : reader["InfoKm"] is DBNull ? null : Convert.ToInt32(reader["InfoKm"]),
                        InfoDominio = reader["InfoDominio"] == DBNull.Value ? null : reader["InfoDominio"].ToString(),
                        InfoCombustible = reader["InfoCombustible"] == DBNull.Value ? null : reader["InfoCombustible"].ToString(),
                        InfoTransmision = reader["InfoTransmision"] == DBNull.Value ? null : reader["InfoTransmision"].ToString(),
                        InfoAdmision = reader["InfoAdmision"] == DBNull.Value ? null : reader["InfoAdmision"].ToString(),
                        InfoEscape = reader["InfoEscape"] == DBNull.Value ? null : reader["InfoEscape"].ToString(),
                        InfoComentarios = reader["InfoComentarios"] == DBNull.Value ? null : reader["InfoComentarios"].ToString(),
                        InfoDTCs = reader["InfoDTCs"] == DBNull.Value ? null : reader["InfoDTCs"].ToString(),
                        FileEquipo = reader["FileEquipo"] == DBNull.Value ? null : reader["FileEquipo"].ToString(),
                        FileArchivo = reader["FileArchivo"] == DBNull.Value ? null : reader["FileArchivo"].ToString()

                    };
                    tickets.Add(ticket);
                }
            }
            await _context.Database.CloseConnectionAsync();
        }
        return tickets;
    }

    public async Task<List<TicketEntity>> GetTicketsByUserAsync()
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        if (user == null)
        {
            return new List<TicketEntity>(); // Retorna una lista vacía si el usuario no está autenticado
        }

        var tickets = new List<TicketEntity>();

        using (var command = _context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "SELECT * FROM Tickets WHERE ClientId = @ClientId";
            command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@ClientId", user.Id));
            await _context.Database.OpenConnectionAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var ticket = new TicketEntity
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        ClientId = reader["ClientId"] == DBNull.Value ? null : reader["ClientId"].ToString(),
                        EditorId = reader["EditorId"] == DBNull.Value ? null : reader["EditorId"].ToString(),
                        Status = reader["Status"] == DBNull.Value ? null : reader["Status"].ToString(),
                        Cost = reader["Cost"] == DBNull.Value ? null : reader.GetInt32(reader.GetOrdinal("Cost")),
                        VehiculoTipo = reader["VehiculoTipo"].ToString(),
                        VehiculoFabricante = reader["VehiculoFabricante"].ToString(),
                        VehiculoModelo = reader["VehiculoModelo"].ToString(),
                        VehiculoVariante = reader["VehiculoVariante"].ToString(),
                        VehiculoPotencia = reader["VehiculoPotencia"] == DBNull.Value ? null : Convert.ToSingle(reader["VehiculoPotencia"]),
                        VehiculoManual = reader["VehiculoManual"] == DBNull.Value ? null : Convert.ToBoolean(reader["VehiculoManual"]),
                        InfoDueno = reader["InfoDueno"] == DBNull.Value ? null : reader["InfoDueno"].ToString(),
                        InfoKm = reader["InfoKm"] == DBNull.Value ? null : reader["InfoKm"] is DBNull ? null : Convert.ToInt32(reader["InfoKm"]),
                        InfoDominio = reader["InfoDominio"] == DBNull.Value ? null : reader["InfoDominio"].ToString(),
                        InfoCombustible = reader["InfoCombustible"] == DBNull.Value ? null : reader["InfoCombustible"].ToString(),
                        InfoTransmision = reader["InfoTransmision"] == DBNull.Value ? null : reader["InfoTransmision"].ToString(),
                        InfoAdmision = reader["InfoAdmision"] == DBNull.Value ? null : reader["InfoAdmision"].ToString(),
                        InfoEscape = reader["InfoEscape"] == DBNull.Value ? null : reader["InfoEscape"].ToString(),
                        InfoComentarios = reader["InfoComentarios"] == DBNull.Value ? null : reader["InfoComentarios"].ToString(),
                        InfoDTCs = reader["InfoDTCs"] == DBNull.Value ? null : reader["InfoDTCs"].ToString(),
                        FileEquipo = reader["FileEquipo"] == DBNull.Value ? null : reader["FileEquipo"].ToString(),
                        FileArchivo = reader["FileArchivo"] == DBNull.Value ? null : reader["FileArchivo"].ToString()
                    };
                    tickets.Add(ticket);
                }
            }
            await _context.Database.CloseConnectionAsync();
        }
        return tickets;
    }




    public async Task<TicketEntity> GetTicketByIdAsync(int id)
    {
        using (var command = _context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "SELECT * FROM Tickets WHERE Id = @Id";
            command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Id", id));
            await _context.Database.OpenConnectionAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    var ticket = new TicketEntity
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        ClientId = reader["ClientId"] == DBNull.Value ? null : reader["ClientId"].ToString(),
                        EditorId = reader["EditorId"] == DBNull.Value ? null : reader["EditorId"].ToString(),
                        Status = reader["Status"] == DBNull.Value ? null : reader["Status"].ToString(),
                        Cost = reader["Cost"] == DBNull.Value ? null : reader.GetInt32(reader.GetOrdinal("Cost")),
                        VehiculoTipo = reader["VehiculoTipo"].ToString(),
                        VehiculoFabricante = reader["VehiculoFabricante"].ToString(),
                        VehiculoModelo = reader["VehiculoModelo"].ToString(),
                        VehiculoVariante = reader["VehiculoVariante"].ToString(),
                        VehiculoPotencia = reader["VehiculoPotencia"] == DBNull.Value ? null : Convert.ToSingle(reader["VehiculoPotencia"]),
                        VehiculoManual = reader["VehiculoManual"] == DBNull.Value ? null : Convert.ToBoolean(reader["VehiculoManual"]),
                        InfoDueno = reader["InfoDueno"] == DBNull.Value ? null : reader["InfoDueno"].ToString(),
                        InfoKm = reader["InfoKm"] == DBNull.Value ? null : reader["InfoKm"] is DBNull ? null : Convert.ToInt32(reader["InfoKm"]),
                        InfoDominio = reader["InfoDominio"] == DBNull.Value ? null : reader["InfoDominio"].ToString(),
                        InfoCombustible = reader["InfoCombustible"] == DBNull.Value ? null : reader["InfoCombustible"].ToString(),
                        InfoTransmision = reader["InfoTransmision"] == DBNull.Value ? null : reader["InfoTransmision"].ToString(),
                        InfoAdmision = reader["InfoAdmision"] == DBNull.Value ? null : reader["InfoAdmision"].ToString(),
                        InfoEscape = reader["InfoEscape"] == DBNull.Value ? null : reader["InfoEscape"].ToString(),
                        InfoComentarios = reader["InfoComentarios"] == DBNull.Value ? null : reader["InfoComentarios"].ToString(),
                        InfoDTCs = reader["InfoDTCs"] == DBNull.Value ? null : reader["InfoDTCs"].ToString(),
                        FileEquipo = reader["FileEquipo"] == DBNull.Value ? null : reader["FileEquipo"].ToString(),
                        FileArchivo = reader["FileArchivo"] == DBNull.Value ? null : reader["FileArchivo"].ToString(),
                        OriginalFile = reader["OriginalFile"] == DBNull.Value ? null : reader["OriginalFile"].ToString()
                    };
                    return ticket;
                }
            }
            await _context.Database.CloseConnectionAsync();
        }
        return null; // Retorna null si no se encuentra el ticket
    }

    public async Task AddTicketAsync(Ticket ticket, UploadedFile file)
    {
        var ticketEntity = new TicketEntity
        {
            ClientId = await GetCurrentUserIdAsync(),
            EditorId = "",
            Status = "New",
            Cost = ticket.Cost,

            VehiculoTipo = ticket.selectedVehicle.TIPO,
            VehiculoFabricante = ticket.selectedVehicle.FABRICANTE,
            VehiculoModelo = ticket.selectedVehicle.MODELO,
            VehiculoVariante = ticket.selectedVehicle.VARIANTE,

            VehiculoManual = ticket.VehicleDetails.Manual,
            VehiculoPotencia = ticket.selectedVehicle.ORI,


            InfoDueno = ticket.VehicleInfo.Dueno,
            InfoKm = ticket.VehicleInfo.Km,
            InfoDominio = ticket.VehicleInfo.Dominio,
            InfoCombustible = ticket.VehicleInfo.Combustible,
            InfoTransmision = ticket.VehicleInfo.Transmision,
            InfoAdmision = ticket.VehicleInfo.Admision,
            InfoEscape = ticket.VehicleInfo.Escape,
            InfoComentarios = ticket.VehicleInfo.Comentarios,

            //FALTA RESOLVER EL TEMA DE DTCS!!!

            OriginalFile = file,
            FileEquipo = ticket.UploadedFile.Equipo,
            FileArchivo = ticket.UploadedFile.Archivo

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
