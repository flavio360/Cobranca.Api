using System.Data;
using System.Data.Common;
using System.Reflection;

namespace Cobranca.Api.Data.Infra
{
    public class Library
    {
        public static T readTable<T>(DbDataReader reader)
        {
            T classe = Activator.CreateInstance<T>();
            Type tipo = classe.GetType();
            PropertyInfo[] propriedades = tipo.GetProperties();

            foreach (PropertyInfo propriedade in propriedades)
            {
                if (reader[propriedade.Name] != DBNull.Value)
                {
                    switch (propriedade.PropertyType.ToString().ToLower())
                    {
                        case "system.string":
                            propriedade.SetValue(classe, reader[propriedade.Name].ToString(), null);
                            break;
                        case "system.int32":
                            propriedade.SetValue(classe, Convert.ToInt32(reader[propriedade.Name].ToString()), null);
                            break;
                        default:
                            propriedade.SetValue(classe, reader[propriedade.Name], null);
                            break;
                    }
                }
            }

            return classe;
        }


        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
