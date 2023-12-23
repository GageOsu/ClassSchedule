﻿using System;
using System.Collections.Generic;

namespace CurriculumSchedule.Models;

public partial class Semester
{
    public int Idsemester { get; set; }

    public string? Year { get; set; }

    public byte? EvenOdd { get; set; }

    public virtual ICollection<Week> Weeks { get; set; } = new List<Week>();
}
