using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartwork.Data.Models;

public class WorkEntry
{

    public DateTime Date { get; set; }
    public TimeSpan From { get; set; }
    public TimeSpan To { get; set; }

    public WorkEntry(DateTime date, TimeSpan from, TimeSpan to)
    {
        Date = date;
        From = from;
        To = to;
    }

    public override string ToString()
    {
        return $"{Date:dd.MM.yyyy}: {From:hh\\:mm} - {To:hh\\:mm}";
    }
}
