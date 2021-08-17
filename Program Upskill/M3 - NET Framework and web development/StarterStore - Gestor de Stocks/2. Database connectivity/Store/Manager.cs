using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Store
{
    public class Manager<T> : IEnumerable<T>
    {
        private List<T> contents;
        public static Manager<T> Instance { get; private set; }

        static Manager()
        {
            Instance = new Manager<T>();
            //Instance.LoadFromFile();
            //Instance.ConnectToSqlServer();
        }

        private Manager() { }

        /*public  void ConnectToSqlServer()
        {
            string connectionString = "Server=.;Database=Northwind2016;User Id=sa; Password=upskills2021;";
            using (SqlConnection db = new SqlConnection (connectionString))
            {
                db.Open();
                SqlCommand selectCommand = new SqlCommand ("SELECT TitleOfCourtesy, FirstName, LastName from Employees", db );
                SqlDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    Console.WriteLine($"Hello {query.GetString(0)} {query.GetString(1)} {query.GetString(2)}!");
                } 
                db.Close();
            }
        }*/
        
        
        /*private void LoadFromFile()
        {
            PathAttribute pathAttribute = (PathAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(PathAttribute));
            if (File.Exists(pathAttribute.Path))
            {
                string fileContent = File.ReadAllText(pathAttribute.Path);
                contents = JsonSerializer.Deserialize<List<T>>(fileContent);
            }
            else
            {
                Console.WriteLine("Este ficheiro não existe!");
                contents = new List<T>();
            }
        }*/

        /*public void Add(Employee id1)
        {
            Employee.Add();
            contents.Add(id1);

        }

        /*public void Read(T t)
        {
            contents.Add(t);
        }

        public void Update(T t)
        {
            contents.Add(t);
        }

        public void Delete(T t)
        {
            contents.Add(t);
        }*/

        public IEnumerator<T> GetEnumerator()
        {
            return contents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return contents.GetEnumerator();
        }
    }
}