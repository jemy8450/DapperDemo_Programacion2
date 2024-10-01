using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CustomerRepository
    {
        public string SelcetAll { get; private set; }

        public List<Customers> ObtenerTodo()
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String SelectAll = "";
                SelectAll = SelectAll + "SELECT [CustomerID] " + "\n";
                SelectAll = SelectAll + "      ,[CompanyName] " + "\n";
                SelectAll = SelectAll + "      ,[ContactName] " + "\n";
                SelectAll = SelectAll + "      ,[ContactTitle] " + "\n";
                SelectAll = SelectAll + "      ,[Address] " + "\n";
                SelectAll = SelectAll + "      ,[City] " + "\n";
                SelectAll = SelectAll + "      ,[Region] " + "\n";
                SelectAll = SelectAll + "      ,[PostalCode] " + "\n";
                SelectAll = SelectAll + "      ,[Country] " + "\n";
                SelectAll = SelectAll + "      ,[Phone] " + "\n";
                SelectAll = SelectAll + "      ,[Fax] " + "\n";
                SelectAll = SelectAll + "  FROM [dbo].[Customers]";

                var cliente = conexion.Query<Customers>(SelectAll).ToList();
                return cliente;

            }
        }

        //--------------------------------------------------------------------------//

        public Customers ObtenerPorID(string id)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String SelectPorID = "";
                SelectPorID = SelectPorID + "SELECT [CustomerID] " + "\n";
                SelectPorID = SelectPorID + "      ,[CompanyName] " + "\n";
                SelectPorID = SelectPorID + "      ,[ContactName] " + "\n";
                SelectPorID = SelectPorID + "      ,[ContactTitle] " + "\n";
                SelectPorID = SelectPorID + "      ,[Address] " + "\n";
                SelectPorID = SelectPorID + "      ,[City] " + "\n";
                SelectPorID = SelectPorID + "      ,[Region] " + "\n";
                SelectPorID = SelectPorID + "      ,[PostalCode] " + "\n";
                SelectPorID = SelectPorID + "      ,[Country] " + "\n";
                SelectPorID = SelectPorID + "      ,[Phone] " + "\n";
                SelectPorID = SelectPorID + "      ,[Fax] " + "\n";
                SelectPorID = SelectPorID + "  FROM [dbo].[Customers] " + "\n";
                SelectPorID = SelectPorID + "  WHERE CustomerID = @CustomerID]";

                var Cliente = conexion.QueryFirstOrDefault<Customers>(SelectPorID, new { CustomerID = id });
                return Cliente;

            }
        }

        //--------------------------------------------------------------------------//

        public int insertarCliente(Customers customer)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String Insertar = "";
                Insertar = Insertar + "INSERT INTO [dbo].[Customers] " + "\n";
                Insertar = Insertar + "           ([CustomerID] " + "\n";
                Insertar = Insertar + "           ,[CompanyName] " + "\n";
                Insertar = Insertar + "           ,[ContactName] " + "\n";
                Insertar = Insertar + "           ,[ContactTitle] " + "\n";
                Insertar = Insertar + "           ,[Address]) " + "\n";
                Insertar = Insertar + "           " + "\n";
                Insertar = Insertar + "     VALUES " + "\n";
                Insertar = Insertar + "           (@customerID " + "\n";
                Insertar = Insertar + "           ,@companyName " + "\n";
                Insertar = Insertar + "           ,@contactName " + "\n";
                Insertar = Insertar + "           ,@contactTitle " + "\n";
                Insertar = Insertar + "           ,@address)";

                var insertadas = conexion.Execute(Insertar, new
                {
                    customerID = customer.CustomerID,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    Address = customer.Address,
                });
                return insertadas;
            }
        }
    }
}
