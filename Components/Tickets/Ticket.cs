using DataRacingV1.Components.Dataracing;
using DataRacingV1.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using YourNamespace.Models;
using static DataRacingV1.Components.Tickets.SubmitFileUpload;
using static DataRacingV1.Components.Tickets.SubmitVehicleInfo;

namespace DataRacingV1.Components.Tickets
{
    public class Ticket
    {

        //variables de los steps
        public Vehicle selectedVehicle { get; set; } = new Vehicle(); //vehiculo seleccionado si esta en la lista, sino solo lo de submit y lo demas vacio
        public SubmitVehicle VehicleDetails { get; set; } = new SubmitVehicle(); //vehiculo abreviado para el step de submit
        public VehicleInfo VehicleInfo { get; set; } = new VehicleInfo();
        public ModificacionesContainer ModificacionesDetails { get; set; } = new ModificacionesContainer();
        public UploadedFileInfo UploadedFile { get; set; } = new UploadedFileInfo();

        //variables propias del ticket

        public int Cost { get; set; }




    }

    //ticket para enviar a la DB

    public class TicketEntity
    {
        public int Id { get; set; }
        public string? ClientId { get; set; }
        public string? EditorId { get; set; }
        public string? Status { get; set; }
        public int? Cost { get; set; }

        public string VehiculoTipo { get; set; }
        public string VehiculoFabricante { get; set; }
        public string VehiculoModelo { get; set; }
        public string VehiculoVariante { get; set; }
        public int? VehiculoPotencia { get; set; }
        public bool?  VehiculoManual { get; set; }
        
        public string? InfoDueno { get; set; }
        public string? InfoKm { get; set; }
        public string? InfoDominio { get; set; }
        public string? InfoCombustible { get; set; }
        public string? InfoTransmision { get; set; }
        public string? InfoAdmision { get; set; }
        public string? InfoEscape { get; set; }
        public string? InfoComentarios { get; set; }
        public string? InfoDTCs { get; set; }

        public string? FileEquipo { get; set; }
        public string? FileArchivo { get; set; }

        public UploadedFile? OriginalFile { get; set; }

        public List<UploadedFile?> UploadedFiles { get; set; } = new List<UploadedFile?>();
    }







}
