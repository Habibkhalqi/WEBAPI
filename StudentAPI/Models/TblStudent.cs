using System;
using System.Collections.Generic;

namespace StudentAPI.Models;

public partial class TblStudent
{
    public int Id { get; set; }

    public string? SName { get; set; }

    public int? SAge { get; set; }

    public string? SGender { get; set; }

    public string? SFatherName { get; set; }

    public string? SClass { get; set; }
}
