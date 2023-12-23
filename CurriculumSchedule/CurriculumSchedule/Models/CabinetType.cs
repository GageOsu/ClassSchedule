using System;
using System.Collections.Generic;

namespace CurriculumSchedule.Models;

public partial class CabinetType
{
    public int Idcabinet { get; set; }

    public string? CabinetName { get; set; }

    public string? Discription { get; set; }

    public virtual Cabinet? Cabinet { get; set; }
}
