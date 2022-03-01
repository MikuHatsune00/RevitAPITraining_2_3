using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraining_2_3
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            var columns = new FilteredElementCollector(doc)
                  .OfCategory(BuiltInCategory.OST_StructuralColumns)
                  .WhereElementIsNotElementType()
                  .Cast<FamilyInstance>()
                  .ToList();

            TaskDialog.Show("Columns count", columns.Count.ToString());
            return Result.Succeeded;
        }
    
    }
}
