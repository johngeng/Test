using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for DaySevice
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class DaySevice : System.Web.Services.WebService
{

    public DaySevice()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string GetNext(string day)
    {
        if (Enum.TryParse<DayOfWeek>(day, true, out DayOfWeek dayInput))
        {
            var baseDay = DateTime.Today.Date.AddDays(-(int)DateTime.Today.DayOfWeek);
            var nextDay = baseDay.AddDays((int)dayInput + 1);

            //assuming return back furture day
            return $"{nextDay.AddDays(nextDay <= DateTime.Today.Date ? 7 : 0).ToString("dd MMM yyyy")}";
        }

        return "Incorrect day supplied.";
    }

}
