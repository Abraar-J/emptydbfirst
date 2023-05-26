using System;
using System.Collections.Generic;

namespace emptydbfirst.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public long? StudentPhNumber { get; set; }

    public string? CourseTaken { get; set; }
}
