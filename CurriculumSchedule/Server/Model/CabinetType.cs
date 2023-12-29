using System;
using System.Collections.Generic;

namespace Server.Model;

public partial class CabinetType
{
    public int IdcabinetType { get; set; }

    public string? CabinetName { get; set; }

    public string? Discription { get; set; }

    public virtual ICollection<Cabinet> Cabinets { get; set; } = new List<Cabinet>();
}
