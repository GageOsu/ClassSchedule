﻿using System;
using System.Collections.Generic;

namespace CurriculumSchedule.Model;

public partial class Week
{
    public int Idweek { get; set; }

    public int? Idsemester { get; set; }

    public virtual ICollection<Day> Days { get; set; } = new List<Day>();

    public virtual Semester? IdsemesterNavigation { get; set; }
}
