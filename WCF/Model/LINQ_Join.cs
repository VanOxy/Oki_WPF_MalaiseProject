using System.Linq;
using System;

public class LinqJoin
{
    public LinqJoin()
    {
        string fakeName = "Sciences";

        var query = from c in db.Students
                    from f in db.Faks
                    from p in db.Profs
                    where f == fakeName
                    select c.Name + p.Name;
    }
}