using System;
using System.Collections.Generic;

namespace Server.Model;

public partial class Cabinet
{
    public int Idcabinet { get; set; }

    public int? IdcabinetType { get; set; }

    public int? AmmountPlaces { get; set; }

    public string? CabinetNumber { get; set; }

    public virtual CabinetType? IdcabinetTypeNavigation { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
