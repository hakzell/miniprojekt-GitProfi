using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartwork.Data.Models;

public class Project
{

    public DateTime Date { get; set; }
    public TimeSpan From { get; set; }
    public TimeSpan To { get; set; }
    public string Description { get; set; }

    public Project(DateTime date, TimeSpan from, TimeSpan to, string description)
    {
        this.Date = date;
        this.From = from;
        this.To = to;
        this.Description = description;
    }

    public override string ToString()
    {
        return $"{Description} {Date:dd.MM.yyyy}: {From:hh\\:mm} - {To:hh\\:mm}";
    }
}
