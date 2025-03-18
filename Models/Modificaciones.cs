namespace DataRacingV1.Models
{
    public class ModificacionesContainer
    {
        public Stage StageInstance { get; set; }
        public List<Modificacion> ModificacionesList { get; set; }
        public Vehicle SelectedVehicle { get; set; }

        public ModificacionesContainer()
        {
            
            StageInstance = new Stage();
            ModificacionesList = new List<Modificacion>();

            ModificacionesList.Add(new Modificacion { Nombre = "DECAT", Tipo = "Nafta", Seleccion = "No", Descripcion = "", Costo = 0, Options = new List<string> { "No", "Si" } });
            ModificacionesList.Add(new Modificacion { Nombre = "EGR-OFF", Tipo = "Diesel", Seleccion = "No", Descripcion = "", Costo = 0, Options = new List<string> { "No", "Si" } });
            ModificacionesList.Add(new Modificacion { Nombre = "DPF-OFF", Tipo = "Diesel", Seleccion = "No", Descripcion = "", Costo = 0, Options = new List<string> { "No", "Si" } });
            ModificacionesList.Add(new Modificacion { Nombre = "SCR-OFF", Tipo = "Diesel", Seleccion = "No", Descripcion = "", Costo = 0, Options = new List<string> { "No", "Si" } });
            ModificacionesList.Add(new Modificacion { Nombre = "DTC-OFF", Tipo = "Nafta, Diesel", Seleccion = "No", Descripcion = "", Costo = 0, Options = new List<string> { "No", "Si" } });
            ModificacionesList.Add(new Modificacion { Nombre = "FLAPS-OFF", Tipo = "Nafta, Diesel", Seleccion = "No", Descripcion = "", Costo = 0, Options = new List<string> { "No", "Si" } });
            ModificacionesList.Add(new Modificacion { Nombre = "MAF DELETE", Tipo = "Nafta, Diesel", Seleccion = "No", Descripcion = "", Costo = 0, Options = new List<string> { "No", "Si" } });
            ModificacionesList.Add(new Modificacion { Nombre = "START-STOP", Tipo = "Nafta, Diesel", Seleccion = "No", Descripcion = "", Costo = 0, Options = new List<string> { "No", "Si" } });
            ModificacionesList.Add(new Modificacion { Nombre = "SPEED-LIM", Tipo = "Nafta, Diesel", Seleccion = "No", Descripcion = "Desactivar el limitador de velocidad final", Costo = 0, Options = new List<string> { "No", "Si" } });
            ModificacionesList.Add(new Modificacion { Nombre = "POP N BANG", Tipo = "Nafta", Seleccion = "No", Descripcion = "", Costo = 0, Options = new List<string> { "No", "Si" } });
            ModificacionesList.Add(new Modificacion { Nombre = "LAUNCH CONTROL", Tipo = "Nafta, Diesel", Seleccion = "No", Descripcion = "", Costo = 0, Options = new List<string> { "No", "Si" } });
            ModificacionesList.Add(new Modificacion { Nombre = "IMMO", Tipo = "Nafta, Diesel", Seleccion = "No", Descripcion = "Desactivar el sistema antiarranque con llave", Costo = 0, Options = new List<string> { "No", "Si" } });
            ModificacionesList.Add(new Modificacion { Nombre = "COLD START HEATING", Tipo = "Nafta", Seleccion = "No", Descripcion = "Desactiva arranque en frio", Costo = 0, Options = new List<string> { "No", "Si" } });
            ModificacionesList.Add(new Modificacion { Nombre = "EXHAUST FLAP", Tipo = "Nafta", Seleccion = "No", Descripcion = "Desactiva Flap Escape", Costo = 0, Options = new List<string> { "No", "Si" } });
            ModificacionesList.Add(new Modificacion { Nombre = "GPF-OFF", Tipo = "Nafta", Seleccion = "No", Descripcion = "Anulacion sistema OPF GPF (Filtro de Particulas Otto)", Costo = 0, Options = new List<string> { "No", "Si" } });
            ModificacionesList.Add(new Modificacion { Nombre = "SECOND AIR INJ", Tipo = "Nafta", Seleccion = "No", Descripcion = "Desactiva inyeccion de aire secundario", Costo = 0, Options = new List<string> { "No", "Si" } });
            ModificacionesList.Add(new Modificacion { Nombre = "THROTTLE BODY", Tipo = "Diesel", Seleccion = "No", Descripcion = "Desactiva los DTC de la mariposa de pare", Costo = 0, Options = new List<string> { "No", "Si" } });
            ModificacionesList.Add(new Modificacion { Nombre = "HARD-CUT", Tipo = "Diesel", Seleccion = "No", Descripcion = "Corte final tipo PopCorn", Costo = 0, Options = new List<string> { "No", "Si" } });
            ModificacionesList.Add(new Modificacion { Nombre = "PEDAL-BOX", Tipo = "Diesel", Seleccion = "No", Descripcion = "Aumenta mas agresivamente la respuesta del acelerador electronico", Costo = 0, Options = new List<string> { "No", "Si" } });
   
        }


        public int changes(Vehicle SelectedVehicle_)
        {

            SelectedVehicle = SelectedVehicle_ ?? new Vehicle
            {
                TIPO = "",
                FABRICANTE = "",
                MODELO = "",
                VARIANTE = "",
                MOTOR = "",
                ORI = 0,
                MOD = 0,
                GAIN = 0,
                HP = 0,
                RPM = 0,
                T_ORI = 0,
                T_MOD = 0,
                OBD = false,
                STG = false,
                ACC = false,
                RON = false,
                VMX = false,
                CAT = false,
                EGR = false,
                DPF = false,
                IMM = false,
                SWR = false,
                MS = false,
                ADB = false,
                SS = false,
                PB = false,
                CAT2 = "",
                STG1 = 0,
                STG2 = 0,
                ONLY_J2 = 0,
                COMBO_J2 = 0,
                ONLY_J4 = 0,
                COMBO_J4 = 0,
                D_STG1 = 0,
                D_STG2 = 0,
                D_ONLY_J2 = 0,
                D_COMBO_J2 = 0,
                D_ONLY_J4 = 0,
                D_COMBO_J4 = 0,
                KESS = "",
                KTAG = "",
                KESS3 = "",
                DFOX = "",
                FLEX = "",
                BITBOX = "",
                FOTO1 = "",
                FOTO2 = "",
                FOTO3 = "",
                FOTO4 = "",
                NOTAS_ESPECIALES = "",
                ID = ""
            };
            switch (this.StageInstance.Seleccion)
            {
                case "Stage 1":
                    this.StageInstance.Costo = SelectedVehicle.D_STG1;
                    this.StageInstance.stage1 = true;
                    this.StageInstance.stage2 = false;
                    this.StageInstance.Descripcion = "(!) No es necesario ninguna modificación en el Hardware";
                    this.StageInstance.Selected = true;
                    break;
                case "Stage 1+":
                    this.StageInstance.Costo = (int)(SelectedVehicle.D_STG1 * 1.2);
                    this.StageInstance.stage1 = true;
                    this.StageInstance.stage2 = false;
                    this.StageInstance.Descripcion = "(!) Es necesario sacar físicamente el DPF o catalizador";
                    this.StageInstance.Selected = true;
                    break;
                case "Stage 2":
                    this.StageInstance.Costo = SelectedVehicle.D_STG2;
                    this.StageInstance.stage1 = false;
                    this.StageInstance.stage2 = true;
                    this.StageInstance.Descripcion = "(!) Es necesario Downpipe";
                    this.StageInstance.Selected = true;
                    break;
                case "Stage 2+":
                    this.StageInstance.Costo = (int)(SelectedVehicle.D_STG2 * 1.2);
                    this.StageInstance.stage1 = false;
                    this.StageInstance.stage2 = true;
                    this.StageInstance.Descripcion = "(!) Es necesario Downpipe, Escape completo, Kit de Admision";
                    this.StageInstance.Selected = true;
                    break;
                case "Stage 3":
                    this.StageInstance.Costo = (int)(SelectedVehicle.D_STG2 * 1.5);
                    this.StageInstance.stage1 = false;
                    this.StageInstance.stage2 = true;
                    this.StageInstance.Descripcion = "(!) Es necesario cambio de Turbo";
                    this.StageInstance.Selected = true;
                    break;
                case "Volver Stock":
                    this.StageInstance.Costo = (int)(SelectedVehicle.D_STG1 * 0.5);
                    this.StageInstance.stage1 = true;
                    this.StageInstance.stage2 = false;
                    this.StageInstance.Descripcion = "";
                    this.StageInstance.Selected = true;
                    break;
                case "Sin Cambios":
                    this.StageInstance.Costo = 0;
                    this.StageInstance.stage1 = false;
                    this.StageInstance.stage2 = false;
                    this.StageInstance.Descripcion = "";
                    this.StageInstance.Selected = false;
                    break;

                default:
                    this.StageInstance.Seleccion = "Sin Cambios";
                    this.StageInstance.Costo = 0;
                    this.StageInstance.stage1 = false;
                    this.StageInstance.stage2 = false;
                    this.StageInstance.Descripcion = "";
                    this.StageInstance.Selected = false;
                    break;
            }



            //modificaciones

            int TotalCost = 0;
            bool dpf = false;
            bool scr = false;
            int job2 = 0;
            int job4 = 0;

            foreach (var mod in this.ModificacionesList)
            {

                // Check if the mod is selected
                if (mod.Seleccion == "Si")
                {
                    mod.Selected = true;
                }
                else
                {
                    mod.Selected = false;
                }


                // Check the cost of the mod
                if (mod.Nombre == "DECAT")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        if (this.StageInstance.stage1 || this.StageInstance.stage2)
                        {
                            mod.Costo = SelectedVehicle.D_COMBO_J2;
                        }
                        else
                        {
                            mod.Costo = SelectedVehicle.D_ONLY_J2;
                        }
                    }
                    else
                    {
                        mod.Costo = 0;

                    }
                }

                if (mod.Nombre == "EGR-OFF")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        if (this.StageInstance.stage1 || this.StageInstance.stage2)
                        {
                            mod.Costo = SelectedVehicle.D_COMBO_J2;
                        }
                        else
                        {
                            mod.Costo = SelectedVehicle.D_ONLY_J2;
                        }
                    }
                    else
                    {
                        mod.Costo = 0;
                    }
                }

                if (mod.Nombre == "DPF-OFF")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        dpf = true;

                        if (this.StageInstance.stage1 || this.StageInstance.stage2)
                        {
                            mod.Costo = SelectedVehicle.D_COMBO_J4;
                        }
                        else
                        {
                            mod.Costo = SelectedVehicle.D_ONLY_J4;
                        }


                    }
                    else
                    {
                        dpf = false;
                        mod.Costo = 0;
                    }
                }

                if (mod.Nombre == "SCR-OFF")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        scr = true;
                        if (dpf == false)
                        {
                            if (this.StageInstance.stage1 || this.StageInstance.stage2)
                            {
                                mod.Costo = SelectedVehicle.D_COMBO_J4;
                            }
                            else
                            {
                                mod.Costo = SelectedVehicle.D_ONLY_J4;
                            }
                        }
                        else
                        {
                            mod.Costo = 0;
                        }
                    }
                    else
                    {
                        scr = false;
                        mod.Costo = 0;
                    }

                }

                if (mod.Nombre == "DTC-OFF")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        if (this.StageInstance.stage1 || this.StageInstance.stage2)
                        {
                            mod.Costo = SelectedVehicle.D_COMBO_J2;
                        }
                        else
                        {
                            mod.Costo = SelectedVehicle.D_ONLY_J2;
                        }
                    }
                    else
                    {
                        mod.Costo = 0;
                    }
                }

                if (mod.Nombre == "FLAPS-OFF")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        if (this.StageInstance.stage1 || this.StageInstance.stage2)
                        {
                            mod.Costo = SelectedVehicle.D_COMBO_J2;
                        }
                        else
                        {
                            mod.Costo = SelectedVehicle.D_ONLY_J2;
                        }
                    }
                    else
                    {
                        mod.Costo = 0;
                    }
                }

                if (mod.Nombre == "MAF DELETE")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        if (this.StageInstance.stage1 || this.StageInstance.stage2)
                        {
                            mod.Costo = SelectedVehicle.D_COMBO_J2;
                        }
                        else
                        {
                            mod.Costo = SelectedVehicle.D_ONLY_J2;
                        }
                    }
                    else
                    {
                        mod.Costo = 0;
                    }
                }

                if (mod.Nombre == "START-STOP")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        if (this.StageInstance.stage1 || this.StageInstance.stage2)
                        {
                            mod.Costo = SelectedVehicle.D_COMBO_J2;
                        }
                        else
                        {
                            mod.Costo = SelectedVehicle.D_ONLY_J2;
                        }
                    }
                    else
                    {
                        mod.Costo = 0;
                    }
                }

                if (mod.Nombre == "SPEED-LIM")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        if (this.StageInstance.stage1 || this.StageInstance.stage2)
                        {
                            mod.Costo = 0;
                        }
                        else
                        {
                            mod.Costo = SelectedVehicle.D_ONLY_J2;
                        }
                    }
                    else
                    {
                        mod.Costo = 0;
                    }
                }

                if (mod.Nombre == "POP N BANG")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        if (this.StageInstance.stage1 || this.StageInstance.stage2)
                        {
                            mod.Costo = SelectedVehicle.D_COMBO_J2;
                        }
                        else
                        {
                            mod.Costo = SelectedVehicle.D_ONLY_J2;
                        }
                    }
                    else
                    {
                        mod.Costo = 0;
                    }
                }

                if (mod.Nombre == "LAUNCH CONTROL")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        if (this.StageInstance.stage1 || this.StageInstance.stage2)
                        {
                            mod.Costo = SelectedVehicle.D_COMBO_J2;
                        }
                        else
                        {
                            mod.Costo = SelectedVehicle.D_ONLY_J2;
                        }
                    }
                    else
                    {
                        mod.Costo = 0;
                    }
                }

                if (mod.Nombre == "IMMO")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        if (this.StageInstance.stage1 || this.StageInstance.stage2)
                        {
                            mod.Costo = SelectedVehicle.D_COMBO_J2;
                        }
                        else
                        {
                            mod.Costo = SelectedVehicle.D_ONLY_J2;
                        }
                    }
                    else
                    {
                        mod.Costo = 0;
                    }
                }

                if (mod.Nombre == "COLD START HEATING")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        if (this.StageInstance.stage1 || this.StageInstance.stage2)
                        {
                            mod.Costo = SelectedVehicle.D_COMBO_J2;
                        }
                        else
                        {
                            mod.Costo = SelectedVehicle.D_ONLY_J2;
                        }
                    }
                    else
                    {
                        mod.Costo = 0;
                    }
                }

                if (mod.Nombre == "EXHAUST FLAP")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        if (this.StageInstance.stage1 || this.StageInstance.stage2)
                        {
                            mod.Costo = SelectedVehicle.D_COMBO_J2;
                        }
                        else
                        {
                            mod.Costo = SelectedVehicle.D_ONLY_J2;
                        }
                    }
                    else
                    {
                        mod.Costo = 0;
                    }
                }

                if (mod.Nombre == "GPF-OFF")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        if (this.StageInstance.stage1 || this.StageInstance.stage2)
                        {
                            mod.Costo = SelectedVehicle.D_COMBO_J2;
                        }
                        else
                        {
                            mod.Costo = SelectedVehicle.D_ONLY_J2;
                        }
                    }
                    else
                    {
                        mod.Costo = 0;
                    }
                }

                if (mod.Nombre == "SECOND AIR INJ")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        if (this.StageInstance.stage1 || this.StageInstance.stage2)
                        {
                            mod.Costo = SelectedVehicle.D_COMBO_J2;
                        }
                        else
                        {
                            mod.Costo = SelectedVehicle.D_ONLY_J2;
                        }
                    }
                    else
                    {
                        mod.Costo = 0;
                    }
                }

                if (mod.Nombre == "THROTTLE BODY")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        if (this.StageInstance.stage1 || this.StageInstance.stage2)
                        {
                            mod.Costo = SelectedVehicle.D_COMBO_J2;
                        }
                        else
                        {
                            mod.Costo = SelectedVehicle.D_ONLY_J2;
                        }
                    }
                    else
                    {
                        mod.Costo = 0;
                    }
                }

                if (mod.Nombre == "HARD-CUT")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        if (this.StageInstance.stage1 || this.StageInstance.stage2)
                        {
                            mod.Costo = SelectedVehicle.D_COMBO_J2;
                        }
                        else
                        {
                            mod.Costo = SelectedVehicle.D_ONLY_J2;
                        }
                    }
                    else
                    {
                        mod.Costo = 0;
                    }
                }

                if (mod.Nombre == "PEDAL-BOX")
                {
                    if (mod.Seleccion.Equals("Si"))
                    {
                        if (this.StageInstance.stage1 || this.StageInstance.stage2)
                        {
                            mod.Costo = SelectedVehicle.D_COMBO_J2;
                        }
                        else
                        {
                            mod.Costo = SelectedVehicle.D_ONLY_J2;
                        }
                    }
                    else
                    {
                        mod.Costo = 0;
                    }


                }



            }

            // Calculate the total cost
            TotalCost = this.ModificacionesList.Sum(m => m.Costo) + this.StageInstance.Costo;

            return TotalCost;







        }




    }

    public class Stage
    {
        public string Seleccion { get; set; }
        public List<string> Options { get; set; } = new List<string> { "Sin Cambios", "Stage 1", "Stage 1+", "Stage 2", "Stage 2+", "Stage 3", "Volver Stock" };
        public string Descripcion { get; set; }
        public int Costo { get; set; }
        public bool stage1 { get; set; }
        public bool stage2 { get; set; }
        public bool Selected { get; set; }
    }

    public class Modificacion
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Seleccion { get; set; }
        public int Costo { get; set; }
        public List<string> Options { get; set; } = new List<string>();
        public string Descripcion { get; set; }
        public bool Selected { get; set; }
    }
}
