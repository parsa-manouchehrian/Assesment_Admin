using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public partial class SystemSetting
    {
        public string Name { get; set; } = null!;
        public string? Value { get; set; }
    }
}
