using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using DataRacingV1.Models;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Hosting;
using CsvHelper.TypeConversion;

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
        csv.Context.RegisterClassMap<VehicleMap>();
        var records = csv.GetRecords<Vehicle>().ToList();
        return records;
    }
}

public class VehicleMap : ClassMap<Vehicle>
{
    public VehicleMap()
    {
        Map(m => m.TIPO).Index(0);
        Map(m => m.FABRICANTE).Index(1);
        Map(m => m.MODELO).Index(2);
        Map(m => m.VARIANTE).Index(3);
        Map(m => m.MOTOR).Index(4);
        Map(m => m.ORI).Index(5).TypeConverter<FloatConverter>();
        Map(m => m.MOD).Index(6).TypeConverter<FloatConverter>();
        Map(m => m.GAIN).Index(7).TypeConverter<FloatConverter>();
        Map(m => m.HP).Index(8).TypeConverter<FloatConverter>();
        Map(m => m.RPM).Index(9).TypeConverter<FloatConverter>();
        Map(m => m.T_ORI).Index(10).TypeConverter<FloatConverter>();
        Map(m => m.T_MOD).Index(11).TypeConverter<FloatConverter>();
        Map(m => m.OBD).Index(12).TypeConverter<BoolConverter>();
        Map(m => m.STG).Index(13).TypeConverter<BoolConverter>();
        Map(m => m.ACC).Index(14).TypeConverter<BoolConverter>();
        Map(m => m.RON).Index(15).TypeConverter<BoolConverter>();
        Map(m => m.VMX).Index(16).TypeConverter<BoolConverter>();
        Map(m => m.CAT).Index(17).TypeConverter<BoolConverter>();
        Map(m => m.EGR).Index(18).TypeConverter<BoolConverter>();
        Map(m => m.DPF).Index(19).TypeConverter<BoolConverter>();
        Map(m => m.IMM).Index(20).TypeConverter<BoolConverter>();
        Map(m => m.SWR).Index(21).TypeConverter<BoolConverter>();
        Map(m => m.MS).Index(22).TypeConverter<BoolConverter>();
        Map(m => m.ADB).Index(23).TypeConverter<BoolConverter>();
        Map(m => m.SS).Index(24).TypeConverter<BoolConverter>();
        Map(m => m.PB).Index(25).TypeConverter<BoolConverter>();
        Map(m => m.CAT2).Index(26);
        Map(m => m.STG1).Index(27).TypeConverter<IntegerConverter>();
        Map(m => m.STG2).Index(28).TypeConverter<IntegerConverter>();
        Map(m => m.ONLY_J2).Index(29).TypeConverter<IntegerConverter>();
        Map(m => m.COMBO_J2).Index(30).TypeConverter<IntegerConverter>();
        Map(m => m.ONLY_J4).Index(31).TypeConverter<IntegerConverter>();
        Map(m => m.COMBO_J4).Index(32).TypeConverter<IntegerConverter>();
        Map(m => m.D_STG1).Index(33).TypeConverter<IntegerConverter>();
        Map(m => m.D_STG2).Index(34).TypeConverter<IntegerConverter>();
        Map(m => m.D_ONLY_J2).Index(35).TypeConverter<IntegerConverter>();
        Map(m => m.D_COMBO_J2).Index(36).TypeConverter<IntegerConverter>();
        Map(m => m.D_ONLY_J4).Index(37).TypeConverter<IntegerConverter>();
        Map(m => m.D_COMBO_J4).Index(38).TypeConverter<IntegerConverter>();
        Map(m => m.KESS).Index(39);
        Map(m => m.KTAG).Index(40);
        Map(m => m.KESS3).Index(41);
        Map(m => m.DFOX).Index(42);
        Map(m => m.FLEX).Index(43);
        Map(m => m.BITBOX).Index(44);
        Map(m => m.FOTO1).Index(45);
        Map(m => m.FOTO2).Index(46);
        Map(m => m.FOTO3).Index(47);
        Map(m => m.FOTO4).Index(48);
        Map(m => m.NOTAS_ESPECIALES).Index(49);
        Map(m => m.ID).Index(50);
    }
}


public class IntegerConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        if (int.TryParse(text, out int result))
        {
            return result;
        }
        return 0; // Default value if parsing fails
    }
}

public class FloatConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        if (float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out float result))
        {
            return result;
        }
        return 0f; // Default value if parsing fails
    }
}

public class BoolConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        //if text == true or TRUE or True, return true
        if (text.Equals("true", System.StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        return false; // Default value if parsing fails
    }
}