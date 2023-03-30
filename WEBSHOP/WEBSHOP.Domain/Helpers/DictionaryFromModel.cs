using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.Domain.Helpers
{
    public static class DictionaryFromModel
    {
        public static Dictionary<string, string> GetDictionaryFromModel(Type modelType, object model)
        {
            Dictionary<string, string> FieldAndValue = new();
            var props = modelType.GetProperties();
            foreach (var i in props)
            {
                if (i.PropertyType.Name == typeof(DateTime).Name)
                    FieldAndValue.Add(i.Name, ((DateTime)i.GetValue(model)).ToString("dd.MM.yyyy"));
                else if (i.PropertyType.Name == typeof(UnitViewModel).Name)
                {
                    UnitViewModel unit = (UnitViewModel)i.GetValue(model);
                    FieldAndValue.Add(i.Name, unit?.Title?.ToString() ?? "undefined");
                }
                else if (i.PropertyType.Name == typeof(UserViewModel).Name)
                {
                    UserViewModel user = (UserViewModel)i.GetValue(model);
                    FieldAndValue.Add(i.Name + " (Phone number)", user.Phone?.ToString() ?? "undefined");
                }
                else if (i.PropertyType.Name == typeof(List<ProductViewModel>).Name)
                {
                    continue;
                }
                else
                    FieldAndValue.Add(i.Name, i.GetValue(model)?.ToString() ?? "undefined");
            }
            return FieldAndValue;
        }
    }
}
