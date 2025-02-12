using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using DataRacingV1.Models;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Hosting;

public class CsvService
{
    private readonly IWebHostEnvironment _env;

    public CsvService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public List<Vehicle> GetVehicles(string filePath)
    {
        var fullPath = Path.Combine(_env.WebRootPath, filePath);

        using var reader = new StreamReader(fullPath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        //csv.ReadHeader();
        csv.Context.RegisterClassMap<VehicleMap>();
        var records = csv.GetRecords<Vehicle>().ToList();
        return records;
    }
}

public class VehicleMap : ClassMap<Vehicle>
{
    public VehicleMap()
    {
        Map(m => m.TIPO).Index(1);
        Map(m => m.FABRICANTE).Index(2);
        Map(m => m.MODELO).Index(3);
        Map(m => m.VARIANTE).Index(4);
        Map(m => m.MOTOR).Index(5);
        Map(m => m.ORI).Index(6);
        Map(m => m.MOD).Index(7);
        Map(m => m.GAIN).Index(8);
        Map(m => m.HP).Index(9);
        Map(m => m.RPM).Index(10);
        Map(m => m.OBD).Index(11);
        Map(m => m.STG).Index(12);
        Map(m => m.ACC).Index(13);
        Map(m => m.RON).Index(14);
        Map(m => m.VMX).Index(15);
        Map(m => m.CAT).Index(16);
        Map(m => m.EGR).Index(17);
        Map(m => m.DPF).Index(18);
        Map(m => m.IMM).Index(19);
        Map(m => m.SWR).Index(20);
        Map(m => m.MS).Index(21);
        Map(m => m.ADB).Index(22);
        Map(m => m.SS).Index(23);
        Map(m => m.PB).Index(24);
        Map(m => m.CAT2).Index(25);
        Map(m => m.STG1).Index(26);
        Map(m => m.STG2).Index(27);
        Map(m => m.ONLY).Index(28);
        Map(m => m.COMBO).Index(29);
        Map(m => m.KESS).Index(30);
        Map(m => m.KTAG).Index(31);
        Map(m => m.KESS3).Index(32);
        Map(m => m.DFOX).Index(33);
        Map(m => m.FLEX).Index(34);
        Map(m => m.BITBOX).Index(35);
        Map(m => m.FOTO1).Index(36);
        Map(m => m.FOTO2).Index(37);
        Map(m => m.FOTO3).Index(38);
        Map(m => m.FOTO4).Index(39);
        Map(m => m.NOTAS_ESPECIALES).Index(40);
        Map(m => m.ID).Index(41);
    }
}
