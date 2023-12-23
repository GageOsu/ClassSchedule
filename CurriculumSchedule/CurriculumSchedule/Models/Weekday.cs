﻿using System;
using System.Collections.Generic;

namespace CurriculumSchedule.Models;

public partial class Weekday
{
    public int Idweekday { get; set; }

    public string? NameWeekday { get; set; }

    public virtual ICollection<Day> Days { get; set; } = new List<Day>();
}
